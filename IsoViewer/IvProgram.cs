using System;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Ps.Iso.Viewer {
  class IvProgram {
    [STAThread]
    static void Main(string[] args) {
      try {
        new FileIOPermission(PermissionState.Unrestricted).Demand();
        Application.EnableVisualStyles();
        var application =
          new IvApplication();
        application.Run(args);
      } catch (SecurityException) {
        MessageBox.Show(Global.IvApplication_Main_NoAcces);
      }
    }
  }
}
