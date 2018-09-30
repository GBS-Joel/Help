using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class UserWatchArticle
  {
    [Key]
    public int ID_UserWatchArticle { get; set; }

    public User WatchedUser { get; set; }

    public Article WatchedArticle { get; set; }

    public DateTime WatchedTime { get; set; }
  }
}