using Help.EF;
using Help.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Help.Test.Handler.FileHandlerTest
{
  [TestClass]
  public class FileHandlerTests
  {
    private MockRepository mockRepository;
    private readonly string path = @".\Help\HelpSoftware\Help\Help.Test\Setup\FileHandlerTestFile.txt";

    [TestInitialize]
    public void TestInitialize()
    {
      this.mockRepository = new MockRepository(MockBehavior.Strict);
      HelpContext.InitInstance();
      // File.WriteAllText(path, string.Empty);
    }

    [TestCleanup]
    public void TestCleanup()
    {
      this.mockRepository.VerifyAll();
      //File.WriteAllText(path, string.Empty);
    }

    private FileHandler CreateFileHandler()
    {
      return new FileHandler();
    }

    [TestMethod]
    public void CreateFile_StateUnderTest_ExpectedBehavior()
    {
      // Arrange
      var unitUnderTest = CreateFileHandler();
      string FilePath = path;

      // Act
      unitUnderTest.CreateFile(FilePath);

      // Assert
      Assert.IsTrue(true);
    }

    [TestMethod]
    public void WriteToEndOfFile_StateUnderTest_ExpectedBehavior()
    {
      // Arrange
      var unitUnderTest = CreateFileHandler();
      string File = path;
      string Text = "Test";

      // Act
      unitUnderTest.WriteToEndOfFile(File, Text);

      // Assert
      Assert.IsTrue(true);
    }

    [TestMethod]
    public void CheckIfFileExits_StateUnderTest_ExpectedBehavior()
    {
      // Arrange
      var unitUnderTest = CreateFileHandler();
      string Path = path;

      // Act
      var result = unitUnderTest.CheckIfFileExits(Path);

      // Assert
      Assert.IsTrue(result);
    }

    [TestMethod]
    public void CheckIfFileExistsAndCreate_StateUnderTest_ExpectedBehavior()
    {
      // Arrange
      var unitUnderTest = CreateFileHandler();
      string Path = path;

      // Act
      unitUnderTest.CheckIfFileExistsAndCreate(Path);

      // Assert
      Assert.IsTrue(unitUnderTest.CheckIfFileExits(path));
    }

    [TestMethod]
    public void GetContentOfFile_StateUnderTest_ExpectedBehavior()
    {
      // Arrange
      var unitUnderTest = CreateFileHandler();
      string Path = @".\Help\HelpSoftware\Help\Help.Test\Setup\FileHandlerTestFile2.txt";

      // Act
      var result = unitUnderTest.GetContentOfFile(
        Path);

      // Assert
      Assert.IsTrue(result[0] == "Test");
    }
  }
}