using Help.EF;
using Help.Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Help.WebService.Controllers
{
  public class UserController : ApiController
  {
    // GET: api/User[EnableCors]
    /// <summary>
    /// This is a test
    /// </summary>
    /// <returns></returns>
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public string Get()
    {
      if (!HelpContext.IsInitialized)
      {
        HelpContext.InitInstance();
      }
      var qry = from u in HelpContext.Instance.Users
                select u;
      List<User> Users = qry.ToList();

      foreach (var item in Users)
      {
        item.Password = "";
      }

      string resp = JSONSerializer.ObjectToJSON(Users);
      HelpContext.Instance.Dispose();
      HelpContext.InitInstance();
      HelpContext.Instance.APIRequests.Add(APIRequestFactory.CreateAPIRequest(this, resp));
      HelpContext.Instance.SaveChanges();
      return resp;
    }

    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public string Get(string Username)
    {
      if (!HelpContext.IsInitialized)
      {
        HelpContext.InitInstance();
      }
      var qry = from u in HelpContext.Instance.Users
                where u.Username == Username
                select u;
      List<User> Users = qry.ToList();
      string resp = JSONSerializer.ObjectToJSON(Users);
      HelpContext.Instance.APIRequests.Add(APIRequestFactory.CreateAPIRequest(this, resp));
      HelpContext.Instance.SaveChanges();
      return resp;
    }

    // GET: api/User/5
    public string Get(int id)
    {
      if (!HelpContext.IsInitialized)
      {
        HelpContext.InitInstance();
      }
      var qry = from u in HelpContext.Instance.Users
                where u.ID_User == id
                select u;
      var us = qry.FirstOrDefault();
      us.Password = "";
      return JSONSerializer.ObjectToJSON(us);
    }

    // POST: api/User
    public void Post([FromBody]string value)
    {
      if (!HelpContext.IsInitialized)
      {
      }
    }

    // PUT: api/User/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/User/5
    public void Delete(int id)
    {
    }
  }
}