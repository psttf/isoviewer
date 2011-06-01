using System.Windows.Forms;

namespace Ps.Iso.Viewer {
  class Helper {
    public static void ReportError(string message) {
      MessageBox.Show(message,
                      Global.IsoFileForm_PrintError_Error,
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
    }
  }
}
