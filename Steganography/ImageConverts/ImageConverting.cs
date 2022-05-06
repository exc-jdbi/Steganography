
using System.Drawing;
using System.Drawing.Imaging;

namespace exc.jdbi.ImageConvertings;
public sealed class ImageConverting
{

#pragma warning disable CA1416 // Plattformkompatibilität überprüfen
#pragma warning disable CS8600 // Das NULL-Literal oder ein möglicher NULL-Wert wird in einen Non-Nullable-Typ konvertiert.


  public static Image? ToImage(byte[] bytesimg)
  {
    if (bytesimg is null || bytesimg.Length < 1)
      throw new ArgumentOutOfRangeException(nameof(bytesimg));
    var ic = new ImageConverter();
    return (Image)ic.ConvertFrom(bytesimg);
  }

  public static byte[]? FromImage(Image src)
  {
    //Generiert eine Byte-Array ohne FormatInformationen.
    //Funktioniert nur, wenn der grundlegende Stream in der
    //src-image nicht geschlossen wurde.
    var ic = new ImageConverter();
    return (byte[])ic.ConvertTo(src, typeof(byte[]));
  }

  public static byte[]? ToBytesFromImageFile(string imgfilepath)
  {
    //So wird korrekt zurückgesetzt.
    //Auch der grundlegende Stream in der Image
    //wird korrekt zurückgesetzt.
    using var img = LoadImage(imgfilepath);
    return FromImage(img);
  }

  public static Image? Copy(Image src)
  {
    var bytes = FromImage(src);
    return bytes is not null ? ToImage(bytes) : new Bitmap(0, 0);
  }

  public static Image LoadImage(string srcfilename, bool useembeddedcolormanagement = true, bool validateimagedata = true)
  {
    //Es wird eine Kopie gemacht. Filestream und das grundlegende 'img' werden
    //zurückgesetzt. 

    using var fs = new FileStream(srcfilename, FileMode.Open, FileAccess.Read);
    using var img = Image.FromStream(fs, useembeddedcolormanagement, validateimagedata);
    var result = Copy(img);
    if (result is not null) return result;
    return new Bitmap(0, 0);
  }

  public static void SaveImage(Image src, string dstfilename, ImageFormat? imgformat = null)
  {
    var defaultimgformat = imgformat ?? ImageFormat.Png;
    if (File.Exists(dstfilename)) File.Delete(dstfilename);
    using var fs = new FileStream(dstfilename, FileMode.CreateNew, FileAccess.Write);
    src.Save(fs, defaultimgformat);
  }

  public static bool EqualsImage(string img1filepath, string img2filepath)
  {
    var img1 = LoadImage(img1filepath);
    var img2 = LoadImage(img2filepath);
    return EqualsImage(img1, img2);
  }

  public static bool EqualsImage(Image img1, Image img2)
  {
    //https://stackoverflow.com/a/35153895
    var hash1 = ToHash(new Bitmap(img1));
    var hash2 = ToHash(new Bitmap(img2));
    //determine the number of equal pixel (x of 256)
    var equalelements = hash1.Zip(hash2, (i, j) => i == j).Count(eq => eq);
    return equalelements > hash1.Length - .005 * hash1.Length;
  }

  private static bool[] ToHash(Bitmap bmpsrc)
  {
    //https://stackoverflow.com/a/35153895
    var result = new List<bool>();
    var bmpmin = new Bitmap(bmpsrc, new Size(16, 16));
    for (int j = 0; j < bmpmin.Height; j++)
      for (int i = 0; i < bmpmin.Width; i++)
        //reduce colors to true / false                
        result.Add(bmpmin.GetPixel(i, j).GetBrightness() < 0.5f);
    return result.ToArray();
  }

  public static bool CheckImageFormat(string imageextention)
  {
    return imageextention.ToLower() switch
    {
      ".bmp" => true,
      ".emf" => true,
      ".gif" => true,
      ".jpg" => true,
      ".jpeg" => true,
      ".png" => true,
      ".tiff" => true,
      ".wmf" => true,
      ".exif" => true,
      _ => false,
    };
  }

