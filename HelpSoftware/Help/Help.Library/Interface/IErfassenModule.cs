namespace Help.Library
{
  public interface IErfassenModule
  {
    bool ValidateWindow();

    void Save();

    void CancelSave();
  }
}