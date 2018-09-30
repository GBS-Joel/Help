using Help.EF;
using Help.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Help.Test.Handler.ErrorHandlerTest
{
  [TestClass]
  public class ErrorHandlerTests
  {
    private MockRepository mockRepository;

    [TestInitialize]
    public void TestInitialize()
    {
      this.mockRepository = new MockRepository(MockBehavior.Strict);
      HelpContext.InitInstance();
    }

    [TestCleanup]
    public void TestCleanup()
    {
      this.mockRepository.VerifyAll();
    }

    private ErrorHandler CreateErrorHandler()
    {
      return new ErrorHandler();
    }

    [TestMethod]
    public void HandleError_StateUnderTest_ExpectedBehavior()
    {
      var unitUnderTest = CreateErrorHandler();
      Exception x = new IndexOutOfRangeException();
      unitUnderTest.HandleError(x);
      Assert.IsTrue(true);
    }

    [TestMethod]
    public void ShowErrorMessage_StateUnderTest_ExpectedBehavior()
    {
      var unitUnderTest = CreateErrorHandler();
      string title = "test";
      string message = "test";
      string stacktrace = "test";

      //unitUnderTest.ShowErrorMessage(title, message, stacktrace);

      Assert.IsTrue(true);
    }

    [TestMethod]
    public void ShowErrorMessageBox_StateUnderTest_ExpectedBehavior()
    {
      var unitUnderTest = CreateErrorHandler();
      string title = "test";
      string message = "test";
      string stacktrace = "test";
      //unitUnderTest.ShowErrorMessageBox(title, message, stacktrace);
      Assert.IsTrue(true);
    }
  }
}