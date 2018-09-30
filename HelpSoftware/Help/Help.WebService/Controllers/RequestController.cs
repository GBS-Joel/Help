using Help.Library;
using System.Web.Http;

namespace Help.WebService.Controllers
{
  public class RequestController : ApiController
  {
    // GET: api/Request
    public string Get()
    {
      return JSONSerializer.ObjectToJSON("Token");
    }

    // GET: api/Request/5
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/Request
    public string Post([FromBody]string value)
    {
      return JSONSerializer.ObjectToJSON("Token");
    }

    // PUT: api/Request/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/Request/5
    public void Delete(int id)
    {
    }
  }
}