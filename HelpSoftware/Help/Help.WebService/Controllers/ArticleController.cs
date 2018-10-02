using Help.EF;
using Help.Library;
using System.Web.Http;

namespace Help.WebService.Controllers
{
  /// <summary>
  /// This Controller is responsible for Accessing Articles
  /// </summary>
  public class ArticleController : ApiController
  {
    /// <summary>
    /// Gets the Article from the Database without the Author
    /// </summary>
    /// <param name="ID">The ID of the Article</param>
    /// <returns>JSON of the Article Found in the Databse without the Author</returns>
    [HttpGet]
    [Authorize]
    public string Get(int ID)
    {
      if (!HelpContext.IsInitialized)
        HelpContext.InitInstance();
      HelpContext.Instance.Configuration.LazyLoadingEnabled = false;
      var art = HelpService.GetService<ArticleService>().GetEntityByID(ID);
      HelpContext.Instance.Configuration.LazyLoadingEnabled = true;
      return JSONSerializer.ObjectToJSON(art);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    [HttpPost]
    [Authorize]
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