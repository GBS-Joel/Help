using Help.EF;
using Help.Library;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Help.WebService.Controllers
{
  public class TranslationController : ApiController
  {
    // GET: api/Translation
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public string Get()
    {
      if (!HelpContext.IsInitialized)
        HelpContext.InitInstance();
      var qry = from t in HelpContext.Instance.Translations
                select t;
      return JSONSerializer.ObjectToJSON(qry.ToList());
    }

    // GET: api/Translation/5
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/Translation
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/Translation/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/Translation/5
    public void Delete(int id)
    {
    }
  }
}