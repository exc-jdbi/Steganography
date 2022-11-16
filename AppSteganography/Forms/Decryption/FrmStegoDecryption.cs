
using System.Text;


namespace exc.jdbi.Stegographie.Forms;

using exc.jdbi.Steganographie;
using exc.jdbi.ImageConvertings;

internal partial class FrmStegoDecryption : Form
{
  private bool IsVaildDragDrop = false;
  internal string FileNamePath = string.Empty;

  private const int HIDE_TEXT_MIN_LENGTH = 10;
  private static readonly Color TEXT_COLOR_FALSE = Color.Red;
  private static readonly Color TEXT_COLOR = SystemColors.ControlText;

  private FrmStegoDecryption()
  {
    this.InitializeComponent();

    this.BtSave.Enabled = false; 
  }

  public FrmStegoDecryption(string? basicimgpath, char signchar = char.MinValue) : this()
  {
     if (File.Exists(basicimgpath))
    {
      this.TbBasicImage.Text = basicimgpath is not null ? basicimgpath : string.Empty;
      this.PbBasicImage.Image = ImageConverting.LoadImage(this.TbBasicImage.Text);
    }
    this.SetTextImageOption(signchar);
  }

  private void Button_Click(object sender, EventArgs e)
  {
    switch (sender)
    {
      case var obj when ReferenceEquals(this.BtBasicImage, obj): this.SetNewImage(this.BtBasicImage); break;
       case var obj when ReferenceEquals(this.BtSave, obj): this.SFD(); break;
      case var obj when ReferenceEquals(this.BtDecryption, obj): this.Decryption(); break;
      case var obj when ReferenceEquals(this.BtClose, obj): this.Close(); break;
    }
  } 

  private void PictureBox_DragDrop(object sender, DragEventArgs e)
  {
    this.TbHideImage.Clear();
    this.TbBasicImage.Clear();
    this.BtDecryption.Enabled = true;
    this.ResetPictureBoxImage(this.PbHideImage);
    this.ResetPictureBoxImage(this.PbBasicImage);
    if (e.Data is null) return;
    if (this.IsVaildDragDrop && this.FileNamePath is not null)
    {
      if (this.PbBasicImage == sender)
      {
        var c = Steganography.CheckImageHeader(this.FileNamePath);
        if (c == 'T' || c == 'I')
        {
          this.TbBasicImage.Text = this.FileNamePath is not null ? this.FileNamePath : string.Empty;
          this.PbBasicImage.Image = ImageConverting.LoadImage(this.TbBasicImage.Text);
          if (this.PbHideImage.Image is not null) this.ResetPictureBoxImage(this.PbHideImage);
          this.TbHideImage.Clear();
          this.SetTextImageOption(c);
          return;
        }
        MessageBox.Show("Image is not crypted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
  }

  private void PictureBox_DragEnter(object sender, DragEventArgs e)
  {
    this.IsVaildDragDrop = this.SetFilename(e);
    if (this.IsVaildDragDrop)
    {
      e.Effect = DragDropEffects.Copy;
      return;
    }
    e.Effect = DragDropEffects.None;
  }

  private void PictureBox_DragLeave(object sender, EventArgs e)
  {

  } 

  private void FrmStegoDecryption_FormClosing(object sender, FormClosingEventArgs e)
  {
    this.ResetAllControls();
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
          return ImageConverting.CheckImageFormat(ext);
        }
      }
    }
    return false;
  }

