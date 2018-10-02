using Help.WebService.Classes;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Services.Description;

[assembly: OwinStartup(typeof(Help.WebService.StartUp))]
namespace Help.WebService
{
  public class StartUp
  {
    public void ConfigureAuth(IAppBuilder app)
    {
      var OAuthOptions = new OAuthAuthorizationServerOptions
      {
        AllowInsecureHttp = true,
        AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
        AuthorizeEndpointPath = new PathString("/token"),
        TokenEndpointPath = new PathString("/token"),
        
        AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
        Provider = new SimpleAuthorizationServerProvider()
      };

      app.UseOAuthBearerTokens(OAuthOptions);
      app.UseOAuthAuthorizationServer(OAuthOptions);
      app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

      HttpConfiguration config = new HttpConfiguration();
      config.EnableCors();
      WebApiConfig.Register(config);
    }

    

    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app);
      GlobalConfiguration.Configure(WebApiConfig.Register);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
  }
}