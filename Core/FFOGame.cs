using System;
using System.Diagnostics;
using System.IO;
using Zeyo.FFOGameLauncher.Common;

namespace Zeyo.FFOGameLauncher.Core
{
  public class FFOGame
  {
    private Process process = null;

    public FFOGame()
    {
      this.process = new Process();
      {
        this.process.StartInfo.UseShellExecute = false;
      }
    }

    public FFOGame(string username, string password) : this()
    {
      this.Username = username;
      this.Password = password;
    }

    public string EasyFun
    {
      get
      {
        return "EasyFun";
      }
    }

    private string username = "";
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

    private string password = "";
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

    public bool Run(string fileName)
    {
      string[] args = new string[]
      {
                                                       string.Format("   {0}".Trim(),         (this.EasyFun ))     ,
        (this.Username != "" && this.Password != "") ? string.Format("-a {0}".Trim(),         (this.Username)) : "",
        (this.Username != "" && this.Password != "") ? string.Format("-p {0}".Trim(), Hash.MD5(this.Password)) : "",
      };
      /************************************************/
      this.process.StartInfo.FileName         = fileName;
      this.process.StartInfo.Arguments        = string.Join(" ", args);
      this.process.StartInfo.WorkingDirectory = Path.GetDirectoryName(fileName);
      /************************************************/
      return this.process.Start();
    }
  }
}
