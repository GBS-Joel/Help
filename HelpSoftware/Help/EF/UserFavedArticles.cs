using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class UserFavedArticles
  {
    [Key]
    public int ID_UserFavedArticles { get; set; }

    public User FavedUser { get; set; }

    public Article FavedArticle { get; set; }

    public DateTime FavedTime { get; set; }
  }
}