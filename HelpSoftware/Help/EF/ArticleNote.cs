using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class ArticleNote
  {
    [Key]
    public int ID_ArticleNote { get; set; }

    public Article Article { get; set; }

    public Note Note { get; set; }

    public User User { get; set; }

    public DateTime Created { get; set; }
  }
}