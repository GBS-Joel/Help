using System;
using System.Linq;
using System.Windows.Media;

namespace Help.Library
{
  public class ProjectManager
  {
    public bool IsInitialized { get; set; }

    private static Random random = new Random();

    private const string DefaultChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public void UdpateAfterDatabaseInitialized()
    {
      IsInitialized = true;
    }

    //public void CreateNewProject(Project project)
    //{
    //  //Required Permission for Creating a project is to be logged in
    //  //Project can only be seen if invited to group
    //  //via Link or direct invite from an admin of the group
    //  //A project can be public
    //  //A project can be secured via a password
    //  //Here we have to create an invite Link to the Group
    //  //Adding the Creator to the Group and validate all the tnerd things
    //  if (project.ID_Project == 0)
    //  {
    //    project.Created = DateTime.Now;
    //    //First Create Project Reference Link or invite Link
    //    project.InviteLink = CreateInviteLink();
    //    //Create Password if they want
    //    if (project.CreatePassword)
    //    {
    //      project.Password = CreatePassword();
    //    }
    //    //Create Random Color
    //    if (project.RandomColor)
    //    {
    //      project.Color = CreateRandomColor();
    //    }
    //    //Add the Author as Admin to the Group After the Project is saved
    //    HelpContext.Instance.Projects.Add(project);
    //    HelpContext.Instance.SaveChanges();
    //    HelpContext.Instance.Entry(project).Reload();
    //    if (project.ID_Project != 0)
    //    {
    //      ProjectUser user = new ProjectUser()
    //      {
    //        Active = true,
    //        Berechtigung = 1,
    //        Created = DateTime.Now,
    //        Project = project,
    //        User = project.Creator
    //      };
    //      HelpContext.Instance.ProjectUser.Add(user);
    //      HelpContext.Instance.SaveChanges();
    //    }
    //  }
    //}

    private string CreatePassword()
    {
      return CreateRandomString("0123456789", 8);
    }

    //private string CreateInviteLink()
    //{
    //  string result = CreateRandomString(8);
    //  if (CheckIfProjectLinkIsFree(result))
    //  {
    //    return result;
    //  }
    //  else
    //  {
    //    return CreateInviteLink();
    //  }
    //}

    private string CreateRandomString(int len)
    {
      return CreateRandomString(DefaultChars, len);
    }

    private string CreateRandomString(string chars, int len)
    {
      return new string(Enumerable.Repeat(chars, len)
          .Select(s => s[ random.Next(s.Length) ])
          .ToArray());
    }

    private string CreateRandomColor()
    {
      // Color randomColor = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
      //Color.FromArgb()
      Color color = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
      return color.ToString();
    }

    //private bool CheckIfProjectLinkIsFree(string link)
    //{
    //  var qry = from p in HelpContext.Instance.Projects
    //            where p.InviteLink == link
    //            select p;
    //  if (qry.FirstOrDefault() != null)
    //  {
    //    return false;
    //  }
    //  else
    //  {
    //    return true;
    //  }
    //}
  }
}