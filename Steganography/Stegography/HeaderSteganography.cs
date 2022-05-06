
using System.Collections;
using System.Drawing;
using System.Text;

namespace exc.jdbi.Steganographie;

using static exc.jdbi.ImageConvertings.ImageConverting;

partial class Steganography
{
#pragma warning disable CA1416 // Plattformkompatibilität überprüfen

  public static char CheckImageHeader(string basicimgpath)
  {
    using var bmp = (Bitmap)LoadImage(basicimgpath);
    var sb = new StringBuilder(56);

    for (int i = 0; i < 19; i++)
    {
      var pxl = bmp.GetPixel(i, 0);
      sb.Append((pxl.R & 1) == 0 ? 0 : 1);
      sb.Append((pxl.G & 1) == 0 ? 0 : 1);
      if (i != 18) sb.Append((pxl.B & 1) == 0 ? 0 : 1);
    }
    //var c = new char[] {'M','N','I','T' };
    var sig1 = (char)Convert.ToByte(string.Join(string.Empty, sb.ToString()[..8].Reverse().ToArray()), 2);
    var sig2 = (char)Convert.ToByte(string.Join(string.Empty, sb.ToString().Substring(8, 8).Reverse().ToArray()), 2);
    var sig3 = (char)Convert.ToByte(string.Join(string.Empty, sb.ToString().Substring(16, 8).Reverse().ToArray()), 2);
    //var len = Convert.ToInt32(string.Join(string.Empty, sb.ToString().Substring(24, 32).Reverse().ToArray()), 2);

    if (sig1 != 'M') return char.MinValue;
    if (sig2 != 'N') return char.MinValue;
    return sig3 == 'I' || sig3 == 'T' ? sig3 : char.MinValue;
  }

  private static BitArray ToHeader(int length, bool imgheader)
  {
    var sign = new[] { (byte)'M', (byte)'N', imgheader ? (byte)'I' : (byte)'T' };
    var blength = BitConverter.GetBytes(length / 8);
    var header = sign.Concat(blength).ToArray();

    //var a = new BitArray(header);
    //var b = new byte[(a.Length - 1) / 8 + 1];
    //a.CopyTo(b, 0);

    return new BitArray(header);
  }

  private static int FromHeaderCodeLength(Image img)
   => FromHeader(img).length;


  private static (int length, char[] sign) FromHeader(Image img)
  {
    var bmp = new Bitmap(img);
    var sb = new StringBuilder(56);

    for (int i = 0; i < 19; i++)
    {
      var pxl = bmp.GetPixel(i, 0);
      sb.Append((pxl.R & 1) == 0 ? 0 : 1);
      sb.Append((pxl.G & 1) == 0 ? 0 : 1);
      if (i != 18) sb.Append((pxl.B & 1) == 0 ? 0 : 1);
    }
    //var c = new char[] {'M','N','I','T' };
    var sig1 = (char)Convert.ToByte(string.Join(string.Empty, sb.ToString()[..8].Reverse().ToArray()), 2);
    var sig2 = (char)Convert.ToByte(string.Join(string.Empty, sb.ToString().Substring(8, 8).Reverse().ToArray()), 2);
    var sig3 = (char)Convert.ToByte(string.Join(string.Empty, sb.ToString().Substring(16, 8).Reverse().ToArray()), 2);
    var len = Convert.ToInt32(string.Join(string.Empty, sb.ToString().Substring(24, 32).Reverse().ToArray()), 2);
    return (len, new char[] { sig1, sig2, sig3 });
  }

#pragma warning restore CA1416 // Plattformkompatibilität überprüfen

}
