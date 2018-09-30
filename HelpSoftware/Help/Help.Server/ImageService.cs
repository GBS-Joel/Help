using System;
using System.IO;

namespace Help.Server
{
  public static class ImageService
  {
    //TODO Change to System Setting to Load from the Database
    public const string ImportFilePath = @".\Documents\GitHubEnterprise\Help\Images\Import";

    public static void WriteImageEntry()
    {

    }

    public static void DoService()
    {
      Program.WriteMessage("Check For Images");
      DirectoryInfo d = new DirectoryInfo(ImportFilePath);
      foreach (var item in d.GetFiles("*.*"))
      {
        try
        {
          item.CopyTo(@".\GitHubEnterprise\Help\Images\" + item.Name);
          Console.ForegroundColor = ConsoleColor.Magenta;
          Program.WriteMessage("Copy File " + item.Name);
          Console.ForegroundColor = ConsoleColor.White;
          item.Delete();
        }
        catch (Exception x)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Program.WriteMessage(x.Message);
          File.Delete(item.FullName);
          Console.ForegroundColor = ConsoleColor.White;
        }
      }
    }
  }
}