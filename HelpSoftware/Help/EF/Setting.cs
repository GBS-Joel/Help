using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class Setting
  {
    [Key]
    public int ID_UserSetting { get; set; }

    public string DefaultValue { get; set; }

    public string SettingName { get; set; }

    public DateTime Created { get; set; }
  }
}