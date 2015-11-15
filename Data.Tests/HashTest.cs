using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Utils;

namespace Data.Tests
{
    [TestClass]
    public class HashTest
    {
        [TestMethod]
        public void HashTest_EqualOutcome()
        {
            var pwd = "password";
            var salt = PasswordHasher.GetSalt();
            
            var hashedPwd1 = PasswordHasher.HashPwd(pwd, salt);
            var hashedPwd2 = PasswordHasher.HashPwd(pwd, salt);

            Assert.AreEqual(hashedPwd1, hashedPwd2);

        }
    }
}
