using Help.EF;
using Help.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Help.Test
{
  [TestClass]
  public class AppContextTest
  {
    [TestInitialize]
    public void SetupDatabase()
    {
      HelpContext.InitInstance();
    }

    [TestMethod]
    public void AppContext_InitAppContext()
    {
      AppContext.InitAppContext();
      Assert.IsInstanceOfType(AppContext.RibbonManagerInstance, typeof(RibbonManager));
      Assert.IsInstanceOfType(AppContext.IconManagerInstance, typeof(IconManager));

      //TODO: Check every property in that Context
    }

    [TestMethod]
    public void AppContext_SetClientInfo()
    {
      AppContext.SetClientInfo();
      Assert.IsTrue(AppContext.ClientInfo.ConnectionString == Connection.ConnectionString);
    }

    [TestMethod]
    public void AppContext_IsAtRuntime()
    {
      Assert.IsTrue(AppContext.IsAtRuntime);
    }
  }
}