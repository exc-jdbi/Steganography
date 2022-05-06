
namespace exc.jdbi.Steganographie;
public class StegoInfo
{ 
  public string? HideImagePath = null;
  public string? BasicImagePath = null;
  public string? StegoImagePath = null;
   
  public byte[]? HideText = null;
  public string? ImageExtention = null;
  public byte[]? Password = null;

  public void Reset()
  {
    this.HideImagePath = null;
    this.BasicImagePath = null;
    this.ImageExtention = null;
    this. StegoImagePath = null;

    if (this.HideText is not null)
      Array.Clear(this.HideText);
    this.HideText = null;

    if (this.Password is not null)
      Array.Clear(this.Password);
    this.Password = null;
  } 
}
