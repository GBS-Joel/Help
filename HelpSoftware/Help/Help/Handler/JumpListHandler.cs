using Help.Library;
using System.Reflection;
using System.Windows;
using System.Windows.Shell;

namespace Help
{
  public static class JumpListHandler
  {
    public static JumpList JList { get; set; }

    public static void CreateJumpList()
    {
      JumpList jumpList = new JumpList();
      JumpList.SetJumpList(Application.Current, jumpList);
      JList = jumpList;
      SetUpJumpTasks();
      JList.Apply();
    }

    public static void UpdateJumpList()
    {
      if (JList != null)
      {
        JList.JumpItems.Clear();
        SetUpJumpTasks();
        JList.Apply();
      }
    }

    public static void SetUpJumpTasks()
    {
      if (AppContext.IsLoggedIn)
        JList.JumpItems.Add(CreateJumpTask("Create New Article", "Shortcut for Creating a New Article", "NewArticle"));
      else
        JList.JumpItems.Add(CreateJumpTask("Propose Article", "Shortcut for Proposing a New Article", "ProposeArticle"));
    }

    public static JumpTask CreateJumpTask(string Title, string Desc, string Arg)
    {
      return new JumpTask()
      {
        Title = Title,
        Description = Desc,
        ApplicationPath = Assembly.GetEntryAssembly().Location,
        Arguments = "/" + Arg
      };
    }
  }
}