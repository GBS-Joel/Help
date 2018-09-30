using Help.EF;
using Help.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Help.Test.Handler.LoginHandlerTest
{
  [TestClass]
  public class LoginHandlerTests
  {
    private MockRepository mockRepository;

    [TestInitialize]
    public void TestInitialize()
    {
      this.mockRepository = new MockRepository(MockBehavior.Strict);
    }

    [TestCleanup]
    public void TestCleanup()
    {
      this.mockRepository.VerifyAll();
      HelpContext.InitInstance();
    }

    private LoginHandler CreateLoginHandler()
    {
      return new LoginHandler();
    }

    [TestMethod]
    public void AutomaticLogin_StateUnderTest_ExpectedBehavior()
    {
      // Arrange
      var unitUnderTest = CreateLoginHandler();

      // Act
      unitUnderTest.AutomaticLogin();

      // Assert
      Assert.Fail();
    }

    [TestMethod]
    public void TryLogin_StateUnderTest_ExpectedBehavior()
    {
      // Arrange
      var unitUnderTest = CreateLoginHandler();
      string Username = "User";
      string Password = "Fischer";

      // Act
      unitUnderTest.TryLogin(Username, Password);

      // Assert
      Assert.Fail();
    }
  }
}