  private void Decryption()
  {
    if (this.CheckAllParameters())
    {
      var c = Steganography.CheckImageHeader(this.TbBasicImage.Text);
      if (c == 'T' || c == 'I')
      {
        this.BtSave.Enabled = false;
        this.BtDecryption.Enabled = false;

        try
        {
          if (c == 'T')
          {
            var stegoinfo = ToStegoInfoTxt(this.TbBasicImage.Text, this.TbHideText.Text, this.TbPassword.Text);
            this.TbPassword.Clear();
            var txt = Steganography.ExtractText(stegoinfo);
            this.TbHideText.Text = Encoding.UTF8.GetString(txt);
          }
          if (c == 'I')
          {
            var stegoinfo = ToStegoInfoImg(this.TbBasicImage.Text, this.TbHideImage.Text, this.TbPassword.Text);
            this.TbPassword.Clear();
            var img = Steganography.ExtractImage(stegoinfo);
            this.ResetPictureBoxImage(this.PbHideImage);
            this.TbHideText.Clear();
            this.PbHideImage.Image = img;
            this.BtSave.Enabled = true;
          }
        }
        catch (Exception ex)
        {
          this.TbPassword.Clear();
          var msg = $"Password is not correctly - {ex.Message}";
          MessageBox.Show(msg, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        return;

      }
      this.TbPassword.Clear();
      MessageBox.Show("Image is not crypted", "INFO",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
      if(this.PbBasicImage.Image is not null)
        this.ResetPictureBoxImage(this.PbBasicImage);
      this.TbBasicImage.Clear();
    }
  }
  private bool CheckAllParameters()
  {
    var cnt = 0; 
    this.LbPassword.ForeColor = TEXT_COLOR_FALSE; 
    this.LbBasicImage.ForeColor = TEXT_COLOR_FALSE;

    if (this.RbImageDecryption.Checked)
    {
      if (this.PbBasicImage.Image != null && !string.IsNullOrEmpty(this.TbBasicImage.Text))
      { this.LbBasicImage.ForeColor = TEXT_COLOR; cnt++; } 
    }
    else
    {
      if (this.PbBasicImage.Image != null && !string.IsNullOrEmpty(this.TbBasicImage.Text))
      { this.LbBasicImage.ForeColor = TEXT_COLOR; cnt++; } 
    }

    if (!string.IsNullOrEmpty(this.TbPassword.Text) && this.TbPassword.Text.Length >= HIDE_TEXT_MIN_LENGTH)
    { this.LbPassword.ForeColor = TEXT_COLOR; cnt++; }

    return cnt == 2;
  }

  private void SetNewImage(Panel button)
  {
    this.BtDecryption.Enabled = true;
    if (button is not null)
    {
      button.Enabled = false;

      var filenamepath = string.Empty;
      var img = this.OFD(ref filenamepath);
      if (this.BtBasicImage == button)
      {
        this.FileNamePath = filenamepath;
        var c = Steganography.CheckImageHeader(this.FileNamePath);
        this.SetTextImageOption(c);
        if (this.PbBasicImage.Image is not null)
          this.ResetPictureBoxImage(this.PbBasicImage);
        if (this.PbHideImage.Image is not null)
          this.ResetPictureBoxImage(this.PbHideImage);
        this.TbHideImage.Clear();
        this.PbBasicImage.Image = img;
        this.TbBasicImage.Text = filenamepath;
      } 
      button.Enabled = true;
    }
  }

  private void SetTextImageOption(char signchar)
  {
    //RbTextDecryption bzw. RbImageDecryption
    //müssen gesetzt sein.
    if (signchar != 'T' && signchar != 'I')
      return;
    this.TbHideImage.Clear();
    this.ResetPictureBoxImage(this.PbHideImage);
    this.RbTextDecryption.Checked = false;
    this.RbImageDecryption.Checked = false;
    this.BtSave.Enabled = false;
    if (signchar == 'T')
    {
      this.TlpText.Enabled = true;
      this.TlpHideImage.Enabled = false;
      this.RbTextDecryption.Checked = true;
    }
    else if (signchar == 'I')
    {
      this.TlpText.Enabled = false;
      this.TlpHideImage.Enabled = true;
      this.RbImageDecryption.Checked = true;
    }
  }

  private static StegoInfo ToStegoInfoTxt(
    string basicfilename, string hidetext, string password)
  {
    var result = new StegoInfo
    {
      HideText = Encoding.UTF8.GetBytes(hidetext),
      Password = Encoding.UTF8.GetBytes(password), 
      StegoImagePath = basicfilename,
      ImageExtention = Path.GetExtension(basicfilename)
    };
    return result;
  }

  private static StegoInfo ToStegoInfoImg(string basicfilename, string hidefilename, string password)
  {
    var result = new StegoInfo
    {
      HideImagePath = hidefilename, 
      StegoImagePath = basicfilename,
      Password = Encoding.UTF8.GetBytes(password),
      ImageExtention = Path.GetExtension(basicfilename)
    };
    return result;
  }

  private void ResetAllControls()
  {
    this.ResetPictureBoxImage(this.PbHideImage);
    this.ResetPictureBoxImage(this.PbBasicImage);
    this.TbBasicImage.Clear();
    this.TbHideImage.Clear();
    this.TbPassword.Clear();
    this.TbHideText.Clear();
  }

  private Image? OFD(ref string filenamepath)
  {
    filenamepath = string.Empty;
    this.OfdDecryption.InitialDirectory =
      Path.GetDirectoryName(Application.ExecutablePath);
    this.OfdDecryption.Filter =
      "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
    this.OfdDecryption.FilterIndex = 1;
    this.OfdDecryption.RestoreDirectory = true;
    if (this.OfdDecryption.ShowDialog() == DialogResult.OK)
    {
      //Grundlegender Stream darf zurückgesetzt werden,
      //da eine copy gemacht wird.
      using var mystream = this.OfdDecryption.OpenFile();
      if (mystream is not null)
      {
        filenamepath = this.OfdDecryption.FileName;
        var img = Image.FromStream(mystream);
        if (img is not null)
          return ImageConverting.Copy(img);
      }
    }
    return null;
  }

  private void SFD()
  {
    if (this.RbImageDecryption.Checked)
    {
      this.SFDImage();
      return;
    }
    this.BtSave.Enabled = false;
    MessageBox.Show("Only for ImageDecryption!", "INFO");
  }

  private void SFDImage()
  {
    //- PbHideImage.Image darf nicht null sein.
    //- Decryption muss vorgängig gemacht worden sein.
    this.SfdDecryption.Filter =
      "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
    this.SfdDecryption.FilterIndex = 2;
    this.SfdDecryption.RestoreDirectory = true;

    if (this.SfdDecryption.ShowDialog() == DialogResult.OK)
    {
      string ext = Path.GetExtension(this.SfdDecryption.FileName);
      ext = ext is null || ext == string.Empty ? ".png" : ext;
      var format = ImageConverting.ToImageFormat(ext);
      var img = this.PbHideImage.Image;
      ImageConverting.SaveImage(img, this.SfdDecryption.FileName, format);
      this.TbHideImage.Text = this.SfdDecryption.FileName;
    }
    this.BtSave.Enabled = false;
    this.BtDecryption.Enabled = true;
  }

  private void ResetPictureBoxImage(PictureBox pb)
  {
    if (pb is null) return;
    if (pb.Image is null) return;
    pb.Image.Dispose();
    if (pb == this.PbHideImage) this.PbHideImage.Image = null;
    if (pb == this.PbBasicImage) this.PbBasicImage.Image = null;
    pb.InitialImage = null;
    pb.Update();
  }

}
