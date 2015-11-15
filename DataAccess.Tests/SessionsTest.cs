using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using DataAccess;

namespace DataAccess.Tests
{
    [TestClass]
    public class SessionsTest
    {
        [TestInitialize]
        public void Init()
        {
            var da = new SessionDA();
            da.Insert(new Session { UserID = 1, Token = "abcdefghijklmnopqrstuvxyz", TimeStamp = DateTime.Now });
            da.SaveChanges();
        }

        [TestMethod]
        public void FindTest()
        {
            var da = new SessionDA();
            var foundSession = da.GetOneByToken("abcdefghijklmnopqrstuvxyz");
            Assert.IsNotNull(foundSession);
        }

        [TestCleanup]
        public void CleanUp()
        {
            var da = new SessionDA();
            var session = da.GetOneByToken("abcdefghijklmnopqrstuvxyz");
            if (session != null)
            {
                da.Delete(session);
                da.SaveChanges();
            }
        }
    }
}
