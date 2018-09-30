using Help.EF;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Help.WebService.Controllers
{
  public class BugReportController : ApiController
  {
    // GET: api/BugReport[EnableCors]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public string Get()
    {
      return "";
    }

    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    //public string Get(string Username)
    //{
    //  if (!HelpContext.IsInitialized)
    //  {
    //    HelpContext.InitInstance();
    //  }
    //  var qry = from u in HelpContext.Instance.Users
    //            where u.Username == Username
    //            select u;
    //  List<User> Users = qry.ToList();
    //  string resp = JSONSerializer.ObjectToJSON(Users);
    //  HelpContext.Instance.APIRequests.Add(APIRequestFactory.CreateAPIRequest(this, resp));
    //  HelpContext.Instance.SaveChanges();
    //  return resp;
    //}

    //// GET: api/User/5
    //public string Get(int id)
    //{
    //  if (!HelpContext.IsInitialized)
    //  {
    //    HelpContext.InitInstance();
    //  }
    //  var qry = from u in HelpContext.Instance.Users
    //            where u.ID_User == id
    //            select u;
    //  var us = qry.FirstOrDefault();
    //  us.Password = "";
    //  return JSONSerializer.ObjectToJSON(us);
    //}

    // POST: api/BugReport
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public string Post(string title, string body)
    {
      if (!HelpContext.IsInitialized)
      {
        HelpContext.InitInstance();
      }
      BugReport r = new BugReport()
      {
        Error = body,
        ReportTime = DateTime.Now,
        ReportUser = null,
        ReportTitle = title,
        Report = "This is a Report from the Website Help.Web"
      };
      HelpContext.Instance.BugReports.Add(r);
      HelpContext.Instance.SaveChanges();
      return "success";
    }

    // PUT: api/User/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/User/5
    public void Delete(int id)
    {
    }
  }
}