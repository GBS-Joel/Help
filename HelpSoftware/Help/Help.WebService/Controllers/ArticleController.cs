using Help.EF;
using Help.Library;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Help.WebService.Controllers
{
  public class ArticleController : ApiController
  {
    // GET: api/Article/ID
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public string Get(int ID)
    {
      if (!HelpContext.IsInitialized)
        HelpContext.InitInstance();
      var qry = from a in HelpContext.Instance.Articles
                where a.ID_Article == ID
                select a;
      var art = qry.FirstOrDefault();
      if (art.Author != null)
      {
        art.Author.Password = "";
      }
      return JSONSerializer.ObjectToJSON(art);
    }

    // GET: api/Article/5

    // POST: api/Article
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/Article/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/Article/5
    public void Delete(int id)
    {
    }
  }
}