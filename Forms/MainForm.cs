using System;
using System.IO;
using System.Windows.Forms;
using Zeyo.FFOGameLauncher.Common;
using Zeyo.FFOGameLauncher.Core;
using Zeyo.FFOGameLauncher.Dialogs;

namespace Zeyo.FFOGameLauncher.Forms
{
  internal partial class MainForm : Form
  {
    public MainForm()
    {
      this.InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      /************************************************/
      this.UpdateUI();
    }

    private void usernameLabel_Click(object sender, EventArgs e)
    {
      this.usernameTextBox.Focus();
    }

    private void passwordLabel_Click(object sender, EventArgs e)
    {
      this.passwordTextBox.Focus();
    }

    private void usernameTextBox_TextChanged(object sender, EventArgs e)
    {
      this.UpdateUI();
    }

    private void passwordTextBox_TextChanged(object sender, EventArgs e)
    {
      this.UpdateUI();
    }

    private void launchButton_Click(object sender, EventArgs e)
    {
      try
      {
        FFOGame launcher = new FFOGame(this.usernameTextBox.Text, this.passwordTextBox.Text);
        /************************************************/
        if (launcher.Run(Config.Default.Application))
        {
          base.Close();
        }
      }
      catch (Exception ex)
      {
        if (MessageBox.Show(ex.Message, ex.HelpLink, MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
        {
          
        }
      }
    }

    private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
    {
      this.UpdateUI();
    }

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (SettingsDialog dialog = new SettingsDialog())
      {
        switch (dialog.ShowDialog(this))
        {
          case DialogResult.OK:
          {
            if (Config.Default.Save())
            {
              if (MessageBox.Show(this, "某些設定，需要重新啟動應用程式才會生效。是否繼續？", "重啟程式？", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
              {
                Application.Restart();
              }
            }
            else
            {
              if (MessageBox.Show(this, string.Format("無法讀寫 {0} 檔案。", Config.Default.FileName), "存取被拒。", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
              {
                // TODO: do-nothing.
              }
            }
            break;
          }
          case DialogResult.Cancel:
          {
            Config.Default.Reload();
            break;
          }
        }
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      base.Close();
    }

    private void guiTimer_Tick(object sender, EventArgs e)
    {
      this.UpdateUI();
    }

    private void UpdateUI()
    {
      this.launchButton.Enabled = 1==1
      &&                          this.usernameTextBox.Text != ""
      &&                          this.passwordTextBox.Text != ""
      &&                          File.Exists(Config.Default.Application)
      ;
    }
  }
}
