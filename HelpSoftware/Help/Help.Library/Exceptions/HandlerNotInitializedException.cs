namespace Help.Library
{
  public class HandlerNotInitializedException : HelpException
  {
    public HandlerNotInitializedException()
    {
    }

    public HandlerNotInitializedException(string Message) : base(Message)
    {
    }
  }
}