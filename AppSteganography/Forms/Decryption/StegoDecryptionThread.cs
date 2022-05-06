

//namespace exc.jdbi.Threads;
namespace exc.jdbi.Stegographie.Forms.App;
class StegoDecryptionThread : IDisposable
{
#pragma warning disable CS8622 // Die NULL-Zulässigkeit von Verweistypen im Typ des Parameters entspricht (möglicherweise aufgrund von Attributen für die NULL-Zulässigkeit) nicht dem Zieldelegaten.

  internal bool IsDisposed;
  private FrmStegoDecryption? Fsd = null;
  private readonly FrmMain? Parent = null;
  internal string ImageFileNamePath = string.Empty;
  public event EventHandler<EventArgs> Closed = delegate { };

  public StegoDecryptionThread(FrmMain parent, string filename, char signchar = char.MinValue)
  {
    if (parent is not null)
      this.Parent = parent;
    else throw new ArgumentNullException(nameof(parent));

    parent.Hide();
    this.IsDisposed = false;
    this.Fsd = new FrmStegoDecryption(filename, signchar);
    if (this.Fsd is not null)
    {
      //Die FormCosing von FrmStegoEncryption wird hierher verschoben.
      //was die ganze Sache um einiges besser kontrollieren lässt.
      this.Fsd.FormClosing += new FormClosingEventHandler(this.FrmStegoDecryption_FormClosing);
      this.Fsd.TopMost = true;
    }
    var thd = new Thread(this.WorkerThread) { IsBackground = true };
    thd.SetApartmentState(ApartmentState.STA);
    thd.Start();
  }

  private void FrmStegoDecryption_FormClosing(object sender, FormClosingEventArgs e)
  {
    this.IsDisposed = true;
    if (this.Fsd is not null)
    {
      this.Fsd.ResetAllControls();
      this.ImageFileNamePath = string.Empty;
      if (this.Parent is not null)
        this.Parent.FileNamePath = string.Empty;

      //if (Fsd.DialogResult == DialogResult.OK)
      //{
      //  if (!string.IsNullOrEmpty(this.Fsd.FileNamePath))
      //    this.ImageFileNamePath = this.Fsd.FileNamePath;
      //  if (this.Parent is not null)
      //    this.Parent.FileNamePath = this.ImageFileNamePath; 
      //}
    }

    if (this.Parent is not null)
      this.Parent.Invoke(this.ParentShow);

    this.Closed(this, EventArgs.Empty);
  }

  public void Dispose()
  {
    if (!this.IsDisposed && this.Fsd is not null)
    {
      this.Fsd.Invoke(new MethodInvoker(this.StopThread));
      this.IsDisposed = true;
    }
  }

  private void StopThread()
  {
    if (this.Fsd is not null)
      this.Fsd.Close();
  }

  private void WorkerThread()
  {
    Application.Run(this.Fsd);
    if (this.Fsd is not null) this.Fsd = null;
  }

  private void ParentShow()
  {
    if (this.Parent is not null)
      this.Parent.Show();
  }
#pragma warning restore CS8622 // Die NULL-Zulässigkeit von Verweistypen im Typ des Parameters entspricht (möglicherweise aufgrund von Attributen für die NULL-Zulässigkeit) nicht dem Zieldelegaten.

}