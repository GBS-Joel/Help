namespace Help.Library
{
  public class SystemSettingNotFoundException : HelpException
  {
    public SystemSettingNotFoundException(string Name) : base("Die System Einstellung mit dem Name '" + Name + "' konnte nicht gefunden werden")
    {
    }

    public SystemSettingNotFoundException() : base()
    {
    }
  }
}