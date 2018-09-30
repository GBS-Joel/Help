using System.IO;

namespace Help.Library
{
  public class FileHandler
  {
    public void CreateFile(string FilePath)
    {
      if (!File.Exists(FilePath))
      {
        File.Create(FilePath);
        AppContext.Logger.Info("Created File " + FilePath);
      }
    }

    public bool CheckIfFileExits(string Path)
    {
      return File.Exists(Path);
    }

    public void WriteToEndOfFile(string File, string Text)
    {
      if (File != null && File != "" && Text != null && Text != "")
      {
        CreateFile(File);
        using (StreamWriter sw = new StreamWriter(new FileStream(File, FileMode.Append)))
        {
          sw.WriteLine(Text);
        }
      }
    }

    public void CheckIfFileExistsAndCreate(string Path)
    {
      if (!File.Exists(Path))
      {
        File.Create(Path);
      }
    }

    public void DeleteFile(string Path)
    {
      if (File.Exists(Path))
      {
        File.Delete(Path);
      }
    }

    public string[ ] GetContentOfFile(string Path)
    {
      AppContext.Logger.Debug("Get Content Of File" + Path);
      CheckIfFileExits(Path);
      return File.ReadAllLines(Path);
    }
  }
}