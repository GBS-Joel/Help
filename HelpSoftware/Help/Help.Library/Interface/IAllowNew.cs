namespace Help.Library
{
  public interface IAllowNew
  {
    /// <summary>
    /// Indicates if the Command New can be Executed
    /// </summary>
    /// <returns>True if a new Entity Can be Executed</returns>
    bool CanNewBeExecuted();

    /// <summary>
    /// The Window thats open if the New Command is executed
    /// </summary>
    /// <returns>The Window that is opened when the new Command is executed</returns>
    IModuleElement GetNewWindow();
  }
}