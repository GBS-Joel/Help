using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class BugReport
  {
     [Key]
    public int ID_BugReport { get; set; }

    public User ReportUser { get; set; }

    public DateTime ReportTime { get; set; }

    public string Report { get; set; }

    public string ReportTitle { get; set; }

    public string Error { get; set; }
  }
}