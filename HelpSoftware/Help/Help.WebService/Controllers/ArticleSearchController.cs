using Help.EF;
using Help.Library;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Help.WebService.Controllers
{
  public class ArticleSearchController : ApiController
  {
    // GET: api/ArticleSearch
    [HttpGet]
    [Authorize]
    public string Get(string Suche)
    {
      if (!HelpContext.IsInitialized)
        HelpContext.InitInstance();
      var res = ArticleSearcher.TrySearch(Suche);
      return JSONSerializer.ObjectToJSON(res);
    }

    // GET: api/Article/5
    public string Get(int id)
    {
      return "value";
    }

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