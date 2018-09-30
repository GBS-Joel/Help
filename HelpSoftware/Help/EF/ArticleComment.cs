using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class ArticleComment
  {
    [Key]
    public int ID_ArticleComment { get; set; }

    public string Comment { get; set; }

    public string CommentTitle { get; set; }

    public User UserComment { get; set; }

    public Article CommentArticle { get; set; }

    public DateTime CommentTime { get; set; }    
  }
}