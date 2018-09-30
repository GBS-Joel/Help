namespace Help.Library
{
  public interface INeedHelpPermission
  {
    HelpPermission RequiredPermission { get; set; }

    void UpdatePermissionRequired();
  }
}