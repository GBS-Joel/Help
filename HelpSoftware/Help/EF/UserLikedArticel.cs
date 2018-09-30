using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class UserLikedArticel
  {
    [Key]
    public int ID_UserLikedArticel { get; set; }

    public User LikedUser { get; set; }

    public Article LikedArticel { get; set; }

    public DateTime LikedTime { get; set; }
  }
}