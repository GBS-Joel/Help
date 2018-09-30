using Help.EF;
using Help.Library;
using System.Collections.Generic;
using System.Web.Http;

namespace Help.WebService.Controllers
{
  public class SearchHistoryController : ApiController
  {
    // GET: api/SearchHistory
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET: api/SearchHistory/5
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/SearchHistory
    public void Post(string Val)
    {
      var res = (SearchHistory)JSONSerializer.JSONToObject(Val, typeof(SearchHistory));
      res.ID_SearchHistory = null;
      if (!HelpContext.IsInitialized)
        HelpContext.InitInstance();
      HelpContext.Instance.SearchHistories.Add(res);
      HelpContext.Instance.SaveChanges();
    }

    // PUT: api/SearchHistory/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/SearchHistory/5
    public void Delete(int id)
    {
    }
  }
}