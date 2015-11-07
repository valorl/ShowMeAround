using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Data.Tests
{
    [TestClass]
    public class UsersTest
    {
        [TestMethod]
        public void AddUser()
        {
            User user = new User();
            user.Id = 1;
            user.FirstName = "Mauro";
            user.LastName = "Monteiro";
            user.Email = "mauro@gmail.com";
            user.BirthDate = DateTime.Now;

            ICollection<Language> languages = new HashSet<Language>();
            languages.Add(new Language(1, "spanish"));
            languages.Add(new Language(2, "english"));

            ICollection<Interest> interests = new HashSet<Interest>();
            interests.Add(new Interest(1, "kickbox"));
            interests.Add(new Interest(2, "metal"));

            user.Languages = languages;
            user.Interests = interests;

            ShowMeAroundContext context = new ShowMeAroundContext();
            context.User.Add(user);
            context.SaveChanges();

            Assert.IsNotNull(context.User.Find(1));

        }
    }
}
