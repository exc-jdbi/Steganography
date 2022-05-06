

//namespace exc.jdbi.Threads;
namespace exc.jdbi.Stegographie.Forms.App;
class StegoEncryptionThread : IDisposable
{
#pragma warning disable CS8622 // Die NULL-Zulässigkeit von Verweistypen im Typ des Parameters entspricht (möglicherweise aufgrund von Attributen für die NULL-Zulässigkeit) nicht dem Zieldelegaten.

  internal bool IsDisposed;
  private FrmStegoEncryption? Fse = null;
  private readonly FrmMain? Parent = null;
  internal string ImageFileNamePath = string.Empty;
  public event EventHandler<EventArgs> Closed = delegate { };

  public StegoEncryptionThread(FrmMain parent, string filename)
  {
    if (parent is not null)
      this.Parent = parent;
    else throw new ArgumentNullException(nameof(parent));

    parent.Hide();
    this.IsDisposed = false;
    this.Fse = new FrmStegoEncryption(filename);
    if (this.Fse is not null) { 
      //Die FormCosing von FrmStegoEncryption wird hierher verschoben.
      //was die ganze Sache um einiges besser kontrollieren lässt.
      this.Fse.FormClosing += new FormClosingEventHandler(this.FrmStegoEncryption_FormClosing);
      this.Fse.TopMost = true;
    }
    var thd = new Thread(this.WorkerThread) { IsBackground = true };
    thd.SetApartmentState(ApartmentState.STA);
    thd.Start();
  }

  private void FrmStegoEncryption_FormClosing(object sender, FormClosingEventArgs e)
  {
    this.IsDisposed = true;
    if (this.Fse is not null)
    {
      this.Fse.ResetAllControls(); 
      this.ImageFileNamePath = string.Empty;
      if (this.Parent is not null)
        this.Parent.FileNamePath = string.Empty; 
    }

    if (this.Parent is not null)
      this.Parent.Invoke(this.ParentShow);

    this.Closed(this, EventArgs.Empty);
  }

  public void Dispose()
  {
    if (!this.IsDisposed && this.Fse is not null)
    {
      this.Fse.Invoke(new MethodInvoker(this.StopThread));
      this.IsDisposed = true;
    }
  }

  private void StopThread()
  {
    if (this.Fse is not null)
      this.Fse.Close();
  }

  private void WorkerThread()
  {
    Application.Run(this.Fse);
    if (this.Fse is not null) this.Fse = null;
  }

  private void ParentShow()
  {
    if (this.Parent is not null)
      this.Parent.Show();
  }
#pragma warning restore CS8622 // Die NULL-Zulässigkeit von Verweistypen im Typ des Parameters entspricht (möglicherweise aufgrund von Attributen für die NULL-Zulässigkeit) nicht dem Zieldelegaten.

}