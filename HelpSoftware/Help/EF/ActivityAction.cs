using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class ActivityAction
  {
    [Key]
    public int ID_ActivityAction { get; set; }

    public string ActionName { get; set; }
  }
}
