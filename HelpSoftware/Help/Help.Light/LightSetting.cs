using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Light
{
  public class LightSetting
  {
    public bool IsDarkThemeEnabled { get; set; }

    public bool RandomAppThemeEnabled { get; set; }

    public ApplicationThemes Theme { get; set; }
  }
}