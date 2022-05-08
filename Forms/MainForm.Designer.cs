using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Zeyo.FFOGameLauncher.Common;

namespace Zeyo.FFOGameLauncher.Forms
{
  partial class MainForm
  {
    private IContainer components = null;

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (this.components != null)
        {
          this.components.Dispose();
        }
      }
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components                  = new Container();
      /************************************************/
      this.mainFoolStripContainer      = new ToolStripContainer();
      this.usernameLabel               = new Label();
      this.usernameTextBox             = new TextBox();
      this.passwordLabel               = new Label();
      this.passwordTextBox             = new TextBox();
      this.launchButton                = new Button();
      this.topMenuStrip                = new MenuStrip();
      this.fileToolStripMenuItem       = new ToolStripMenuItem();
      this.settingsToolStripMenuItem   = new ToolStripMenuItem();
      this.exitToolStripMenuItem       = new ToolStripMenuItem();
      this.bottomStatusStrip           = new StatusStrip();
      this.messageToolStripStatusLabel = new ToolStripStatusLabel();
      this.guiTimer                    = new Timer(this.components);
      /************************************************/
      // mainFoolStripContainer
      {
        this.mainFoolStripContainer.Name = "mainFoolStripContainer";
        this.mainFoolStripContainer.Dock = DockStyle.Fill;
        this.mainFoolStripContainer.ContentPanel.Font       = new Font(FontFamily.GenericMonospace, 8f);
        this.mainFoolStripContainer.ContentPanel.RenderMode = ToolStripRenderMode.System;
        this.mainFoolStripContainer.ContentPanel.Controls.Add(this.usernameLabel);
        this.mainFoolStripContainer.ContentPanel.Controls.Add(this.usernameTextBox);
        this.mainFoolStripContainer.ContentPanel.Controls.Add(this.passwordLabel);
        this.mainFoolStripContainer.ContentPanel.Controls.Add(this.passwordTextBox);
        this.mainFoolStripContainer.ContentPanel.Controls.Add(this.launchButton);
      }
      // usernameLabel
      {
        this.usernameLabel.Name      = "usernameLabel";
        this.usernameLabel.Location  = new Point(10, 10);
        this.usernameLabel.Size      = new Size(50, 20);
        this.usernameLabel.Text      = "帳號：";
        this.usernameLabel.TextAlign = ContentAlignment.MiddleLeft;
        this.usernameLabel.Click += this.usernameLabel_Click;
      }
      // usernameTextBox
      {
        this.usernameTextBox.Name                  = "usernameTextBox";
        this.usernameTextBox.Location              = new Point(65, 10);
        this.usernameTextBox.Size                  = new Size(150, 20);
        this.usernameTextBox.Text                  = Config.Default.Username;
        this.usernameTextBox.UseSystemPasswordChar = false;
        this.usernameTextBox.TextChanged += this.usernameTextBox_TextChanged;
      }
      // passwordLabel
      {
        this.passwordLabel.Name      = "passwordLabel";
        this.passwordLabel.Location  = new Point(10, 35);
        this.passwordLabel.Size      = new Size(50, 20);
        this.passwordLabel.Text      = "密碼：";
        this.passwordLabel.TextAlign = ContentAlignment.MiddleLeft;
        this.passwordLabel.Click += this.passwordLabel_Click;
      }
      // passwordTextBox
      {
        this.passwordTextBox.Name                  = "passwordTextBox";
        this.passwordTextBox.Location              = new Point(65, 35);
        this.passwordTextBox.Size                  = new Size(150, 20);
        this.passwordTextBox.Text                  = Config.Default.Password;
        this.passwordTextBox.UseSystemPasswordChar = true;
        this.passwordTextBox.TextChanged += this.passwordTextBox_TextChanged;
      }
      // launchButton
      {
        this.launchButton.Name     = "launchButton";
        this.launchButton.Location = new Point(220, 10);
        this.launchButton.Size     = new Size(50, 45);
        this.launchButton.Text     = "啟動";
        this.launchButton.Click += this.launchButton_Click;
      }
      // topMenuStrip
      {
        this.topMenuStrip.Name       = "topMenuStrip";
        this.topMenuStrip.Dock       = DockStyle.Top;
        this.topMenuStrip.Font       = new Font(FontFamily.GenericMonospace, 8f);
        this.topMenuStrip.RenderMode = ToolStripRenderMode.System;
        this.topMenuStrip.Items.Add(this.fileToolStripMenuItem);
      }
      // fileToolStripMenuItem
      {
        this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        this.fileToolStripMenuItem.Text = "檔案";
        this.fileToolStripMenuItem.DropDownItems.Add(this.settingsToolStripMenuItem);
        this.fileToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
        this.fileToolStripMenuItem.DropDownItems.Add(this.exitToolStripMenuItem);
        this.fileToolStripMenuItem.DropDownOpening += this.fileToolStripMenuItem_DropDownOpening;
      }
      // settingsToolStripMenuItem
      {
        this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        this.settingsToolStripMenuItem.Text = "設定";
        this.settingsToolStripMenuItem.Click += this.settingsToolStripMenuItem_Click;
      }
      // exitToolStripMenuItem
      {
        this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        this.exitToolStripMenuItem.Text = "結束";
        this.exitToolStripMenuItem.Click += this.exitToolStripMenuItem_Click;
      }
      // bottomStatusStrip
      {
        this.bottomStatusStrip.Name       = "bottomStatusStrip";
        this.bottomStatusStrip.Dock       = DockStyle.Bottom;
        this.bottomStatusStrip.Font       = new Font(FontFamily.GenericMonospace, 8f);
        this.bottomStatusStrip.RenderMode = ToolStripRenderMode.System;
        this.bottomStatusStrip.SizingGrip = false;
        this.bottomStatusStrip.Items.Add(this.messageToolStripStatusLabel);
      }
      // messageToolStripStatusLabel
      {
        this.messageToolStripStatusLabel.Name = "messageToolStripStatusLabel";
        this.messageToolStripStatusLabel.Text = "就緒";
      }
      // guiTimer
      {
        this.guiTimer.Enabled  = true;
        this.guiTimer.Interval = 100;
        this.guiTimer.Tick += this.guiTimer_Tick;
      }
      // MainForm
      {
        base.Name            = "MainForm";
        base.AcceptButton    = this.launchButton;
        base.AutoScaleMode   = AutoScaleMode.Font;
        base.AutoScroll      = true;
        base.ClientSize      = new Size(240, 95);
        base.Font            = new Font(FontFamily.GenericMonospace, 8f);
        base.FormBorderStyle = FormBorderStyle.FixedSingle;
        base.MaximizeBox     = false;
        base.StartPosition   = FormStartPosition.CenterScreen;
        base.Text            = "Zeyo.FFOGameLauncher";
        base.Controls.Add(this.mainFoolStripContainer);
        base.Controls.Add(this.topMenuStrip);
        base.Controls.Add(this.bottomStatusStrip);
      }
    }

    private ToolStripContainer   mainFoolStripContainer      = null;
    private Label                usernameLabel               = null;
    private TextBox              usernameTextBox             = null;
    private Label                passwordLabel               = null;
    private TextBox              passwordTextBox             = null;
    private Button               launchButton                = null;
    private MenuStrip            topMenuStrip                = null;
    private ToolStripMenuItem    fileToolStripMenuItem       = null;
    private ToolStripMenuItem    settingsToolStripMenuItem   = null;
    private ToolStripMenuItem    exitToolStripMenuItem       = null;
    private StatusStrip          bottomStatusStrip           = null;
    private ToolStripStatusLabel messageToolStripStatusLabel = null;
    private Timer                guiTimer                    = null;
  }
}
