using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class Note
  {
    [Key]
    public int ID_Note { get; set; }

    public string NoteName { get; set; }

    public DateTime Created { get; set; }
  }
}