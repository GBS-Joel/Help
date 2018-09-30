using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class Activity
  {
    [Key]
    public int ID_Activity { get; set; }

    public User ActivityUser { get; set; }

    public Article ActivityArticle { get; set; }

    public ActivityAction ActivityAction { get; set; }

    public string NewValue { get; set; }

    public string OldValue { get; set; }

    public DateTime ActivityOn { get; set; }

    public string ChangedPropertyName { get; set; }
  }
}