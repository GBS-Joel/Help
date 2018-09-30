using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class AppErrorService : HelpBaseService<AppError>
  {
    public override List<AppError> GetAllEntities()
    {
      EFLogger.EFLog("Get All Entities on AppErrorService");
      var qry = from apperror in HelpContext.Instance.AppErrors
                select apperror;
      EFLogger.EFLog("Found " + qry.ToList().Count + " Entities on AppErrorService");
      return qry.ToList();
    }

    public override AppError GetEntityByID(int id)
    {
      EFLogger.EFLog("Get AppError with ID " + id);
      var qry = from apperror in HelpContext.Instance.AppErrors
                where apperror.ID_AppError == id
                select apperror;
      AppError error = new AppError();
      if (error != null)
      {
        EFLogger.EFLog("Found AppError with ID " + id);
        return error;
      }
      else
      {
        EFLogger.EFLog("Could Not Found AppError with ID " + id);
        return null;
      }
    }
  }
}