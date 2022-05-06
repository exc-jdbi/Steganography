
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace exc.jdbi.Steganographie;

using static StegoCalculation;
using static Cryptographie.Cryptography;
using static exc.jdbi.ImageConvertings.ImageConverting;

partial class Steganography
{

#pragma warning disable CA1416 // Plattformkompatibilität überprüfen
#pragma warning disable CS8604 // Mögliches Nullverweisargument.
  public static Image EmbeddingImageNaive(StegoInfo steginfo)
  {
    AssertEmbedding(steginfo, true);
    var basicimg = (Bitmap)LoadImage(steginfo.BasicImagePath, true, true);
    using var hideimg = (Bitmap)LoadImage(steginfo.HideImagePath, true, true);
    var plain = FromImage(hideimg);

    var csc = CheckStorageCapacities(basicimg, hideimg);
    var header = ToHeader(csc.RequiredCapacity, true);
    var width = basicimg.Width;
    var height = basicimg.Height;
    var headerlength = 19; // 3 * 8 + 32; //pixels

    bool bit;
    byte value = 0;
    int pxlidx = 0, index = 0;
    var cipher = AesEncryption(steginfo.Password, hideimg);

    int w = 0, h = 0;
    byte r = 0, g = 0, b = 0;
    for (int i = 0; i < 8; i++)
    {
      for (h = 0; h < height; h++)
      {
        for (w = 0; w < width; w++)
        {
          var pxlcol = basicimg.GetPixel(w, h);
          r = pxlcol.R; g = pxlcol.G; b = pxlcol.B;
          if (w < headerlength && h == 0 && i == 0)
          {
            r = header[3 * w] ? (byte)(pxlcol.R | 1) : (byte)(pxlcol.R & ~1);
            g = header[3 * w + 1] ? (byte)(pxlcol.G | 1) : (byte)(pxlcol.G & ~1);
            if (header.Length > 3 * w + 2)
              b = header[3 * w + 2] ? (byte)(pxlcol.B | 1) : (byte)(pxlcol.B & ~1);
            else b = pxlcol.B;
            basicimg.SetPixel(w, h, Color.FromArgb(r, g, b));
            continue;
          }
          if (index == cipher.Length && pxlidx == 8) goto jump;
          if (pxlidx % 8 == 0) { pxlidx = 0; value = cipher[index++]; }
          bit = (value & (1 << pxlidx++)) != 0;
          r = bit ? (byte)(pxlcol.R | (1 << i)) : (byte)(pxlcol.R & ~(1 << i));

          if (index == cipher.Length && pxlidx == 8) goto jump;
          if (pxlidx % 8 == 0) { pxlidx = 0; value = cipher[index++]; }
          bit = (value & (1 << pxlidx++)) != 0;
          g = bit ? (byte)(pxlcol.G | (1 << i)) : (byte)(pxlcol.G & ~(1 << i));

          if (index == cipher.Length && pxlidx == 8) goto jump;
          if (pxlidx % 8 == 0) { pxlidx = 0; value = cipher[index++]; }
          bit = (value & (1 << pxlidx++)) != 0;
          b = bit ? (byte)(pxlcol.B | (1 << i)) : (byte)(pxlcol.B & ~(1 << i));
          basicimg.SetPixel(w, h, Color.FromArgb(r, g, b));
        }
      }
    }
    jump:
    basicimg.SetPixel(w, h, Color.FromArgb(r, g, b));
    return basicimg;
  }

  public static Image EmbeddingImage(StegoInfo steginfo)
  {
    AssertEmbedding(steginfo, true);
    var basicimg = (Bitmap)LoadImage(steginfo.BasicImagePath, true, true);
    using var hideimg = (Bitmap)LoadImage(steginfo.HideImagePath, true, true);
    //var plain = FromImage(hideimg);

    var csc = CheckStorageCapacities(basicimg, hideimg);
    var header = ToHeader(csc.RequiredCapacity, true);
    var headerlength = 19; // 3 * 8 + 32; //pixels

    bool bit;
    byte value = 0;
    int pxlidx = 0, index = 0;
    var cipher = AesEncryption(steginfo.Password, hideimg);

    unsafe
    {
      var bpp = Image.GetPixelFormatSize(basicimg.PixelFormat) / 8;
      var rc = new Rectangle(0, 0, basicimg.Width, basicimg.Height);
      var bmdata = basicimg.LockBits(rc, ImageLockMode.ReadWrite, basicimg.PixelFormat);

      byte* ptrscan = (byte*)bmdata.Scan0.ToPointer();
      for (int i = 0; i < 8; i++)
      {
        for (int y = 0; y < bmdata.Height; y++)
        {
          //BGR >> Blue(x) + Green(x+1) + Red(x+2)

          byte* currentline = ptrscan + (y * bmdata.Stride);
          for (int x = 0; x < (bpp * bmdata.Width); x += bpp)
          {
            if (x < 3 * headerlength && y == 0 && i == 0)
            {
              _ = header[x] ? currentline[x + 2] |= 1 : currentline[x + 2] = (byte)(currentline[x + 2] & ~1);
              _ = header[x + 1] ? currentline[x + 1] |= 1 : currentline[x + 1] = (byte)(currentline[x + 1] & ~1);
              if (header.Length > x + 2)
                _ = header[x + 2] ? currentline[x] |= 1 : currentline[x] = (byte)(currentline[x] & ~1);
              continue;
            }

            if (index == cipher.Length && pxlidx == 8) goto jump;
            if (pxlidx % 8 == 0) { pxlidx = 0; value = cipher[index++]; }
            bit = (value & (1 << pxlidx++)) != 0;
            _ = bit ? currentline[x] = (byte)(currentline[x] | (1 << i)) : currentline[x] = (byte)(currentline[x] & ~(1 << i));

            if (index == cipher.Length && pxlidx == 8) goto jump;
            if (pxlidx % 8 == 0) { pxlidx = 0; value = cipher[index++]; }
            bit = (value & (1 << pxlidx++)) != 0;
            _ = bit ? currentline[x + 1] = (byte)(currentline[x + 1] | (1 << i)) : currentline[x + 1] = (byte)(currentline[x + 1] & ~(1 << i));

            if (index == cipher.Length && pxlidx == 8) goto jump;
            if (pxlidx % 8 == 0) { pxlidx = 0; value = cipher[index++]; }
            bit = (value & (1 << pxlidx++)) != 0;
            _ = bit ? currentline[x + 2] = (byte)(currentline[x + 2] | (1 << i)) : currentline[x + 2] = (byte)(currentline[x + 2] & ~(1 << i));

          }
        }
      }
      jump:
      basicimg.UnlockBits(bmdata);
      return basicimg;
    }
  }

