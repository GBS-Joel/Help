using Help.EF;
using Help.Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Help.WebService.Controllers
{
  public class ActivityController : ApiController
  {
    // GET: api/Activity
    public string Get()
    {
      return "";
    }

    // GET: api/Activity/5
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public string Get(int ID)
    {
      if (!HelpContext.IsInitialized)
        HelpContext.InitInstance();
      var qry = from a in HelpContext.Instance.Activities
                where a.ActivityUser.ID_User == ID
                orderby a.ActivityOn descending
                select a;
      List<Activity> Acts = qry.ToList();
      foreach (var item in Acts)
      {
        if (item.ActivityUser != null)
        {
          item.ActivityUser.Password = "";
        }
      }
      return JSONSerializer.ObjectToJSON(Acts);
    }

    // POST: api/Activity
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/Activity/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/Activity/5
    public void Delete(int id)
    {
    }
  }
}