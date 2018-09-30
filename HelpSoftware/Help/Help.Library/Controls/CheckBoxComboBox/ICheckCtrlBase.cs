using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Library
{
  public interface ICheckCtrlBase
  {
    object CheckedValue { get; set; }

    void SetDisplay(string displayText);
  }
}