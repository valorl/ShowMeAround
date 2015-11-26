using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

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
            traveler = new User()
            {
                // prepare traveler ...
            };
            guide = new User()
            {
                // prepare guide
            };


        }

        [TestMethod]
        public void Check_that_matching_returns_a_score()
        {
            // get a score from MatchingProvider for traveler and guide
            // Assert that score isnt null

        }

        [TestMethod]
        public void Check_that_score_is_expected()
        {
            // get a score from MatchingProvider for traveler and guide
            // Calculate the score manually
            // Assert true if returned score matches the expected score
        }

        [TestCleanup]
        public void CleanUp()
        {
            traveler = null;
            guide = null;
        }


    }
}
