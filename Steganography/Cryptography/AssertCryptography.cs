

namespace exc.jdbi.Cryptographie;

partial class Cryptography
{
  private static void AssertCng(
   bool _encryption,
   byte[] key,
   byte[] plaincipher,
   byte[] entropie)
  {
    if (key.Length != AES_CNG_KEY)
      throw new ArgumentOutOfRangeException(nameof(key),
        $"{nameof(key)} != {AES_CNG_KEY}");

    if (plaincipher.Length < PLAIN_MIN_SIZE)
      throw new ArgumentOutOfRangeException(nameof(plaincipher),
        $"{nameof(plaincipher)} < {PLAIN_MIN_SIZE}");

    if (_encryption)
    {
      if (plaincipher.Length > PLAIN_MAX_SIZE)
        throw new ArgumentOutOfRangeException(nameof(plaincipher),
          $"{nameof(plaincipher)} < {PLAIN_MAX_SIZE}");
    }

    //Muss min. 16 Byte sein
    if (entropie.Length < ASSOCIATED_SIZE_MIN)
      throw new ArgumentOutOfRangeException(nameof(entropie),
        $"{nameof(entropie)} < {ASSOCIATED_SIZE_MIN}");
  }
}
