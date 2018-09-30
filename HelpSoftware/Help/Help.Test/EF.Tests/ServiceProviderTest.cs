//using Help.EF;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System;

////MethodName_StateUnderTest_ExpectedBehavior
////ClassName_MethodName_ExpectedBehavior
//namespace Help.Test
//{
//  [TestClass]
//  public class ServiceProviderTest
//  {
//    [TestMethod]
//    public void ServiceProvider_GetServiceByType_GetKnownInstance()
//    {
//      ServiceProvider provider = new ServiceProvider();
//      var service = provider.GetServiceByType(typeof(UserService));
//      Assert.IsInstanceOfType(service, typeof(UserService));
//    }

//    [TestMethod]
//    public void ServiceProvider_GetServiceByType_GetInstanceFromUnknownType()
//    {
//      var serviceprovider = new Mock<ServiceProvider>();
//      serviceprovider.Setup(x => x.GetServiceByType(typeof(FileStyleUriParser))).Throws<ArgumentException>();
//      try
//      {
//        var service = serviceprovider.Object.GetServiceByType(typeof(FileStyleUriParser));
//      }
//      catch (Exception) { }
//      serviceprovider.Verify(x => x.GetServiceByType(typeof(FileStyleUriParser)));
//    }

//    [TestMethod]
//    public void ServiceProvider_GetServiceByType_GetInstanceFromNull()
//    {
//      var serviceprovider = new Mock<ServiceProvider>();
//      serviceprovider.Setup(x => x.GetServiceByType(null)).Throws<ArgumentException>();
//      try
//      {
//        var service = serviceprovider.Object.GetServiceByType(null);
//      }
//      catch (Exception) { }
//      serviceprovider.Verify(x => x.GetServiceByType(null));
//    }

//    [TestMethod]
//    public void GetInstanceFromServiceProviderString()
//    {
//      var serviceprovider = new Mock<ServiceProvider>();
//      var service = serviceprovider.Object.GetServiceByName("UserService");
//      Assert.IsTrue(service is UserService);
//    }

//    [TestMethod]
//    public void GetInstanceFromServiceProviderWhenNameIsNull()
//    {
//      var serviceprovider = new Mock<ServiceProvider>();
//      serviceprovider.Setup(x => x.GetServiceByName(null)).Throws<ArgumentException>();
//      try
//      {
//        var service = serviceprovider.Object.GetServiceByName(null);
//      }
//      catch (Exception) { }
//      serviceprovider.Verify(x => x.GetServiceByName(null));
//    }
//  }
//}