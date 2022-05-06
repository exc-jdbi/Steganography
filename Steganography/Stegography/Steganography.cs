
using System.Drawing;

namespace exc.jdbi.Steganographie;

public partial class Steganography
{
  public const int TEXT_MIN_SIZE = 10;
  public const int PASSWORD_MIN_SIZE = 10;
  public static readonly Size HIDE_IMAGE_SIZE = new(8, 8);
  public static readonly Size BASIC_IMAGE_SIZE = new(20, 20);
}
