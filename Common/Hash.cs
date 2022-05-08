using System;
using System.Security.Cryptography;
using System.Text;

namespace Zeyo.FFOGameLauncher.Common
{
  internal static class Hash
  {
    public static string MD5(string text)
    {
      using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
      {
        return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
      }
    }
  }
}
