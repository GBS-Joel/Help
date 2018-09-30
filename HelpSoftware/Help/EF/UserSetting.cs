using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class UserSetting
  {
    [Key]
    public int ID_UserSetting { get; set; }

    public Setting Setting { get; set; }

    public User User { get; set; }

    public string UserValue { get; set; }

    public DateTime Created { get; set; }

    public DateTime LastChanged { get; set; }
  }
}