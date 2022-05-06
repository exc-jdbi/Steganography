
namespace exc.jdbi.Stegographie.Forms.App;

partial class FrmMain
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
      this.TlpMainLogo = new System.Windows.Forms.TableLayoutPanel();
      this.PbMainLogo = new System.Windows.Forms.PictureBox();
      this.LbMainLogo = new System.Windows.Forms.Label();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.BtEncryption = new System.Windows.Forms.Button();
      this.BtDecryption = new System.Windows.Forms.Button();
      this.LbDragDrop = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.ScMain)).BeginInit();
      this.ScMain.Panel1.SuspendLayout();
      this.ScMain.Panel2.SuspendLayout();
      this.ScMain.SuspendLayout();
      this.TlpMainLogo.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PbMainLogo)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
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
      this.ScMain.Panel1.Controls.Add(this.TlpMainLogo);
      // 
      // ScMain.Panel2
      // 
      this.ScMain.Panel2.Controls.Add(this.tableLayoutPanel1);
      this.ScMain.Size = new System.Drawing.Size(509, 331);
      this.ScMain.SplitterDistance = 80;
      this.ScMain.SplitterWidth = 5;
      this.ScMain.TabIndex = 0;
      this.ScMain.TabStop = false;
      // 
      // TlpMainLogo
      // 
      this.TlpMainLogo.BackColor = System.Drawing.Color.Black;
      this.TlpMainLogo.ColumnCount = 3;
      this.TlpMainLogo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.TlpMainLogo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TlpMainLogo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
      this.TlpMainLogo.Controls.Add(this.PbMainLogo, 0, 0);
      this.TlpMainLogo.Controls.Add(this.LbMainLogo, 2, 0);
      this.TlpMainLogo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TlpMainLogo.Location = new System.Drawing.Point(0, 0);
      this.TlpMainLogo.Name = "TlpMainLogo";
      this.TlpMainLogo.RowCount = 1;
      this.TlpMainLogo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.TlpMainLogo.Size = new System.Drawing.Size(509, 80);
      this.TlpMainLogo.TabIndex = 100;
      // 
      // PbMainLogo
      // 
      this.PbMainLogo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PbMainLogo.Image = global::AppSteganography.Properties.Resources.stegologo;
      this.PbMainLogo.Location = new System.Drawing.Point(3, 3);
      this.PbMainLogo.Name = "PbMainLogo";
      this.PbMainLogo.Size = new System.Drawing.Size(94, 74);
      this.PbMainLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.PbMainLogo.TabIndex = 0;
      this.PbMainLogo.TabStop = false;
      // 
      // LbMainLogo
      // 
      this.LbMainLogo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LbMainLogo.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.LbMainLogo.ForeColor = System.Drawing.Color.White;
      this.LbMainLogo.Location = new System.Drawing.Point(212, 0);
      this.LbMainLogo.Name = "LbMainLogo";
      this.LbMainLogo.Size = new System.Drawing.Size(294, 80);
      this.LbMainLogo.TabIndex = 101;
      this.LbMainLogo.Text = "Steganography";
      this.LbMainLogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.BtEncryption, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.BtDecryption, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.LbDragDrop, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.01626F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.98374F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 246);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // BtEncryption
      // 
      this.BtEncryption.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.BtEncryption.Location = new System.Drawing.Point(55, 200);
      this.BtEncryption.Name = "BtEncryption";
      this.BtEncryption.Size = new System.Drawing.Size(144, 33);
      this.BtEncryption.TabIndex = 1;
      this.BtEncryption.Text = "Encryption";
      this.BtEncryption.UseVisualStyleBackColor = true;
      this.BtEncryption.Click += new System.EventHandler(this.BtEncryption_Click);
      // 
      // BtDecryption
      // 
      this.BtDecryption.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.BtDecryption.Location = new System.Drawing.Point(309, 200);
      this.BtDecryption.Name = "BtDecryption";
      this.BtDecryption.Size = new System.Drawing.Size(144, 33);
      this.BtDecryption.TabIndex = 2;
      this.BtDecryption.Text = "Decryption";
      this.BtDecryption.UseVisualStyleBackColor = true;
      this.BtDecryption.Click += new System.EventHandler(this.BtDecryption_Click);
      // 
      // LbDragDrop
      // 
      this.LbDragDrop.AllowDrop = true;
      this.tableLayoutPanel1.SetColumnSpan(this.LbDragDrop, 2);
      this.LbDragDrop.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LbDragDrop.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.LbDragDrop.ForeColor = System.Drawing.Color.Silver;
      this.LbDragDrop.Location = new System.Drawing.Point(3, 0);
      this.LbDragDrop.Name = "LbDragDrop";
      this.LbDragDrop.Size = new System.Drawing.Size(503, 187);
      this.LbDragDrop.TabIndex = 3;
      this.LbDragDrop.Text = "Drag and Drop\r\n\r\nBasic Image";
      this.LbDragDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.LbDragDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.LbDragDrop_DragDrop);
      this.LbDragDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.LbDragDrop_DragEnter);
      this.LbDragDrop.DragLeave += new System.EventHandler(this.LbDragDrop_DragLeave);
      // 
      // FrmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(509, 331);
      this.Controls.Add(this.ScMain);
      this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.MinimumSize = new System.Drawing.Size(420, 370);
      this.Name = "FrmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "© Steganography 2022 created by © exc-jdbi 2022";
      this.ScMain.Panel1.ResumeLayout(false);
      this.ScMain.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ScMain)).EndInit();
      this.ScMain.ResumeLayout(false);
      this.TlpMainLogo.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.PbMainLogo)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

  }

  #endregion

  private SplitContainer ScMain;
  private TableLayoutPanel TlpMainLogo;
  private PictureBox PbMainLogo;
  private Label LbMainLogo;
  private TableLayoutPanel tableLayoutPanel1;
  private Button BtEncryption;
  private Button BtDecryption;
  private Label LbDragDrop;
}
