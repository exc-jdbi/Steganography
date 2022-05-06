
using System.Text;

namespace exc.jdbi.Stegographie.Forms;

using exc.jdbi.Steganographie;
using exc.jdbi.ImageConvertings;
using static exc.jdbi.Steganographie.StegoCalculation;

internal partial class FrmStegoEncryption : Form
{
  private bool IsVaildDragDrop = false;
  internal string FileNamePath = string.Empty;

  private const int HIDE_TEXT_MIN_LENGTH = 10;
  private static readonly Color TEXT_COLOR_FALSE = Color.Red;
  private static readonly Color TEXT_COLOR = SystemColors.ControlText;

  //Storage Capacities Calculation Varify
  private static readonly Color STEGO_L1_SCV = Color.LimeGreen;
  private static readonly Color STEGO_Rest_SCV = Color.AntiqueWhite;
  private static readonly Color STEGO_L2_SCV = Color.LightGoldenrodYellow;

  private FrmStegoEncryption()
  {
    this.InitializeComponent(); 
  }

  public FrmStegoEncryption(string? basicimgpath) : this()
  {
    if (File.Exists(basicimgpath))
    {
      this.TbBasicImage.Text = basicimgpath is not null ? basicimgpath : string.Empty;
      this.PbBasicImage.Image = ImageConverting.LoadImage(this.TbBasicImage.Text);
    }
  }

  private void Button_Click(object sender, EventArgs e)
  {
    switch (sender)
    {
      case var obj when ReferenceEquals(this.BtBasicImage, obj): this.SetNewImage(this.BtBasicImage); break;
      case var obj when ReferenceEquals(this.BtHideImage, obj): this.SetNewImage(this.BtHideImage); break;
      case var obj when ReferenceEquals(this.BtSave, obj): this.SFD(); break;
      case var obj when ReferenceEquals(this.BtEncryption, obj): this.Encryption(); break;
      case var obj when ReferenceEquals(this.BtClose, obj): this.Close(); break;
    }
  }

  private void RadioButton_Click(object sender, EventArgs e)
  {
    this.ResetPictureBoxImage(this.PbHideImage);
    this.TbHideImage.Clear();
    if (this.RbTextEncryption.Checked)
    {
      this.TlpHideImage.Enabled = false;
      this.TlpText.Enabled = true;
      this.RbImageEncryption.Checked = false;
    }
    else
    {
      this.TlpHideImage.Enabled = true;
      this.TlpText.Enabled = false;
      this.RbTextEncryption.Checked = false;
      this.RbImageEncryption.Checked = true;
    }
  }

