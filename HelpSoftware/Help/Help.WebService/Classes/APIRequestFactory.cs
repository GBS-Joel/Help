using Help.EF;
using System;
using System.Web.Http;

namespace Help.WebService
{
  public static class APIRequestFactory
  {
    public static APIRequest CreateAPIRequest(ApiController controller, string response)
    {
      APIRequest r = new APIRequest()
      {
        Certificate = controller.RequestContext.RouteData.Route.ToString(),
        Time = DateTime.Now,
        Host = controller.Url.Request.Headers.Host,
        Response = response,
        Method = controller.Url.Request.Method.Method,
        Request = controller.Request.RequestUri.PathAndQuery,
        LoggedInUser = null
      };
      return r;
    }
  }
}