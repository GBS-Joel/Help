using System.Web.Mvc;

namespace Help.WebService
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
      filters.Add(new AuthorizeAttribute());
     // filters.Add(new AuthorizeAttribute());
    }
  }
}