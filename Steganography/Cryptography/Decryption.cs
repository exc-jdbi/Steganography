

using System.Drawing;
using System.Diagnostics;
using System.Security.Cryptography;

namespace exc.jdbi.Cryptographie;

using static exc.jdbi.ImageConvertings.ImageConverting;

partial class Cryptography
{  
#pragma warning disable CA1416 // Plattformkompatibilität überprüfen 
 
  public static Image AesDecryptionImage(byte[] password, byte[] cipher)
  {
    var salt = cipher.Skip(cipher.Length - 16).ToArray();
    var associated = cipher.Skip(cipher.Length - 32).Take(16).ToArray();
    var key = ToNewKey(password, salt);
    var c = cipher.Take(cipher.Length - 32).ToArray();
    var bimg = AesDecryption(key, c, associated);
    var result = ToImage(bimg);
    return result is not null ? result : new Bitmap(0, 0);
  }

  public static byte[] AesDecryptionText(byte[] password, byte[] cipher)
  {
    var salt = cipher.Skip(cipher.Length - 16).ToArray();
    var associated = cipher.Skip(cipher.Length - 32).Take(16).ToArray();
    var key = ToNewKey(password, salt);
    var c = cipher.Take(cipher.Length - 32).ToArray();
    return AesDecryption(key, c, associated);
  }

  private static byte[] AesDecryption(
    byte[] key,
    byte[] cipher,
    byte[] associated,
    bool _assert = false)
  {
    if (_assert)
      AssertCng(false, key, cipher, associated);
    
    var sw = Stopwatch.StartNew();
    using var aes256 = Aes.Create();

    aes256.Mode = CipherMode.CBC;
    aes256.Padding = PaddingMode.PKCS7;
    //aes256.BlockSize = 256;
    //aes256.FeedbackSize = 256; 

    aes256.IV = cipher[..16].ToArray();
    aes256.Key = ToNewKey(key, associated);

    using var de = aes256.CreateDecryptor();

    var ciphertext = cipher[16..cipher.Length].ToArray(); 

    var result =  de.TransformFinalBlock(ciphertext, 0, ciphertext.Length);

    sw.Stop();

    int deltatime = (int)(TimeSleep - sw.ElapsedMilliseconds);
    if (deltatime > 0) Thread.Sleep(deltatime);

    return result;
  }
#pragma warning restore CA1416 // Plattformkompatibilität überprüfen
}
