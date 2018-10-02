using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.EF
{
  public enum WerteBereichValueRangeItemType
  {
    Exact = 1,
    Bigger = 2,
    BiggerOrSame = 3,
    Smaller = 4,
    SmallerOrSame = 5,
    Regex = 6,
    IsPath = 7,
  }
}