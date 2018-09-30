using Help.EF;
using Help.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Help
{
  public partial class OrganizationOverView : HelpUserControl
  {
    public string Tit { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public string Link { get; set; }

    public OrganizationOverView(Organization Organization)
    {
      InitializeComponent();
    }

    public OrganizationOverView()
    {
      InitializeComponent();
      DataContext = this;
      Tit = "FaceBook";
      Description = "We are working to build community through open source technology. NB: members must have two-factor auth.";
      Location = "Menlo Park, California";
      Link = "https://opensource.fb.com";
    }
  }
}