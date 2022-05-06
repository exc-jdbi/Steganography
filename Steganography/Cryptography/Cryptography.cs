


using System.Security.Cryptography;

namespace exc.jdbi.Cryptographie;
internal sealed partial class Cryptography
{

  public const int AES_CNG_KEY = 32;
  public const int PLAIN_MIN_SIZE = 10;
  public const int ASSOCIATED_SIZE_MIN = 16;
  public const int PLAIN_MAX_SIZE = int.MaxValue - 64;

  private static byte[] ToNewKey(byte[] key, byte[] entropie)
  {
    using var _sha = new HMACSHA512(key);
    return _sha.ComputeHash(entropie).Skip(16).Take(32).ToArray();
  }
}
