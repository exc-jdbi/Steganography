
namespace exc.jdbi.Stegographie.Forms;

partial class FrmStegoDecryption
{
  /// <summary>
  /// Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  /// Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing)
  {
    if (disposing && (components != null))
    {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  /// <summary>
  /// Required method for Designer support - do not modify
  /// the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent()
  {
      this.ScMain = new System.Windows.Forms.SplitContainer();
      this.TplLogo = new System.Windows.Forms.TableLayoutPanel();
      this.PbLogo = new System.Windows.Forms.PictureBox();
      this.LbLogo = new System.Windows.Forms.Label();
      this.TlpMain = new System.Windows.Forms.TableLayoutPanel();
      this.GbOption = new System.Windows.Forms.GroupBox();
      this.TlpOption = new System.Windows.Forms.TableLayoutPanel();
      this.RbImageDecryption = new System.Windows.Forms.RadioButton();
      this.RbTextDecryption = new System.Windows.Forms.RadioButton();
      this.TlpText = new System.Windows.Forms.TableLayoutPanel();
      this.TbHideText = new System.Windows.Forms.TextBox();
      this.LbHideText = new System.Windows.Forms.Label();
      this.TlpPassword = new System.Windows.Forms.TableLayoutPanel();
      this.TbPassword = new System.Windows.Forms.TextBox();
      this.LbPassword = new System.Windows.Forms.Label();
      this.TlpBasicImage = new System.Windows.Forms.TableLayoutPanel();
      this.TbBasicImage = new System.Windows.Forms.TextBox();
      this.LbBasicImage = new System.Windows.Forms.Label();
      this.PbBasicImage = new System.Windows.Forms.PictureBox();
      this.BtBasicImage = new System.Windows.Forms.Panel();
      this.TlpHideImage = new System.Windows.Forms.TableLayoutPanel();
      this.TbHideImage = new System.Windows.Forms.TextBox();
      this.LbHideImage = new System.Windows.Forms.Label();
      this.PbHideImage = new System.Windows.Forms.PictureBox();
      this.TlpButtons = new System.Windows.Forms.TableLayoutPanel();
      this.BtDecryption = new System.Windows.Forms.Button();
      this.BtSave = new System.Windows.Forms.Button();
      this.BtClose = new System.Windows.Forms.Button();
      this.OfdDecryption = new System.Windows.Forms.OpenFileDialog();
      this.SfdDecryption = new System.Windows.Forms.SaveFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.ScMain)).BeginInit();
      this.ScMain.Panel1.SuspendLayout();
      this.ScMain.Panel2.SuspendLayout();
      this.ScMain.SuspendLayout();
      this.TplLogo.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
      this.TlpMain.SuspendLayout();
      this.GbOption.SuspendLayout();
      this.TlpOption.SuspendLayout();
      this.TlpText.SuspendLayout();
      this.TlpPassword.SuspendLayout();
      this.TlpBasicImage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PbBasicImage)).BeginInit();
      this.TlpHideImage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PbHideImage)).BeginInit();
      this.TlpButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // ScMain
      // 
      this.ScMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ScMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.ScMain.IsSplitterFixed = true;
      this.ScMain.Location = new System.Drawing.Point(0, 0);
      this.ScMain.Margin = new System.Windows.Forms.Padding(4);
      this.ScMain.Name = "ScMain";
      this.ScMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // ScMain.Panel1
      // 
      this.ScMain.Panel1.Controls.Add(this.TplLogo);
      // 
      // ScMain.Panel2
      // 
      this.ScMain.Panel2.Controls.Add(this.TlpMain);
      this.ScMain.Size = new System.Drawing.Size(884, 761);
      this.ScMain.SplitterDistance = 80;
      this.ScMain.SplitterWidth = 5;
      this.ScMain.TabIndex = 0;
      // 
      // TplLogo
      // 
      this.TplLogo.BackColor = System.Drawing.Color.Black;
      this.TplLogo.ColumnCount = 3;
      this.TplLogo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.TplLogo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TplLogo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 450F));
      this.TplLogo.Controls.Add(this.PbLogo, 0, 0);
      this.TplLogo.Controls.Add(this.LbLogo, 2, 0);
      this.TplLogo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TplLogo.Location = new System.Drawing.Point(0, 0);
      this.TplLogo.Name = "TplLogo";
      this.TplLogo.RowCount = 1;
      this.TplLogo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TplLogo.Size = new System.Drawing.Size(884, 80);
      this.TplLogo.TabIndex = 100;
      // 
      // PbLogo
      // 
      this.PbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PbLogo.Image = global::AppSteganography.Properties.Resources.stegodec;
      this.PbLogo.Location = new System.Drawing.Point(3, 3);
      this.PbLogo.Name = "PbLogo";
      this.PbLogo.Size = new System.Drawing.Size(94, 74);
      this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.PbLogo.TabIndex = 0;
      this.PbLogo.TabStop = false;
      // 
      // LbLogo
      // 
      this.LbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LbLogo.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.LbLogo.ForeColor = System.Drawing.Color.White;
      this.LbLogo.Location = new System.Drawing.Point(437, 0);
      this.LbLogo.Name = "LbLogo";
      this.LbLogo.Size = new System.Drawing.Size(444, 80);
      this.LbLogo.TabIndex = 101;
      this.LbLogo.Text = "Steganography Decryption";
      this.LbLogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // TlpMain
      // 
      this.TlpMain.ColumnCount = 2;
      this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TlpMain.Controls.Add(this.GbOption, 0, 1);
      this.TlpMain.Controls.Add(this.TlpText, 0, 2);
      this.TlpMain.Controls.Add(this.TlpPassword, 0, 3);
      this.TlpMain.Controls.Add(this.TlpBasicImage, 0, 0);
      this.TlpMain.Controls.Add(this.TlpHideImage, 1, 0);
      this.TlpMain.Controls.Add(this.TlpButtons, 0, 4);
      this.TlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TlpMain.Location = new System.Drawing.Point(0, 0);
      this.TlpMain.Name = "TlpMain";
      this.TlpMain.RowCount = 5;
      this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
      this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
      this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
      this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
      this.TlpMain.Size = new System.Drawing.Size(884, 676);
      this.TlpMain.TabIndex = 1;
      this.TlpMain.TabStop = true;
      // 
      // GbOption
      // 
      this.TlpMain.SetColumnSpan(this.GbOption, 2);
      this.GbOption.Controls.Add(this.TlpOption);
      this.GbOption.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GbOption.Enabled = false;
      this.GbOption.Location = new System.Drawing.Point(10, 297);
      this.GbOption.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
      this.GbOption.Name = "GbOption";
      this.GbOption.Size = new System.Drawing.Size(864, 61);
      this.GbOption.TabIndex = 8;
      this.GbOption.TabStop = false;
      this.GbOption.Text = "Option";
      // 
      // TlpOption
      // 
      this.TlpOption.ColumnCount = 2;
      this.TlpOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TlpOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TlpOption.Controls.Add(this.RbImageDecryption, 0, 0);
      this.TlpOption.Controls.Add(this.RbTextDecryption, 1, 0);
      this.TlpOption.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TlpOption.Location = new System.Drawing.Point(3, 22);
      this.TlpOption.Name = "TlpOption";
      this.TlpOption.RowCount = 1;
      this.TlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TlpOption.Size = new System.Drawing.Size(858, 36);
      this.TlpOption.TabIndex = 9;
      this.TlpOption.TabStop = true;
      // 
      // RbImageDecryption
      // 
      this.RbImageDecryption.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.RbImageDecryption.AutoSize = true;
      this.RbImageDecryption.Location = new System.Drawing.Point(140, 7);
      this.RbImageDecryption.Name = "RbImageDecryption";
      this.RbImageDecryption.Size = new System.Drawing.Size(148, 22);
      this.RbImageDecryption.TabIndex = 10;
      this.RbImageDecryption.TabStop = true;
      this.RbImageDecryption.Text = "Image Decryption";
      this.RbImageDecryption.UseVisualStyleBackColor = true;
      // 
      // RbTextDecryption
      // 
      this.RbTextDecryption.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.RbTextDecryption.AutoSize = true;
      this.RbTextDecryption.Checked = true;
      this.RbTextDecryption.Location = new System.Drawing.Point(577, 7);
      this.RbTextDecryption.Name = "RbTextDecryption";
      this.RbTextDecryption.Size = new System.Drawing.Size(132, 22);
      this.RbTextDecryption.TabIndex = 11;
      this.RbTextDecryption.TabStop = true;
      this.RbTextDecryption.Text = "Text Decryption";
      this.RbTextDecryption.UseVisualStyleBackColor = true;
      // 
      // TlpText
      // 
      this.TlpText.ColumnCount = 2;
      this.TlpMain.SetColumnSpan(this.TlpText, 2);
      this.TlpText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TlpText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TlpText.Controls.Add(this.TbHideText, 0, 1);
      this.TlpText.Controls.Add(this.LbHideText, 0, 0);
      this.TlpText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TlpText.Location = new System.Drawing.Point(3, 364);
      this.TlpText.Name = "TlpText";
      this.TlpText.RowCount = 2;
      this.TlpText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.TlpText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TlpText.Size = new System.Drawing.Size(878, 194);
      this.TlpText.TabIndex = 12;
      this.TlpText.TabStop = true;
      // 
      // TbHideText
      // 
      this.TlpText.SetColumnSpan(this.TbHideText, 2);
      this.TbHideText.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TbHideText.Location = new System.Drawing.Point(10, 35);
      this.TbHideText.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
      this.TbHideText.Multiline = true;
      this.TbHideText.Name = "TbHideText";
      this.TbHideText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.TbHideText.Size = new System.Drawing.Size(858, 156);
      this.TbHideText.TabIndex = 13;
      // 
      // LbHideText
      // 
      this.LbHideText.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.TlpText.SetColumnSpan(this.LbHideText, 2);
      this.LbHideText.Location = new System.Drawing.Point(331, 0);
      this.LbHideText.Name = "LbHideText";
      this.LbHideText.Size = new System.Drawing.Size(216, 32);
      this.LbHideText.TabIndex = 100;
      this.LbHideText.Text = "Hide Text";
      this.LbHideText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // TlpPassword
      // 
      this.TlpPassword.ColumnCount = 2;
      this.TlpMain.SetColumnSpan(this.TlpPassword, 2);
      this.TlpPassword.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TlpPassword.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.TlpPassword.Controls.Add(this.TbPassword, 0, 1);
      this.TlpPassword.Controls.Add(this.LbPassword, 0, 0);
      this.TlpPassword.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TlpPassword.Location = new System.Drawing.Point(3, 564);
      this.TlpPassword.Name = "TlpPassword";
      this.TlpPassword.RowCount = 2;
      this.TlpPassword.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
      this.TlpPassword.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
      this.TlpPassword.Size = new System.Drawing.Size(878, 66);
      this.TlpPassword.TabIndex = 14;
      this.TlpPassword.TabStop = true;
      // 
      // TbPassword
      // 
      this.TbPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.TlpPassword.SetColumnSpan(this.TbPassword, 2);
      this.TbPassword.Location = new System.Drawing.Point(264, 33);
      this.TbPassword.MaxLength = 128;
      this.TbPassword.Name = "TbPassword";
      this.TbPassword.PasswordChar = '*';
      this.TbPassword.Size = new System.Drawing.Size(350, 26);
      this.TbPassword.TabIndex = 15;
      this.TbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.TbPassword.UseSystemPasswordChar = true;
      // 
      // LbPassword
      // 
      this.LbPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.TlpPassword.SetColumnSpan(this.LbPassword, 2);
      this.LbPassword.Location = new System.Drawing.Point(331, 0);
      this.LbPassword.Name = "LbPassword";
      this.LbPassword.Size = new System.Drawing.Size(216, 26);
      this.LbPassword.TabIndex = 100;
      this.LbPassword.Text = "Password";
      this.LbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // TlpBasicImage
      // 
      this.TlpBasicImage.ColumnCount = 2;
      this.TlpBasicImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TlpBasicImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
      this.TlpBasicImage.Controls.Add(this.TbBasicImage, 0, 2);
      this.TlpBasicImage.Controls.Add(this.LbBasicImage, 0, 0);
      this.TlpBasicImage.Controls.Add(this.PbBasicImage, 0, 1);
      this.TlpBasicImage.Controls.Add(this.BtBasicImage, 1, 2);
      this.TlpBasicImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TlpBasicImage.Location = new System.Drawing.Point(10, 3);
      this.TlpBasicImage.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
      this.TlpBasicImage.Name = "TlpBasicImage";
      this.TlpBasicImage.RowCount = 3;
      this.TlpBasicImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
      this.TlpBasicImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TlpBasicImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
      this.TlpBasicImage.Size = new System.Drawing.Size(429, 288);
      this.TlpBasicImage.TabIndex = 2;
      this.TlpBasicImage.TabStop = true;
      // 
      // TbBasicImage
      // 
      this.TbBasicImage.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.TbBasicImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.TbBasicImage.Location = new System.Drawing.Point(5, 254);
      this.TbBasicImage.Name = "TbBasicImage";
      this.TbBasicImage.Size = new System.Drawing.Size(373, 26);
      this.TbBasicImage.TabIndex = 3;
      // 
      // LbBasicImage
      // 
      this.TlpBasicImage.SetColumnSpan(this.LbBasicImage, 2);
      this.LbBasicImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LbBasicImage.Location = new System.Drawing.Point(3, 0);
      this.LbBasicImage.Name = "LbBasicImage";
      this.LbBasicImage.Size = new System.Drawing.Size(423, 28);
      this.LbBasicImage.TabIndex = 100;
      this.LbBasicImage.Text = "Basic Image";
      this.LbBasicImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // PbBasicImage
      // 
      this.PbBasicImage.AllowDrop = true;
      this.PbBasicImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TlpBasicImage.SetColumnSpan(this.PbBasicImage, 2);
      this.PbBasicImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PbBasicImage.Location = new System.Drawing.Point(3, 31);
      this.PbBasicImage.Name = "PbBasicImage";
      this.PbBasicImage.Size = new System.Drawing.Size(423, 212);
      this.PbBasicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.PbBasicImage.TabIndex = 3;
      this.PbBasicImage.TabStop = false;
      this.PbBasicImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragDrop);
      this.PbBasicImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragEnter);
      this.PbBasicImage.DragLeave += new System.EventHandler(this.PictureBox_DragLeave);
      // 
      // BtBasicImage
      // 
      this.BtBasicImage.BackgroundImage = global::AppSteganography.Properties.Resources.eyepic;
      this.BtBasicImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.BtBasicImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.BtBasicImage.Location = new System.Drawing.Point(387, 249);
      this.BtBasicImage.Name = "BtBasicImage";
      this.BtBasicImage.Size = new System.Drawing.Size(39, 36);
      this.BtBasicImage.TabIndex = 4;
      this.BtBasicImage.TabStop = true;
      this.BtBasicImage.Click += new System.EventHandler(this.Button_Click);
      // 
      // TlpHideImage
      // 
      this.TlpHideImage.ColumnCount = 2;
      this.TlpHideImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TlpHideImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
      this.TlpHideImage.Controls.Add(this.TbHideImage, 0, 2);
      this.TlpHideImage.Controls.Add(this.LbHideImage, 0, 0);
      this.TlpHideImage.Controls.Add(this.PbHideImage, 0, 1);
      this.TlpHideImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TlpHideImage.Enabled = false;
      this.TlpHideImage.Location = new System.Drawing.Point(445, 3);
      this.TlpHideImage.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
      this.TlpHideImage.Name = "TlpHideImage";
      this.TlpHideImage.RowCount = 3;
      this.TlpHideImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
      this.TlpHideImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TlpHideImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
      this.TlpHideImage.Size = new System.Drawing.Size(429, 288);
      this.TlpHideImage.TabIndex = 5;
      this.TlpHideImage.TabStop = true;
      // 
      // TbHideImage
      // 
      this.TbHideImage.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.TlpHideImage.SetColumnSpan(this.TbHideImage, 2);
      this.TbHideImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.TbHideImage.Location = new System.Drawing.Point(3, 254);
      this.TbHideImage.Name = "TbHideImage";
      this.TbHideImage.Size = new System.Drawing.Size(423, 26);
      this.TbHideImage.TabIndex = 6;
      // 
      // LbHideImage
      // 
      this.TlpHideImage.SetColumnSpan(this.LbHideImage, 2);
      this.LbHideImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LbHideImage.Location = new System.Drawing.Point(3, 0);
      this.LbHideImage.Name = "LbHideImage";
      this.LbHideImage.Size = new System.Drawing.Size(423, 28);
      this.LbHideImage.TabIndex = 100;
      this.LbHideImage.Text = "Hide Image";
      this.LbHideImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // PbHideImage
      // 
      this.PbHideImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TlpHideImage.SetColumnSpan(this.PbHideImage, 2);
      this.PbHideImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PbHideImage.Location = new System.Drawing.Point(3, 31);
      this.PbHideImage.Name = "PbHideImage";
      this.PbHideImage.Size = new System.Drawing.Size(423, 212);
      this.PbHideImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.PbHideImage.TabIndex = 3;
      this.PbHideImage.TabStop = false;
      // 
      // TlpButtons
      // 
      this.TlpButtons.ColumnCount = 3;
      this.TlpMain.SetColumnSpan(this.TlpButtons, 2);
      this.TlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.TlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
      this.TlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
      this.TlpButtons.Controls.Add(this.BtDecryption, 0, 0);
      this.TlpButtons.Controls.Add(this.BtSave, 1, 0);
      this.TlpButtons.Controls.Add(this.BtClose, 2, 0);
      this.TlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TlpButtons.Location = new System.Drawing.Point(3, 636);
      this.TlpButtons.Name = "TlpButtons";
      this.TlpButtons.RowCount = 1;
      this.TlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TlpButtons.Size = new System.Drawing.Size(878, 37);
      this.TlpButtons.TabIndex = 16;
      this.TlpButtons.TabStop = true;
      // 
      // BtDecryption
      // 
      this.BtDecryption.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.BtDecryption.Location = new System.Drawing.Point(10, 3);
      this.BtDecryption.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
      this.BtDecryption.Name = "BtDecryption";
      this.BtDecryption.Size = new System.Drawing.Size(191, 31);
      this.BtDecryption.TabIndex = 17;
      this.BtDecryption.Text = "Decryption";
      this.BtDecryption.UseVisualStyleBackColor = true;
      this.BtDecryption.Click += new System.EventHandler(this.Button_Click);
      // 
      // BtSave
      // 
      this.BtSave.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.BtSave.Location = new System.Drawing.Point(342, 3);
      this.BtSave.Name = "BtSave";
      this.BtSave.Size = new System.Drawing.Size(191, 31);
      this.BtSave.TabIndex = 18;
      this.BtSave.Text = "Save Hide Image";
      this.BtSave.UseVisualStyleBackColor = true;
      this.BtSave.Click += new System.EventHandler(this.Button_Click);
      // 
      // BtClose
      // 
      this.BtClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.BtClose.Location = new System.Drawing.Point(677, 3);
      this.BtClose.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
      this.BtClose.Name = "BtClose";
      this.BtClose.Size = new System.Drawing.Size(191, 31);
      this.BtClose.TabIndex = 19;
      this.BtClose.Text = "Close";
      this.BtClose.UseVisualStyleBackColor = true;
      this.BtClose.Click += new System.EventHandler(this.Button_Click);
      // 
      // OfdDecryption
      // 
      this.OfdDecryption.FileName = "openFileDialog1";
      // 
      // FrmStegoDecryption
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(884, 761);
      this.Controls.Add(this.ScMain);
      this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.MaximumSize = new System.Drawing.Size(900, 800);
      this.MinimumSize = new System.Drawing.Size(900, 800);
      this.Name = "FrmStegoDecryption";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "© Steganography 2022 created by © exc-jdbi 2022";
      this.ScMain.Panel1.ResumeLayout(false);
      this.ScMain.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ScMain)).EndInit();
      this.ScMain.ResumeLayout(false);
      this.TplLogo.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
      this.TlpMain.ResumeLayout(false);
      this.GbOption.ResumeLayout(false);
      this.TlpOption.ResumeLayout(false);
      this.TlpOption.PerformLayout();
      this.TlpText.ResumeLayout(false);
      this.TlpText.PerformLayout();
      this.TlpPassword.ResumeLayout(false);
      this.TlpPassword.PerformLayout();
      this.TlpBasicImage.ResumeLayout(false);
      this.TlpBasicImage.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PbBasicImage)).EndInit();
      this.TlpHideImage.ResumeLayout(false);
      this.TlpHideImage.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PbHideImage)).EndInit();
      this.TlpButtons.ResumeLayout(false);
      this.ResumeLayout(false);

  }

  #endregion

  private SplitContainer ScMain;
  private TableLayoutPanel TplLogo;
  private PictureBox PbLogo;
  private Label LbLogo;
  private TableLayoutPanel TlpMain;
  private GroupBox GbOption;
  private TableLayoutPanel TlpOption;
  private RadioButton RbImageDecryption;
  private RadioButton RbTextDecryption;
  private TableLayoutPanel TlpText;
  private TextBox TbHideText;
  private Label LbHideText;
  private TableLayoutPanel TlpPassword;
  private TextBox TbPassword;
  private Label LbPassword;
  private TableLayoutPanel TlpBasicImage;
  private TextBox TbBasicImage;
  private Label LbBasicImage;
  private Panel BtBasicImage;
  private TableLayoutPanel TlpHideImage;
  private TextBox TbHideImage;
  private Label LbHideImage;
  private PictureBox PbHideImage;
  private TableLayoutPanel TlpButtons;
  private Button BtDecryption;
  private Button BtSave;
  private Button BtClose;
  internal PictureBox PbBasicImage;
  private OpenFileDialog OfdDecryption;
  private SaveFileDialog SfdDecryption;
}
