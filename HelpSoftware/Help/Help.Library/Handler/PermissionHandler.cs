namespace Help.Library
{
  public class PermissionHandler
  {
    public PermissionHandler()
    {
      AppContext.Logger.Debug("Init Instance of Permission Handler");
    }

    public bool GetIsCurrentPermissionEnough()
    {
      return true;
    }

    //public int GetPermissionForProjectForCurrentUser(Project project)
    //{
    //  if (AppContext.IsLoggedIn)
    //  {
    //    var qry = from us in HelpContext.Instance.ProjectUser
    //              where us.User.ID_User == AppContext.LoggedInUser.ID_User
    //              where us.Project.ID_Project == project.ID_Project
    //              select us;
    //    if (qry.FirstOrDefault() != null)
    //    {
    //      return qry.FirstOrDefault().Berechtigung;
    //    }
    //    else
    //    {
    //      throw new NullReferenceException();
    //    }
    //  }
    //  else
    //  {
    //    throw new UserNotLoggedInException();
    //  }
    //}
  }
}