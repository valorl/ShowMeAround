using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Collections.Generic;
using Service.Utils;


namespace Service.Tests
{
    [TestClass]
    public class MatchingTest
    {
        private User traveler;
        private User guide;

        [TestInitialize]
        public void Init()
        {
            // prepare traveler 
            traveler = new User()
            {
                FirstName = "Miroslaw",
                LastName = "Luch",
                Email = "miroluch@gmail.com",
                BirthDate = DateTime.Now,
                Languages = new List<Language>()
                {
                    new Language("English"),
                    new Language("German")
                } ,
                
                Interests = new List<Interest>()
                {
                    new Interest("Volleyball"),
                    new Interest("Singing"),
                    new Interest("Programming"),
                    new Interest("Sailing"),
                    new Interest("Weaponry")
                }

                
            };

            // prepare guide
            guide = new User()
            {
                FirstName = "Johnny",
                LastName = "Jay",
                Email = "joja@whatever.com",
                BirthDate = DateTime.Now,
                Languages = new List<Language>()
                {
                    new Language("English"),
                    new Language("German"),
                    new Language("Japanese")
                },

                Interests = new List<Interest>()
                {
                    new Interest("Volleyball"),
                    new Interest("Singing"),
                    new Interest("Science"),
                    new Interest("Animals"),
                    new Interest("Sightseeing")
                }                
            };
        }

        [TestMethod]
        public void Check_that_matching_returns_a_score()
        {
            var mp = new MatchingProvider();
            var matchingScore = mp.GetMatch(traveler, guide);
            Assert.IsNotNull(matchingScore);
        }

        [TestMethod]
        public void Check_that_score_is_expected()
        {
            var mp = new MatchingProvider();
            var matchingScore = mp.GetMatch(traveler, guide).Score;
            var expectedScore = 210;
            Assert.AreEqual(expectedScore, matchingScore);
        }

        [TestCleanup]
        public void CleanUp()
        {
            traveler = null;
            guide = null;
        }


    }
}
