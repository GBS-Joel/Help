using Help.EF;
using Help.Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Help.WebService.Controllers
{
  public class ArticleFeedController : ApiController
  {
    // GET: api/ArticleFeed
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public string Get()
    {
      if (!HelpContext.IsInitialized)
        HelpContext.InitInstance();
      var qry = (from a in HelpContext.Instance.Articles
                 select a).Take(10);
      List<Article> art = new List<Article>();
      art = qry.ToList();
      foreach (var item in art)
      {
        if (item.Author != null)
          item.Author.Password = "";
      }
      return JSONSerializer.ObjectToJSON(art);
    }

    // GET: api/ArticleFeed/5
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/ArticleFeed
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/ArticleFeed/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/ArticleFeed/5
    public void Delete(int id)
    {
    }
  }
}