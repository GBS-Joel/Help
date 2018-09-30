using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class APIRequestService : HelpBaseService<APIRequest>
  {
    public override List<APIRequest> GetAllEntities()
    {
      EFLogger.EFLog("Get All Entities on APIRequestService");
      var qry = from api in HelpContext.Instance.APIRequests
                select api;
      EFLogger.EFLog("Found " + qry.ToList().Count + " Entities on APIRequestService");
      return qry.ToList();
    }

    public override APIRequest GetEntityByID(int id)
    {
      EFLogger.EFLog("Get APIRequest with ID " + id);
      var qry = from api in HelpContext.Instance.APIRequests
                where api.ID_APIRequest == id
                select api;
      APIRequest request = qry.FirstOrDefault();
      if (request != null)
      {
        EFLogger.EFLog("Found APIRequest with ID " + id);
        return request;
      }
      else
      {
        EFLogger.EFLog("Could Not Found APIRequest with ID " + id);
        return null;
      }
    }
  }
}