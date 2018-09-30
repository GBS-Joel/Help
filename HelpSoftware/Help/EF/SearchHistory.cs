using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class SearchHistory
  {
    [Key]
    public int ID_SearchHistory { get; set; }

    public string SearchText { get; set; }

    public DateTime SearchTime { get; set; }

    public User SearchedUser { get; set; }
  }
}