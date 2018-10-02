using Help.WebService.Areas.HelpPage;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Help.WebService
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web-API-Konfiguration und -Dienste
      config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
      // Web-API-Routen
      config.MapHttpAttributeRoutes();
      config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/XmlDocument.xml")));
      config.Routes.MapHttpRoute(
name: "DefaultApi",
routeTemplate: "api/{controller}/{id}",
defaults: new { id = RouteParameter.Optional }
);
    }
  }
}