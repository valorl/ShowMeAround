using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Service.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void CreateTest()
        {
            Data.User user = new Data.User()
            {
                FirstName = "Valer",
                LastName = "Orlovsky",
                Email = "valer@mail.com",
                BirthDate = DateTime.Now
            };
            
                       
        }
    }
}
