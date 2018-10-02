using Help.EF;
using Help.Library;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Help.WebService.Classes
{
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
  {
    [AllowAnonymous]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
      context.Validated();
    }

    [AllowAnonymous]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
      var identity = new ClaimsIdentity(context.Options.AuthenticationType);
      context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[ ] { "*" });

      if (!HelpContext.IsInitialized)
        HelpContext.InitInstance();

      if (context.UserName != "" && context.Password != "")
      {
        var Users = HelpService.GetService<UserService>().GetUsersFromUserName(context.UserName);

        foreach (var item in Users)
        {
          if (item.Username == item.Username)
          {
            if (HashGenerator.Verify(context.Password, item.Password))
            {
              identity.AddClaim(new Claim("ID_User", item.ID_User.ToString()));

              var props = new AuthenticationProperties(new Dictionary<string, string>
                            {
                                {
                                    "userdisplayname", context.UserName
                                },
                                {
                                     "role", "admin"
                                }
                             });
              var ticket = new AuthenticationTicket(identity, props);
              context.Validated(ticket);
            }
            else
            {
              context.SetError("invalid_grant", "Provided username and password is incorrect");
              context.Rejected();
            }
          }
        }
      }
      else
      {
        context.SetError("invalid_grant", "Provided username and password is incorrect");
        context.Rejected();
      }
      return;
    }
  }
}