using Help.EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Help.Test
{
  [TestClass]
  public class UserServiceTest
  {
    [TestMethod]
    public void GetAllUserFromUserService()
    {
      var data = new List<User>
      {
        new User {Vorname = "AAA" },
        new User {Vorname = "BBB" },
        new User {Vorname = "CCC" }
      }.AsQueryable();

      var mockSet = new Mock<DbSet<User>>();
      mockSet.As<IQueryable<User>>().Setup(u => u.Provider).Returns(data.Provider);
      mockSet.As<IQueryable<User>>().Setup(u => u.Expression).Returns(data.Expression);
      mockSet.As<IQueryable<User>>().Setup(u => u.ElementType).Returns(data.ElementType);
      mockSet.As<IQueryable<User>>().Setup(u => u.GetEnumerator()).Returns(data.GetEnumerator());

      var mockContext = new Mock<HelpContext>();
      HelpContext.Instance = mockContext.Object;

      mockContext.Setup(c => c.Users).Returns(mockSet.Object);

      UserService service = new UserService();
      List<User> users = service.GetAllEntities();
      Assert.AreEqual(3, users.Count);
      Assert.AreEqual("AAA", users[0].Vorname);
      Assert.AreEqual("BBB", users[1].Vorname);
      Assert.AreEqual("ZZZ", users[2].Vorname);
    }
  }
}