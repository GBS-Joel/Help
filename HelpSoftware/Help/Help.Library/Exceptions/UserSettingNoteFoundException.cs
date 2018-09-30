namespace Help.Library
{
  public class UserSettingNoteFoundException : HelpException
  {
    public UserSettingNoteFoundException(string Message) : base("Die User Setting mit dem Namen " + Message + " wurde nicht gefunden")
    {
    }

    public UserSettingNoteFoundException() : base()
    {
    }
  }
}