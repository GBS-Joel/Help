using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Library
{
  public interface ICheckViewModel
  {
    List<CheckItem> CheckItems { get; set; }

    Type BoundType { get; }

    bool IsRadioMode { get; set; }

    ICheckCtrlBase HostParent { get; set; }

    void InitDiscovery();

    void ApplyValue(object newValue);
  }
}
