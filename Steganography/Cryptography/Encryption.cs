

using System.Drawing;
using System.Security.Cryptography;

namespace exc.jdbi.Cryptographie;

using exc.jdbi.Randoms;
using System.Diagnostics;
using static exc.jdbi.ImageConvertings.ImageConverting;

partial class Cryptography
{
  private const long TimeSleep = 120; //ms
  public static byte[] AesEncryption(byte[] password, Image imghide)
  {
    var salt = new byte[ASSOCIATED_SIZE_MIN];
    var associated = new byte[ASSOCIATED_SIZE_MIN];
    SOCR.IsAlive();
    SOCR.NextBytes(salt);
    SOCR.NextBytes(associated);
    var key = ToNewKey(password, salt);
    var plain = FromImage(imghide);
    if (plain is not null)
      return AesEncryption(key, plain, associated).Concat(associated).Concat(salt).ToArray();

    throw new ArgumentNullException(nameof(imghide),
       $"HideImage cannot be reformatted. Please use a other HideImage.");
  }

  public static byte[] AesEncryption(byte[] password, byte[] texthide)
  {
    var salt = new byte[ASSOCIATED_SIZE_MIN];
    var associated = new byte[ASSOCIATED_SIZE_MIN];
    SOCR.IsAlive();
    SOCR.NextBytes(salt);
    SOCR.NextBytes(associated);
    var key = ToNewKey(password, salt);
    var plain = texthide;
    return AesEncryption(key, plain, associated).Concat(associated).Concat(salt).ToArray();
  }

  private static byte[] AesEncryption(
    byte[] key,
    byte[] plain,
    byte[] associated,
    bool _assert = false)
  {
    if (_assert)
      AssertCng(true, key, plain, associated);

    var sw = Stopwatch.StartNew();
    using var aes256 = Aes.Create();

    aes256.Mode = CipherMode.CBC;
    aes256.Padding = PaddingMode.PKCS7;
    //aes256.BlockSize = 256;
    //aes256.FeedbackSize = 256;

    aes256.GenerateIV();

    var iv = aes256.IV;

    aes256.Key = ToNewKey(key, associated);

    using var ce = aes256.CreateEncryptor();

    var cipher = ce.TransformFinalBlock(plain, 0, plain.Length);

    var result = iv.Concat(cipher).ToArray();

    sw.Stop();

    //Verzögerung um TimeAttacs entgegen zuwirken.
    int deltatime = (int)(TimeSleep - sw.ElapsedMilliseconds);
    if (deltatime > 0) Thread.Sleep(deltatime);

    return result;
  }

}
