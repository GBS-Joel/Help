using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class ArticleViewHistory
  {
    [Key]
    public int ID_ArticleViewHistory { get; set; }

    public DateTime ViewTime { get; set; }

    public User User { get; set; }

    public Article Article { get; set; }
  }
}