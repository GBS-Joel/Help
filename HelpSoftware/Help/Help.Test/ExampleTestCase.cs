//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Help.EF;
//using Help;

//namespace Help.Test
//{
//  [TestClass]
//  class ExampleTestCase
//  {
//    [TestMethod]
//    public void CreateExample()
//    {
//      var mockSet = new Mock<DbSet<Activity>>();
//      var mockContext = new Mock<HelpContext>();

//      mockContext.Setup(m => m.Activities).Returns(mockSet.Object);

//      //Class to test
//      //var service = new BlogService(mockContext.Object);
//      //service.AddBlog(Params);

//      //überprüft ob die Methode SaveChanes() aufgerufen wurde
//      //mockSet.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once());
//      //mockContext.Verify(m => m.SaveChanges(), Times.Once());
//    }
//  }
//}