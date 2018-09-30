using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.EF
{
  public class ProjectUser
  {
    [Key]
    public int ID_ProjectUser { get; set; }

    public Project Project { get; set; }

    public User User { get; set; }

    public int Berechtigung { get; set; }

    public DateTime Created { get; set; }

    public bool Active { get; set; }
  }
}