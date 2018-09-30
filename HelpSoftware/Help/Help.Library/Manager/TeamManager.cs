using Help.EF;

namespace Help.Library
{
  //Create and Act over this Class if Teams are there
  public class TeamManager
  {
    public TeamMessageManager MessageManager { get; set; }

    public TeamManager()
    {
      MessageManager = new TeamMessageManager();
    }

    public bool TryCreateTeam(Team team)
    {
      return true;
      
    }

    public void WriteCreatingTeamMessage(Team team)
    {

    }

    //Only Active and Verified User in the Team
    public bool CheckIfUserIsVerified(User User)
    {
      return User.IsActive && User.IsVerified;
    }
  }
}