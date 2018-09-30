using Help.WebService.Areas.HelpPage;
using System.Web;
using System.Web.Http;

namespace Help.WebService
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web-API-Konfiguration und -Dienste

      // Web-API-Routen
      config.MapHttpAttributeRoutes();
      config.EnableCors();

      config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/XmlDocument.xml")));

      config.Routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "api/{controller}/{id}",
    defaults: new { id = RouteParameter.Optional }
);
    }
  }
}