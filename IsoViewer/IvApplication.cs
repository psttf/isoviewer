using System;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Ps.Iso.Viewer
{
	public class IvApplication
	{
	  /// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{
			try
			{
				new FileIOPermission(PermissionState.Unrestricted).Demand();
				string fileName = null;
				if (args.Length > 0)
				{
					fileName = args[0];
				}
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm(fileName));
			}
			catch (SecurityException)
			{
				MessageBox.Show(Global.IvApplication_Main_NoAcces);
			} 
			//Application.Exit();
		}
	}
}
