using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class LoginHistory
  {
    [Key]
    public int ID_LoginHistory { get; set; }

    public User LoggedInUser { get; set; }

    public DateTime LoggedInTime { get; set; }

    public int LoginType { get; set; }
  }
}