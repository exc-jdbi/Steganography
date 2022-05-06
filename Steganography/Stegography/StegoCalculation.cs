using System.Drawing;

namespace exc.jdbi.Steganographie;

using static exc.jdbi.ImageConvertings.ImageConverting;

public class StegoCalculation
{
#pragma warning disable CA1416 // Plattformkompatibilität überprüfen
  //Speicherkapazitäten (Storage capacities) ausrechnen 
  public static StorageCapacitiesInfo CheckStorageCapacities(Image imgbasic, Image imghide)
  {
    var result = new StorageCapacitiesInfo();
    var headerlength = 19; //pixels
    //To Bits
    result.StorageCapacitiesL1 = 3 * (imgbasic.Width * imgbasic.Height - headerlength);
    result.StorageCapacitiesL2 = (3 * imgbasic.Width * imgbasic.Height) + result.StorageCapacitiesL1;
    result.StorageCapacities = StorageCapacitiesBasicImage(imgbasic);
    result.RequiredCapacity = RequiredCapacityHideImage(imghide);
    result.PerceptionDistortion = result.RequiredCapacity > result.StorageCapacitiesL2;
    result.StorageCapacitiesVarify = result.RequiredCapacity <= result.StorageCapacities;
    return result;
  }

  public static StorageCapacitiesInfo CheckStorageCapacities(Image imgbasic, byte[] texthide)
  {
    var result = new StorageCapacitiesInfo();
    var headerlength = 19; //pixels
    //To Bits
    result.StorageCapacitiesL1 = 3 * (imgbasic.Width * imgbasic.Height - headerlength);
    result.StorageCapacitiesL2 = (3 * imgbasic.Width * imgbasic.Height) + result.StorageCapacitiesL1;
    result.StorageCapacities = StorageCapacitiesBasicImage(imgbasic);
    result.RequiredCapacity = RequiredCapacityHideText(texthide);
    result.PerceptionDistortion = result.RequiredCapacity > result.StorageCapacitiesL2;
    result.StorageCapacitiesVarify = result.RequiredCapacity <= result.StorageCapacities;
    return result;
  }

  internal static int StorageCapacitiesBasicImage(Image imgbasic)
  {
    AssertBasicImage(imgbasic);
    var headerlength = 19; //pixels
    var pixelcapacities = 8 * imgbasic.Width * imgbasic.Height;
    pixelcapacities -= headerlength;
    //to bits
    return 3 * pixelcapacities;
  }

  internal static int RequiredCapacityHideImage(Image imghide)
  {
    AssertHideImage(imghide);
    var bytes = FromImage(imghide);
    if (bytes is not null)
    {
      //var pixels = imghide.Width * imghide.Height;
      //var byteslength = 3 * pixels;

      //AesCrypt
      //var cryptobyteslength = (((bytes.Length + 1) / 16) + 1) * 16;
      var cryptobyteslength = ((bytes.Length / 16) + 1) * 16;
      cryptobyteslength += 16 + 32;//IV + Key
      var bitlength = 8 * cryptobyteslength;
      return bitlength;
    }
    return -1;
  }

  internal static int RequiredCapacityHideText(byte[] texthide)
  {
    AssertHideText(texthide);
    var bytes = texthide;

    //if(bytes.Length % 16 ==0)cryptobyteslength = (((bytes.Length + 1) / 16) + 1) * 16;
    //else  cryptobyteslength = ((bytes.Length / 16) + 1) * 16;
    var cryptobyteslength = ((bytes.Length / 16) + 1) * 16;
    cryptobyteslength += 16 + 32;//IV + Key
    var bitlength = 8 * cryptobyteslength;
    return bitlength;
  }

  private static void AssertBasicImage(Image imgbasic)
  {
    if (imgbasic is null)
      throw new ArgumentNullException(nameof(imgbasic));

    if (imgbasic.Width < 20 || imgbasic.Height < 20)
      throw new ArgumentOutOfRangeException(nameof(imgbasic));
  }

  private static void AssertHideImage(Image imghide)
  {
    if (imghide is null)
      throw new ArgumentNullException(nameof(imghide));

    if (imghide.Width < 8 || imghide.Height < 8)
      throw new ArgumentOutOfRangeException(nameof(imghide));
  }

  private static void AssertHideText(byte[] texthide)
  {
    if (texthide is null || texthide.Length < Steganography.TEXT_MIN_SIZE)
      throw new ArgumentNullException(nameof(texthide));
  }
#pragma warning restore CA1416 // Plattformkompatibilität überprüfen
}


