using Help.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Help.Test
{
  [TestClass]
  public class HashGeneratorTest
  {
    [TestMethod]
    public void HashGenerator_Hash_GenerateNormalHash()
    {
      string Password = "ABC123ANC+&/ABC123";
      string hash = HashGenerator.Hash(Password);
      Assert.IsTrue(HashGenerator.Verify(Password, hash));
    }

    [TestMethod]
    public void GenerateHashWithNull()
    {
      string password = null;
      try
      {
        string hash = HashGenerator.Hash(password);
      }
      catch (Exception)
      {
        Assert.IsNull(password);
      }
    }

    [TestMethod]
    public void GenerateHashWithLongPassword()
    {
      int i = 0;
      StringBuilder builder = new StringBuilder();
      int maxcap = builder.MaxCapacity;
      while (i < 100000000)
      {
        builder.Append("A");
        i++;
      }
      string hash = HashGenerator.Hash(builder.ToString());
      Assert.IsTrue(HashGenerator.Verify(builder.ToString(), hash));
    }
  }
}