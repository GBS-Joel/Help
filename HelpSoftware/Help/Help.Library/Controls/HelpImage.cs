using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Help.Library
{
  public class HelpImage : Image
  {
    protected override void OnRender(DrawingContext dc)
    {
      VisualBitmapScalingMode = BitmapScalingMode.HighQuality;
      base.OnRender(dc);
    }
  }
}