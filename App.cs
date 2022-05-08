using System;
using System.Windows.Forms;
using Zeyo.FFOGameLauncher.Forms;

namespace Zeyo.FFOGameLauncher
{
  internal sealed class App
  {
    [STAThread]
    private static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}
