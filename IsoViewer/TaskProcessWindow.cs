using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ps.Iso.Viewer {
  public partial class TaskProcessWindow : Form {
    public IsoFileScheme Result;
    private readonly Task _task;
    readonly CancellationTokenSource _tokenSource =
      new CancellationTokenSource();

    public TaskProcessWindow() {
      Init();
    }

    public TaskProcessWindow(Action<Action<int>> action, string title) {
      Init();
      _task = new Task(() => action(SetProgress), _tokenSource.Token);
      _task.ContinueWith(t => {
        var message = "";
        if (t.Exception == null) return;
        message = t.Exception.InnerExceptions.Aggregate(message,
          (current, innerException) =>
            current + (innerException.Message + "\n"));
        Helper.ReportError(message);
      }, TaskContinuationOptions.OnlyOnFaulted);
      _task.ContinueWith(t => {
        if (pbProcessProgress.InvokeRequired) {
          this.InvokeEx(Close);
        } else {
          Close();
        }
      });
      lblTitle.Text = title;
    }

    private void Init() {
      InitializeComponent();
    }

    public void SetProgress(int percentComplete) {
      // InvokeRequired required compares the thread ID of the
      // calling thread to the thread ID of the creating thread.
      // If these threads are different, it returns true.
      if (pbProcessProgress.InvokeRequired) {
        this.InvokeEx(() => SetProgress(percentComplete));
      } else {
        pbProcessProgress.Value = percentComplete;
      }
    }

    private void btnCancel_Click(object sender, EventArgs e) {
      _tokenSource.Cancel();
    }

    private void TaskProcessWindow_Shown(object sender, EventArgs e) {
      _task.Start();
    }
  }
}

