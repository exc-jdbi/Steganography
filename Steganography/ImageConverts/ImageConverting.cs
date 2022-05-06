
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

#pragma warning restore CS8600 // Das NULL-Literal oder ein möglicher NULL-Wert wird in einen Non-Nullable-Typ konvertiert.
#pragma warning restore CA1416 // Plattformkompatibilität überprüfen
}
