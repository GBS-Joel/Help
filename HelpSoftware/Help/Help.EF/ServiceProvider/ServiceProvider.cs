namespace Help.EF
{
  public static class HelpService
  {
    public static T GetService<T>() where T : new()
    {
      T a = new T();
      return a;
    }
  }
}