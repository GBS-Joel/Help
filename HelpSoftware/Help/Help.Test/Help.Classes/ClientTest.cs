using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Help.Test
{
  [TestClass]
  public class ClientTest
  {
    [TestInitialize]
    public void CreateConfigFile()
    {
      string envpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      string path = Path.Combine(envpath, @"Help\ConfFile.txt");
      File.Copy(Path.GetFullPath(@"..\..\Setup\ConfFile.txt"), path, true);
    }

    [TestMethod]
    public void Client_TryLoadConfigFile_LoadExistingFile()
    {
      //Client c = new Client();
      //var res = c.TryLoadConfigFile();
      //Assert.IsTrue(res);
    }
  }
}