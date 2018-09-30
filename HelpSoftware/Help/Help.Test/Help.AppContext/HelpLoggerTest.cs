using Help.EF;
using Help.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Help.Test
{
  [TestClass]
  public class HelpLoggerTest
  {
    public static HelpLogger Logger { get; set; }

    [TestInitialize]
    public void InitLogger()
    {
      HelpContext.InitInstance();
    }

    [TestMethod]
    public void HelpLogger_Constructor()
    {
      Logger = new HelpLogger();
      Assert.IsInstanceOfType(Logger, typeof(HelpLogger));
    }

    [TestMethod]
    public void HelpLogger_ContextLog_CorrectValue()
    {
      Logger.ContextLog("Message To Log");
    }

    [TestMethod]
    public void HelpLogger_ContextLog_Null()
    {
      Logger.ContextLog(null);
    }

    [TestMethod]
    public void HelpLogger_Debug_CorrectValue()
    {
      Logger.Debug("Message To Log");
    }

    [TestMethod]
    public void HelpLogger_Debug_Null()
    {
      Logger.Debug(null);
    }

    [TestMethod]
    public void HelpLogger_Error_CorrectValue()
    {
      Logger.Error("Message To Log", "Stacktrace");
    }

    [TestMethod]
    public void HelpLogger_Error_Null()
    {
      Logger.Error(null, null);
    }
  }
}