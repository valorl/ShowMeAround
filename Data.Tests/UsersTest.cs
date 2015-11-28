using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Data.Tests
{
    [TestClass]
    public class UsersTest
    {
        [TestInitialize]
        public void Init()
        {
            ShowMeAroundContext ctx = new ShowMeAroundContext();

            if (ctx.Language.Any(l => l.Name == "english" || l.Name == "spanish"))
            {
                ctx.Language.Add(new Language("spanish"));
                ctx.Language.Add(new Language("english"));
            }
            
            if(ctx.Interest.Any(i => i.Name == "kickbox" || i.Name == "metal"))
            {
                ctx.Interest.Add(new Interest("kickbox"));
                ctx.Interest.Add(new Interest("metal"));
                ctx.SaveChanges();
            }
           
            

            
        }
        [TestCleanup]
        public void CleanUp()
        {
            ShowMeAroundContext ctx = new ShowMeAroundContext();

            User mauro = ctx.User.Where(u => u.FirstName == "Mauro").FirstOrDefault();
            if (mauro != null) ctx.User.Remove(mauro);
            ctx.SaveChanges();
        }
        [TestMethod]
        public void User_CreateTest()
        {
            ShowMeAroundContext ctx = new ShowMeAroundContext();

            User user = new User();
            user.Id = 1;
            user.FirstName = "Mauro";
            user.LastName = "Monteiro";
            user.Email = "mauro@gmail.com";
            user.PwdHash = "Capital10!";
            user.BirthDate = DateTime.Now;

            if (ctx.Language.Find("spanish") != null) user.AddLanguage(ctx.Language.Find("spanish"));
            if (ctx.Language.Find("english") != null) user.AddLanguage(ctx.Language.Find("english"));

            if (ctx.Interest.Find("kickbox") != null) user.AddInterest(ctx.Interest.Find("kickbox"));
            if (ctx.Interest.Find("metal") != null) user.AddInterest(ctx.Interest.Find("metal"));


            
            ctx.User.Add(user);
            ctx.SaveChanges();

            
            Assert.IsNotNull(ctx.User.Where(u => u.FirstName == "Mauro"));

        }
    }
}
