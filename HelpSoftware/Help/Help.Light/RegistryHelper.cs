using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Help.Light
{
  public class RegistryHelper
  {
    public static void RegisterUriScheme()
    {
      const string UriScheme = ".help";
      const string FriendlyName = "Help Protocol";

      using (var key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\" + UriScheme))
      {
        string applicationLocation = typeof(App).Assembly.Location;

        key.SetValue("", "URL:" + FriendlyName);
        key.SetValue("URL Protocol", "");

        using (var defaultIcon = key.CreateSubKey("DefaultIcon"))
        {
          defaultIcon.SetValue("", @".\Documents\GitHubEnterprise\Help\HelpSoftware\Help\Help.Light\faviconDark.ico");
        }

        using (var commandKey = key.CreateSubKey(@"shell\open\command"))
        {
          commandKey.SetValue("", "\"" + applicationLocation + "\" \"%1\"");
        }
      }
    }
  }
}