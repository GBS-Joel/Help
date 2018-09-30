using System;

namespace Help.Library
{
  public class JumpListHandler : IRefreshAfterLogin
  {
    public void CreateJumpList()
    {
      //JumpTask task = new JumpTask()
      //{
      //  Title = "Create A New Article",
      //};
      //JumpList jumpList = new JumpList();
      //jumpList.JumpItems.Add(task);
      //jumpList.ShowFrequentCategory = false;
      //jumpList.ShowRecentCategory = false;
      //JumpList.SetJumpList(Application.Current, jumpList);
    }

    public void UpdateAfterLogin()
    {
    }

    public void UpdateOnLogin()
    {
      throw new NotImplementedException();
    }

    public void UpdateOnLogOut()
    {
      throw new NotImplementedException();
    }
  }
}