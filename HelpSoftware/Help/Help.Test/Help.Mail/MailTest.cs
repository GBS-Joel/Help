using Help.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Help.Test
{
  [TestClass]
  public class MailTest
  {
    [TestInitialize]
    public void MailHandler_InitInstance()
    {
      MailHandler.InitInstance();
    }

    [TestMethod]
    public void MailHandler_SendMail_ValidEMail()
    {
    }

    [TestMethod]
    public void MailHandler_SendMail_InvalidEMail()
    {
    }
  }
}