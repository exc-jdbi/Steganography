

namespace exc.jdbi.Stegographie.Forms.App;

using exc.jdbi.Steganographie;
using static exc.jdbi.ImageConvertings.ImageConverting;
internal partial class FrmMain : Form
{
  private bool IsVaildDragDrop = false;
  internal string FileNamePath = string.Empty;

  public FrmMain()
  {
    this.InitializeComponent(); 
    this.ActiveControl = this.BtEncryption;
  }

  private void BtEncryption_Click(object sender, EventArgs e)
  {
    this.IsVaildDragDrop = true;
    this.ToStegoFrm(true);
  }

  private void BtDecryption_Click(object sender, EventArgs e)
  {
    this.IsVaildDragDrop = true;
    this.ToStegoFrm(false);
  }

  private void LbDragDrop_DragDrop(object sender, DragEventArgs e)
  {
    if (e.Data is null) return;
    if (this.IsVaildDragDrop && this.FileNamePath is not null)
    {
      var c = Steganography.CheckImageHeader(this.FileNamePath);
      if (c == char.MinValue) this.ToStegoFrm(true);
      else this.ToStegoFrm(false, c);
    }
  }

  private void LbDragDrop_DragEnter(object sender, DragEventArgs e)
  {
    this.LbDragDrop.Font = new Font("Arial", 20F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);

    this.IsVaildDragDrop = this.SetFilename(e);
    if (this.IsVaildDragDrop)
    {
      e.Effect = DragDropEffects.Copy;
      return;
    }
    e.Effect = DragDropEffects.None;
  }

  private void LbDragDrop_DragLeave(object sender, EventArgs e)
    => this.LbDragDrop.Font = new Font("Arial", 20F, FontStyle.Regular, GraphicsUnit.Point);

  private void ToStegoFrm(bool frmencryption, char signchar = char.MinValue)
  {
    if (!this.IsVaildDragDrop) return;

    //Nach Schlissen von FrmStegoEncryption bzw. FrmStegodecryption
    //werden die Forms korrekt zurückgesetzt. 
    //Auch die Instanz von StegoEncryptionThread bzw. StegoDecryptionThread
    //werden korrekt zurückgesetzt. 
    if (frmencryption)
      _ =new  StegoEncryptionThread(this,this.FileNamePath);
    else _ = new StegoDecryptionThread(this, this.FileNamePath, signchar);

    this.LbDragDrop.Font = new Font("Arial", 20F, FontStyle.Regular, GraphicsUnit.Point);
  }

  private bool SetFilename(DragEventArgs e)
  {
    if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
    {
      if (e.Data is null) return false;
      if (e.Data.GetData("FileDrop") is string[] data)
      {
        if (data.Length == 1)
        {
          this.FileNamePath = data[0];
          string ext = Path.GetExtension(this.FileNamePath).ToLower();
          return CheckImageFormat(ext);
        }
      }
    }
    return false;
  }

}
