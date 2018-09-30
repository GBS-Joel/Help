using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class ViewHistory
  {
    [Key]
    public int ID_ViewHistory { get; set; }

    public Article ViewedArticle { get; set; }

    public User ViewedUser { get; set; }

    public DateTime AccessTime { get; set; }
  }
}
