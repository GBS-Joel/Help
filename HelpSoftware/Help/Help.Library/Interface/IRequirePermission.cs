namespace Help.Library
{
  public interface IRequirePermission
  {
    bool RequirePermission { get; set; }

    bool IsCurrentPermissionEnough();

    HelpPermission RequiredPermission { get; set; }
  }
}