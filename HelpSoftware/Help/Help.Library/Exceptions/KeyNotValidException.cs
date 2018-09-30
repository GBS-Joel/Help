namespace Help.Library
{
  public class KeyNotValidException : HelpException
  {
    public KeyNotValidException(string Message) : base("Das Bild mit dem Schlüssel '" + Message + "' konnte nicht gefunden werden!")
    {
    }

    public KeyNotValidException() : base()
    {
    }
  }
}