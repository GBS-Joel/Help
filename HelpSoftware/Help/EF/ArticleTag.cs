using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class ArticleTag
  {
    [Key]
    public int ID_ArticleTag { get; set; }

    public Article Article { get; set; }

    public Tag Tag { get; set; }

    public DateTime AssingTime { get; set; }

    public User User { get; set; }
  }
}