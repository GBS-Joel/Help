using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class SystemSetting
  {
    [Key]
    public int ID_SystemSetting { get; set; }

    public string Name { get; set; }

    public string Value { get; set; }

    public DateTime Created { get; set; }
  }
}