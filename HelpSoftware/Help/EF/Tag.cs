using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class Tag
  {
    [Key]
    public int ID_Tag { get; set; }

    public string TagName { get; set; }

    public DateTime Created { get; set; }

    public string TagDescription { get; set; }

    public string ColorString { get; set; }
  }
}