using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms.Design;

namespace Zeyo.FFOGameLauncher.Common
{
  internal class Config
  {
    public Config(string fileName)
    {
      if (!File.Exists(fileName))
      {
        using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Zeyo.FFOGameLauncher.Resources.FFOGameLauncher.ini"))
        {
          using (StreamReader reader = new StreamReader(stream))
          {
            File.WriteAllText(fileName, reader.ReadToEnd());
          }
        }
      }
      /************************************************/
      if ((this.FileName = Path.GetFullPath(fileName)) != "")
      {
        this.Reload();
      }
    }

    private static Config instance = null;
    public static Config Default
    {
      get
      {
        return  instance = instance
        ??      new Config(string.Format("{0}.ini", Process.GetCurrentProcess().ProcessName));
      }
    }

    private string fileName = "";
    [Category("#Profile")]
    public string FileName
    {
      get
      {
        return this.fileName;
      }
      private set
      {
        this.fileName = value;
      }
    }

    private string application = "";
    [Category("Game")]
    [Description("遊戲主程式路徑")]
    [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
    public string Application
    {
      get
      {
        return this.application;
      }
      set
      {
        this.application = value;
      }
    }

    private string username = "";
    [Category("Security")]
    [Description("使用者帳號")]
    public string Username
    {
      get
      {
        return this.username;
      }
      set
      {
        this.username = value;
      }
    }

    private string password;
    [Category("Security")]
    [Description("使用者密碼")]
    [PasswordPropertyText(true)]
    public string Password
    {
      get
      {
        return this.password;
      }
      set
      {
        this.password = value;
      }
    }

    public bool Save()
    {
      return  1==1
      &&      this.Write("Game    ".Trim(), "Application".Trim(),                   (this.Application))
      &&      this.Write("Security".Trim(), "Username   ".Trim(),                   (this.Username   ))
      &&      this.Write("Security".Trim(), "Password   ".Trim(), Crypt.Base64Encode(this.Password   ))
      ;
    }

    public void Reload()
    {
      this.Application =                   (this.Read("Game    ".Trim(), "Application".Trim(), "game.bin".Trim()));
      this.Username    =                   (this.Read("Security".Trim(), "Username   ".Trim(), "        ".Trim()));
      this.Password    = Crypt.Base64Decode(this.Read("Security".Trim(), "Password   ".Trim(), "        ".Trim()));
    }

    private string Read(string section, string key, string defaultValue)
    {
      StringBuilder buffer = new StringBuilder(512);
      /************************************************/
      return  WinAPI.GET_PRIVATE_PROFILE_STRING(section, key, defaultValue, buffer, buffer.Capacity, this.FileName) == buffer.Length
      ?       buffer.ToString()
      :       "";
    }

    private bool Write(string section, string key, string value)
    {
      return WinAPI.WRITE_PRIVATE_PROFILE_STRING(section, key, value, this.FileName);
    }
  }
}
