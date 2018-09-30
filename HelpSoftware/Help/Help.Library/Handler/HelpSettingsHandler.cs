using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Library
{
  public class HelpSettingsHandler
  {
    public SettingsHandler SettingsHandler { get; set; }

    public UserSettingsHandler UserSettingsHandler { get; set; }

    public SystemSettingHandler SystemSettingsHandler { get; set; }

    public HelpSettingsHandler()
    {
      SettingsHandler = new SettingsHandler();
      UserSettingsHandler = new UserSettingsHandler();
      SystemSettingsHandler = new SystemSettingHandler();
    }
  }
}