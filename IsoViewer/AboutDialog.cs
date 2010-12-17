using System;
using System.Reflection;
using System.Windows.Forms;

using System.Diagnostics;

namespace Ps.Iso.Viewer
{
  public partial class AboutDialog : Form
  {
    public AboutDialog()
    {
      InitializeComponent();

      var version = Assembly.GetExecutingAssembly().GetName().Version;
      var buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(
        // days since 1 January 2000
        TimeSpan.TicksPerDay * version.Build + 
        // seconds since midnight, (multiply by 2 to get original)
        TimeSpan.TicksPerSecond * 2 * version.Revision));

      lblTitleAndVersion.Text += version.ToString();
      lblYear.Text = lblYear.Text.Replace("{$currentYear}", buildDateTime.Year.ToString());
    }

    private void lnkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(string.Format("mailto:{0}?Subject={1}&Body={2}",
                                                     "p.shapkin@gmail.com", "ISO Viewer Feedback", "Ваши отзывы:"));
    }

    private void lnkToViniti_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(string.Format("http://www.viniti.ru"));
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(string.Format("http://www.gnu.org/copyleft/lesser.html"));
    }

    private void llLGPLRu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(string.Format("http://ru.wikisource.org/wiki/GNU_Lesser_General_Public_License"));
    }

    private void llISOViewer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(string.Format("http://code.google.com/p/isoviewer/"));
    }
  }
}