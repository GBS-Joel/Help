using Help.EF;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Help.WebService.Controllers
{
  public class VerifyController : ApiController
  {
    // GET: api/Verify
    /// <summary>
    ///
    /// </summary>
    /// <param name="Token"></param>
    /// <returns></returns>
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public string Get(string Token)
    {
      if (!HelpContext.IsInitialized)
        HelpContext.InitInstance();
      var qry = from v in HelpContext.Instance.Verifies
                where v.Token == Token
                select v;
      Verify Ver = qry.FirstOrDefault();
      if (Ver != null)
      {
        Ver.IsVerified = true;
        Ver.VerifyTime = DateTime.Now;
        if (Ver.User != null)
          Ver.User.IsVerified = true;
        HelpContext.Instance.SaveChanges();
        return "true";
      }
      else
      {
        return "false";
      }
    }

    // GET: api/Verify/5
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/Verify
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/Verify/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/Verify/5
    public void Delete(int id)
    {
    }
  }
}