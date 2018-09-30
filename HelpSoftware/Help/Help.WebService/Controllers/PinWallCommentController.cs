using Help.EF;
using Help.Library;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Help.WebService.Controllers
{
  public class PinWallCommentController : ApiController
  {
    // GET: api/ProfileComment
    public string Get()
    {
      return "";
    }

    // GET: api/ProfileComment/5
    //ID --> ID User of the Profile to be loaded
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public string Get(int ID)
    {
      if (!HelpContext.IsInitialized)
        HelpContext.InitInstance();
      var qry = from u in HelpContext.Instance.PinWallComments
                where u.User.ID_User == ID
                select u;
      PinWallComment c = qry.FirstOrDefault();
      HelpContext.Instance.Entry(c).Reload();
      return JSONSerializer.ObjectToJSON(qry.ToList());
    }

    // POST: api/ProfileComment
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/ProfileComment/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/ProfileComment/5
    public void Delete(int id)
    {
    }
  }
}