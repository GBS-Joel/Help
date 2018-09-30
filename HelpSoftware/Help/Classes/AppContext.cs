using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public static class AppContext
  {
    public static User LoggedInUser { get; set; }

    public static bool IsLoggedIn { get; set; }

    
  }
}