namespace Help.Library
{
  public class UserNotLoggedInException : HelpException
  {
    public UserNotLoggedInException(string Message) : base(Message)
    {
    }

    public UserNotLoggedInException() : base()
    {
    }
  }
}