  public static Image ExtractImageNaive(StegoInfo steginfo)
  {
    AssertExtract(steginfo, true);
    var bmp = (Bitmap)LoadImage(steginfo.StegoImagePath);
    var length = FromHeaderCodeLength(bmp);

    var width = bmp.Width;
    var height = bmp.Height;

    byte r, g, b;
    var index = 0;
    var cipher = new byte[length];
    var sbits = new StringBuilder(8);

    for (int i = 0; i < 8; i++)
    {
      for (int h = 0; h < height; h++)
      {
        for (int w = 0; w < width; w++)
        {
          if (w == 0 && h == 0 && i == 0)
            w = 19;//skip header.

          var pxlcol = bmp.GetPixel(w, h);
          r = pxlcol.R; g = pxlcol.G; b = pxlcol.B;

          sbits.Append((r & (1 << i)) == 0 ? 0 : 1);
          if (sbits.Length == 8) cipher[index++] = ToByteR(sbits);
          if (index == length) goto jump;

          sbits.Append((g & (1 << i)) == 0 ? 0 : 1);
          if (sbits.Length == 8) cipher[index++] = ToByteR(sbits);
          if (index == length) goto jump;

          sbits.Append((b & (1 << i)) == 0 ? 0 : 1);
          if (sbits.Length == 8) cipher[index++] = ToByteR(sbits);
          if (index == length) goto jump;
        }
      }
    }

    jump:
    return AesDecryptionImage(steginfo.Password, cipher);
  }

  public static Image ExtractImage(StegoInfo steginfo)
  {
    AssertExtract(steginfo, true);

    var bmp = (Bitmap)LoadImage( steginfo.StegoImagePath);
    var length = FromHeaderCodeLength(bmp) ;

    var index = 0;
    var cipher = new byte[length];
    var sbits = new StringBuilder(8);

    unsafe
    {
      var bpp = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
      var rc = new Rectangle(0, 0, bmp.Width, bmp.Height);
      var bmdata = bmp.LockBits(rc, ImageLockMode.ReadWrite, bmp.PixelFormat);

      byte* ptrscan = (byte*)bmdata.Scan0.ToPointer();
      for (int i = 0; i < 8; i++)
      {
        for (int y = 0; y < bmdata.Height; y++)
        {
          byte* currentline = ptrscan + (y * bmdata.Stride);
          for (int x = 0; x < (bpp * bmdata.Width); x += bpp)
          {
            if (x == 0 && y == 0 && i == 0)
              x = 3 * 19;//skip header.

            sbits.Append((currentline[x] & (1 << i)) == 0 ? 0 : 1);
            if (sbits.Length == 8) cipher[index++] = ToByteR(sbits);
            if (index == length) goto jump;

            sbits.Append((currentline[x + 1] & (1 << i)) == 0 ? 0 : 1);
            if (sbits.Length == 8) cipher[index++] = ToByteR(sbits);
            if (index == length) goto jump;

            sbits.Append((currentline[x + 2] & (1 << i)) == 0 ? 0 : 1);
            if (sbits.Length == 8) cipher[index++] = ToByteR(sbits);
            if (index == length) goto jump;
          }
        }
      }

      jump:
      bmp.UnlockBits(bmdata);
      return AesDecryptionImage(steginfo.Password, cipher);
    }
  }

  private static byte ToByteR(StringBuilder sbits, bool sbclear = true)
  {
    var result = Convert.ToByte(string.Join(string.Empty, sbits.ToString().Reverse().ToArray()), 2);
    if (sbclear) sbits.Clear();
    return result;
  }

#pragma warning restore CS8604 // Mögliches Nullverweisargument.
#pragma warning restore CA1416 // Plattformkompatibilität überprüfen

}