  private void PictureBox_DragDrop(object sender, DragEventArgs e)
  {
    if (e.Data is null) return;
    if (this.IsVaildDragDrop && this.FileNamePath is not null)
    {
      if (this.PbBasicImage == sender)
      {
        var c = Steganography.CheckImageHeader(this.FileNamePath);
        if (c == char.MinValue)
        {
          if(this.PbHideImage.Image is not null)
            this.ResetPictureBoxImage(this.PbHideImage);
          this.TbHideImage.Clear();
          this.ResetPictureBoxImage(this.PbBasicImage);
          this.TbBasicImage.Text = this.FileNamePath is not null ? this.FileNamePath : string.Empty;
          this.PbBasicImage.Image = ImageConverting.LoadImage(this.TbBasicImage.Text);
          this.StorageVerifyCalculation();
          return;
        }
        MessageBox.Show("Image is already crypted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        if (this.PbBasicImage.Image is not null) this.ResetPictureBoxImage(this.PbBasicImage);
        this.TbBasicImage.Clear();
      }
      if (this.PbHideImage == sender)
      {
        this.ResetPictureBoxImage(this.PbHideImage);
        this.TbHideImage.Text = this.FileNamePath is not null ? this.FileNamePath : string.Empty;
        this.PbHideImage.Image = ImageConverting.LoadImage(this.TbHideImage.Text);
      }
      this.StorageVerifyCalculation();
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

  private void TbHideText_Leave(object sender, EventArgs e)
  {
    this.StorageVerifyCalculation();
  }

  internal void ResetAllControls()
  {
    this.ResetPictureBoxImage(this.PbHideImage);
    this.ResetPictureBoxImage(this.PbBasicImage);
    this.TbBasicImage.Clear();
    this.TbHideImage.Clear();
    this.TbPassword.Clear();
    this.TbHideText.Clear();
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

  private void Encryption()
  {
    if (this.CheckAllParameters())
    {
      var c = Steganography.CheckImageHeader(this.TbBasicImage.Text);
      if (c == char.MinValue)
      {
        this.BtEncryption.Enabled = false;
        if (this.RbTextEncryption.Checked)
        {
          var stegoinfo = ToStegoInfoTxt(this.TbBasicImage.Text, this.TbHideText.Text, this.TbPassword.Text);
          this.TbPassword.Clear();
          var img = Steganography.EmbeddingText(stegoinfo);
          this.ResetPictureBoxImage(this.PbBasicImage);
          this.PbBasicImage.Image = null;
          this.PbBasicImage.Image = img;
        }
        if (this.RbImageEncryption.Checked)
        {
          var stegoinfo = ToStegoInfoImg(this.TbBasicImage.Text, this.TbHideImage.Text, this.TbPassword.Text);
          this.TbPassword.Clear();
          var img = Steganography.EmbeddingImage(stegoinfo);
          this.ResetPictureBoxImage(this.PbBasicImage);
          this.PbBasicImage.Image = null;
          this.PbBasicImage.Image = img;
        }
        this.TbBasicImage.Clear();
        this.BtSave.Enabled = true;
        return;
      }
      this.TbPassword.Clear();
      MessageBox.Show("Image is already crypted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      if(this.PbBasicImage.Image is not null)
        this.ResetPictureBoxImage(this.PbBasicImage);
      this.TbBasicImage.Clear();
    }
  }

  private static StegoInfo ToStegoInfoTxt(string basicfilename, string hidetext, string password)
  {
    var result = new StegoInfo
    {
      HideText = Encoding.UTF8.GetBytes(hidetext),
      Password = Encoding.UTF8.GetBytes(password),
      BasicImagePath = basicfilename,
      ImageExtention = Path.GetExtension(basicfilename)
    };
    return result;
  }

  private static StegoInfo ToStegoInfoImg(string basicfilename, string hidefilename, string password)
  {
    var result = new StegoInfo
    {
      HideImagePath = hidefilename,
      BasicImagePath = basicfilename,
      Password = Encoding.UTF8.GetBytes(password),
      ImageExtention = Path.GetExtension(basicfilename)
    };
    return result;
  }

  private void SetNewImage(Panel button)
  {
    if (button is not null)
    {
      button.Enabled = false;

      var filenamepath = string.Empty;
      var img = this.OFD(ref filenamepath);
      if (this.PbHideImage.Image is not null)
        this.ResetPictureBoxImage(this.PbHideImage);
      this.TbHideImage.Clear();

      if (this.BtBasicImage == button)
      {
        if (this.PbBasicImage.Image is not null)
          this.ResetPictureBoxImage(this.PbBasicImage);
        this.PbBasicImage.Image = img;
        this.TbBasicImage.Text = filenamepath;
      }
      if (this.BtHideImage == button)
      { 
        this.PbHideImage.Image = img;
        this.TbHideImage.Text = filenamepath;
      }
      button.Enabled = true;
    }
  }

  private bool CheckAllParameters()
  {
    var cnt = 0;
    this.LbLogo.ForeColor = TEXT_COLOR_FALSE;
    this.LbHideText.ForeColor = TEXT_COLOR_FALSE;
    this.LbPassword.ForeColor = TEXT_COLOR_FALSE;
    this.LbHideImage.ForeColor = TEXT_COLOR_FALSE;
    this.LbBasicImage.ForeColor = TEXT_COLOR_FALSE;

    if (this.RbImageEncryption.Checked)
    {
      if (this.PbBasicImage.Image != null && !string.IsNullOrEmpty(this.TbBasicImage.Text))
      { this.LbBasicImage.ForeColor = TEXT_COLOR; cnt++; }

      if (this.PbHideImage.Image != null && !string.IsNullOrEmpty(this.TbHideImage.Text))
      { this.LbHideImage.ForeColor = TEXT_COLOR; cnt++; }

      this.LbHideText.ForeColor = TEXT_COLOR;
    }
    else
    {
      if (this.PbBasicImage.Image != null && !string.IsNullOrEmpty(this.TbBasicImage.Text))
      { this.LbBasicImage.ForeColor = TEXT_COLOR; cnt++; }

      if (!string.IsNullOrEmpty(this.TbHideText.Text) && this.TbHideText.Text.Length >= HIDE_TEXT_MIN_LENGTH)
      { this.LbHideText.ForeColor = TEXT_COLOR; cnt++; }

      this.LbHideImage.ForeColor = TEXT_COLOR;
    }

    if (!string.IsNullOrEmpty(this.TbPassword.Text) && this.TbPassword.Text.Length >= HIDE_TEXT_MIN_LENGTH)
    { this.LbPassword.ForeColor = TEXT_COLOR; cnt++; }

    var svc = this.StorageVerifyCalculation();
    return cnt == 3 && svc > 0 && svc < 4;
  }

  private int StorageVerifyCalculation()
  {
    int result = 0;
    this.LbLogo.ForeColor = Color.White;
    if (this.RbImageEncryption.Checked)
    if (this.PbBasicImage.Image is not null)
      if (this.PbHideImage.Image is not null)
      {
          var csi = CheckStorageCapacities(
            this.PbBasicImage.Image, this.PbHideImage.Image);
          if (csi.RequiredCapacity <= csi.StorageCapacitiesL1) result = 1;
          else if (csi.RequiredCapacity <= csi.StorageCapacitiesL2) result = 2;
          else if (csi.StorageCapacitiesVarify) result = 3;
          else result = 4;
        }
    if (this.RbTextEncryption.Checked)
      if (this.PbBasicImage.Image is not null)
        if (!string.IsNullOrEmpty(this.TbHideText .Text))
        {
          var csi = CheckStorageCapacities(
            this.PbBasicImage.Image,Encoding.UTF8.GetBytes( this.TbHideText.Text));
          if (csi.RequiredCapacity <= csi.StorageCapacitiesL1) result = 1;
          else if (csi.RequiredCapacity <= csi.StorageCapacitiesL2) result = 2;
          else if (csi.StorageCapacitiesVarify) result = 3;
          else result = 4;
        }
    if (result == 0) return result; 
    if (result == 1) this.LbLogo.ForeColor = STEGO_L1_SCV;
    if (result == 2) this.LbLogo.ForeColor = STEGO_L2_SCV;
    if (result == 3) this.LbLogo.ForeColor = STEGO_Rest_SCV;
    if (result == 4) this.LbLogo.ForeColor = TEXT_COLOR_FALSE;
    return result;
  }

  private Image? OFD(ref string filenamepath)
  {
    filenamepath = string.Empty;
    this.OfdEncryption.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
    this.OfdEncryption.Filter =
      "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
    this.OfdEncryption.FilterIndex = 1;
    this.OfdEncryption.RestoreDirectory = true;
    if (this.OfdEncryption.ShowDialog() == DialogResult.OK)
    {
      //Grundlegender Stream darf zurückgesetzt werden,
      //da eine copy gemacht wird.
      using var mystream = this.OfdEncryption.OpenFile();
      if (mystream is not null)
      {
        filenamepath = this.OfdEncryption.FileName;
        var img = Image.FromStream(mystream);
        if (img is not null)
          return ImageConverting.Copy(img);
      }
    }
    return null;
  }

  private void SFD()
  {
    //- PbBasicImage.Image darf nicht null sein.
    //- Encryption muss vorgängig gemacht worden sein.
    this.SfdEncryption.Filter =
      "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
    this.SfdEncryption.FilterIndex = 2;
    this.SfdEncryption.RestoreDirectory = true;

    if (this.SfdEncryption.ShowDialog() == DialogResult.OK)
    {
      //Muss als '.png' abgespeichert werden.
      //string ext = Path.GetExtension(this.SfdEncryption.FileName);
      var format = ImageConverting.ToImageFormat(".png");
      var filename = this.SfdEncryption.FileName;
      if (Path.GetExtension(filename) != ".png")
        filename = Path.ChangeExtension(filename, ".png");
      var img = this.PbBasicImage.Image;
      ImageConverting.SaveImage(img, filename, format);
      this.TbBasicImage.Text = filename;
    }
    this.BtSave.Enabled = false;
    this.BtEncryption.Enabled = true;
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
