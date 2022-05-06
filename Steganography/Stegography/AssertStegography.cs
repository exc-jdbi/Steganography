
using System.Text;
using System.Drawing;

namespace exc.jdbi.Steganographie;
using static StegoCalculation;
using static exc.jdbi.ImageConvertings.ImageConverting;

partial class Steganography
{

#pragma warning disable CA1416 // Plattformkompatibilität überprüfen
#pragma warning disable CS8604 // Mögliches Nullverweisargument.
  private static void AssertEmbedding(StegoInfo stegoInfo, bool imgagecheck)
  {
    if (imgagecheck)
    {
      AssertEmbeddingImg(stegoInfo.BasicImagePath, stegoInfo.HideImagePath, stegoInfo.Password);
      AssertCapacity(stegoInfo, imgagecheck);
      return;
    }
    AssertEmbeddingText(stegoInfo.BasicImagePath, stegoInfo.HideText, stegoInfo.Password);
    AssertCapacity(stegoInfo, imgagecheck);
  }

  private static void AssertExtract(StegoInfo stegoInfo, bool isimagestegography)
   => AssertExtract(stegoInfo.StegoImagePath, stegoInfo.Password, isimagestegography);

  private static void AssertCapacity(StegoInfo stegoInfo, bool imgagecheck)
  {
    if (imgagecheck)
    {
      using var imgbasic = LoadImage(stegoInfo.BasicImagePath);
      using var imghide = LoadImage(stegoInfo.HideImagePath);
      var _csc = CheckStorageCapacities(imgbasic, imghide);
      if (!_csc.StorageCapacitiesVarify)
        throw new ArgumentOutOfRangeException($"'BasicImage'",
          $"The existing capacity in the 'BasicImage' is not sufficient");
      return;
    }
    using var _imgbasic = LoadImage(stegoInfo.BasicImagePath);
    var csc = CheckStorageCapacities(_imgbasic, stegoInfo.HideText);
    if (!csc.StorageCapacitiesVarify)
      throw new ArgumentOutOfRangeException($"'BasicImage'",
        $"The existing capacity in the 'BasicImage' is not sufficient");
  }

  private static void AssertEmbeddingImg(string imgbasicpath, string imghidepath, byte[] password)
  {
    if (imgbasicpath is null || !File.Exists(imgbasicpath))
      throw new ArgumentNullException(nameof(imgbasicpath));

    if (imghidepath is null || !File.Exists(imghidepath))
      throw new ArgumentNullException(nameof(imghidepath));

    using var imgbasic = LoadImage(imgbasicpath);
    using var imghide = LoadImage(imgbasicpath);

    if (imgbasic is not null && imghide is not null)
    {
      if (imgbasic.Width < BASIC_IMAGE_SIZE.Width || imgbasic.Height < BASIC_IMAGE_SIZE.Height)
        throw new ArgumentOutOfRangeException(nameof(imgbasicpath),
        $"Minimum size: Width = {BASIC_IMAGE_SIZE.Width} / Height = {BASIC_IMAGE_SIZE.Height}");

      if (imghide.Width < HIDE_IMAGE_SIZE.Width || imghide.Height < HIDE_IMAGE_SIZE.Height)
        throw new ArgumentOutOfRangeException(nameof(imghidepath),
        $"Minimum size: Width = {HIDE_IMAGE_SIZE.Width} / Height = {HIDE_IMAGE_SIZE.Height}");

      if (password is null || password.Length < PASSWORD_MIN_SIZE)
        throw new ArgumentOutOfRangeException(nameof(password),
        $"Minimum password size is {PASSWORD_MIN_SIZE}");
    }
  }

  private static void AssertEmbeddingText(string imgbasicpath, byte[] texthide, byte[] password)
  {
    if (imgbasicpath is null || !File.Exists(imgbasicpath))
      throw new ArgumentNullException(nameof(imgbasicpath));

    if (texthide is null || texthide.Length < TEXT_MIN_SIZE)
      throw new ArgumentOutOfRangeException(nameof(texthide),
        $"Minimum text size is {TEXT_MIN_SIZE}");

    if (password is null || password.Length < PASSWORD_MIN_SIZE)
      throw new ArgumentOutOfRangeException(nameof(password),
        $"Minimum password size is {PASSWORD_MIN_SIZE}");

    using var imgbasic = LoadImage(imgbasicpath);
    if (imgbasic.Width < BASIC_IMAGE_SIZE.Width || imgbasic.Height < BASIC_IMAGE_SIZE.Height)
      throw new ArgumentOutOfRangeException(nameof(imgbasicpath),
      $"Minimum size: Width = {BASIC_IMAGE_SIZE.Width} / Height = {BASIC_IMAGE_SIZE.Height}");
  }

  private static void AssertExtract(string imgstegopath, byte[] password, bool isimagestegography)
  {
    if (password is null || password.Length < PASSWORD_MIN_SIZE)
      throw new ArgumentOutOfRangeException(nameof(password));

    if (imgstegopath is null)
      throw new ArgumentNullException(nameof(imgstegopath));

    using var imgstego = LoadImage(imgstegopath);

    if (imgstego.Width < BASIC_IMAGE_SIZE.Width || imgstego.Height < BASIC_IMAGE_SIZE.Height)
      throw new ArgumentOutOfRangeException(nameof(imgstegopath),
        $"Minimum size: Width = {BASIC_IMAGE_SIZE.Width} / Height = {BASIC_IMAGE_SIZE.Height}");

    if (!CheckPictureStego(imgstego, isimagestegography))
      throw new ArgumentException(
        $"Signature is wrong! {nameof(imgstego)} is not a legal image.",
        nameof(imgstegopath));
  }

  private static bool CheckPictureStego(Image imgstego, bool isimagestegography)
  {
    var result = true;
    var bmp = new Bitmap(imgstego);
    var sb = new StringBuilder(56);

    for (int i = 0; i < 8; i++)
    {
      var pxl = bmp.GetPixel(i, 0);
      sb.Append((pxl.R & 1) == 0 ? 0 : 1);
      sb.Append((pxl.G & 1) == 0 ? 0 : 1);
      sb.Append((pxl.B & 1) == 0 ? 0 : 1);
    }
    //var c = new char[] { 'M', 'N', 'I', 'T' };
    var sig1 = Convert.ToByte(string.Join(string.Empty, sb.ToString()[..8].Reverse().ToArray()), 2);
    if (sig1 != 'M') return false;
    var sig2 = Convert.ToByte(string.Join(string.Empty, sb.ToString().Substring(8, 8).Reverse().ToArray()), 2);
    if (sig2 != 'N') return false;
    var sig3 = Convert.ToByte(string.Join(string.Empty, sb.ToString().Substring(16, 8).Reverse().ToArray()), 2);
    if (isimagestegography && sig3 != 'I') return false;
    if (!isimagestegography && sig3 != 'T') return false;
    //if (sig3 != 'I' && sig3 != 'T') return false;

    return result;
  }
#pragma warning restore CS8604 // Mögliches Nullverweisargument.
#pragma warning restore CA1416 // Plattformkompatibilität überprüfen
}
