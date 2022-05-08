using System;
using System.Text;

namespace Zeyo.FFOGameLauncher.Common
{
  internal static class Crypt
  {
    public static string Base64Encode(string text)
    {
      try
      {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
      }
      catch
      {
        return "";
      }
    }

    public static string Base64Decode(string text)
    {
      try
      {
        return Encoding.UTF8.GetString(Convert.FromBase64String(text));
      }
      catch
      {
        return "";
      }
    }
  }
}