  public static ImageFormat ToImageFormat(string imageextention)
  {
    return imageextention.ToLower() switch
    {
      ".bmp" => ImageFormat.Bmp,
      ".emf" => ImageFormat.Emf,
      ".gif" => ImageFormat.Gif,
      ".jpg" => ImageFormat.Jpeg,
      ".jpeg" => ImageFormat.Jpeg,
      ".png" => ImageFormat.Png,
      ".tiff" => ImageFormat.Tiff,
      ".wmf" => ImageFormat.Wmf,
      ".exif" => ImageFormat.Exif,
      _ => ImageFormat.Jpeg,
    };
  }

  //private static Image? ChanceFormatBm(Image img, ImageFormat format/*, EncoderValue ev = default*/)
  //{
  //  Image ?result = null;
  //  //ev = ev == default ? EncoderValue.CompressionNone : ev;
  //  using (var ms = new MemoryStream(ChanceFormatByte(img, format)))
  //  {
  //    var tmp = Image.FromStream(ms);
  //    result = Copy(tmp);
  //    if(result is not null)
  //    foreach (PropertyItem p in tmp.PropertyItems)
  //      result.SetPropertyItem(p);
  //  }
  //  return result;
  //}

  //private static byte[] ChanceFormatByte(Image img, ImageFormat format/*, EncoderValue ev = default*/)
  //{
  //  //ev = ev == null ? EncoderValue.CompressionNone : ev;
  //  using var ms = new MemoryStream();
  //  using var ep = new EncoderParameters(1);
  //  var qualitylevel = EncoderValue.CompressionNone;
  //  using var myEncoderParameters = new EncoderParameters(1);
  //  using var myEncoderParameter = new EncoderParameter(Encoder.Quality, (byte)qualitylevel);
  //  myEncoderParameters.Param[0] = myEncoderParameter;
  //  var ici = GetEncoderInfo(format);
  //  if (ici is not null)
  //    img.Save(ms, ici, myEncoderParameters);
  //  ms.Flush();
  //  return ms.ToArray();
  //}

  //private static ImageCodecInfo? GetEncoderInfo(ImageFormat format)
  //{
  //  var codecs = ImageCodecInfo.GetImageDecoders();
  //  foreach (var codec in codecs) 
  //    if (codec.FormatID == format.Guid) 
  //      return codec;  
  //  return null;
  //}

  //private ImageCodecInfo GetEncoderInfo(string mimeType)
  //{
  //  // mimeType z.B. "Image/Png" siehe
  //  // https://referencesource.microsoft.com/System.Web.DataVisualization/a.html#50b0fd2ab80e3a33
  //  var encoders = ImageCodecInfo.GetImageEncoders;
  //  for (int j = 0, loopTo = encoders.Length - 1; j <= loopTo; j++)
  //  {
  //    if (encoders[j].MimeType == mimeType)
  //    {
  //      return encoders[j];
  //    }
  //  }

  //  return default;
  //}

  //public static Image CopyWithFormat(Image src, PixelFormat format = PixelFormat.Undefined)
  //{
  //  format = format == PixelFormat.Undefined ? src.PixelFormat : PixelFormat.Format32bppArgb;
  //  return ImageFromBytes(ImageToBytes(src), new Size(src.Width, src.Height), format);
  //}
  //public static byte[] ImageToBytes(Image img)
  //{
  //  //bpp = BytePerPixel
  //  var bmp = new Bitmap(img);
  //  var bpp = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
  //  var bytes = new byte[bmp.Width * bmp.Height * bpp];
  //  var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
  //  var bmpdata = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
  //  Marshal.Copy(bmpdata.Scan0, bytes, 0, bytes.Length);
  //  bmp.UnlockBits(bmpdata);
  //  return bytes;
  //}

  //public static Image ImageFromBytes(byte[] bytes, Size size, PixelFormat format = PixelFormat.Format32bppArgb)
  //{
  //  var bmp = new Bitmap(size.Width, size.Height, format);
  //  var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
  //  var bmpdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
  //  Marshal.Copy(bytes, 0, bmpdata.Scan0, bytes.Length);
  //  bmp.UnlockBits(bmpdata);
  //  return bmp;
  //}

#pragma warning restore CS8600 // Das NULL-Literal oder ein möglicher NULL-Wert wird in einen Non-Nullable-Typ konvertiert.
#pragma warning restore CA1416 // Plattformkompatibilität überprüfen
}