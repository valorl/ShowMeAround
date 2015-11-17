using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataAccess.Tests
{
    [TestClass]
    public class MeetupsTest
    {


        [TestInitialize]
        public void Init()
        {
            var uDA = new UserDA();
            MeetUp mu = new MeetUp()
            {
                Traveler = uDA.GetOneByID(32),
                Guide = uDA.GetOneByID(33),
                City = "New York",
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now,
                GuideState = RequestState.Received,
                TravelerState = RequestState.Sent
                
                
            };

            var mDA = new MeetUpDA();
            mDA.Insert(mu);
            mDA.SaveChanges();

        }

        [TestMethod]
        public void MeetUp_FindTest()
        {
            var mDA = new MeetUpDA();
            var meetup = mDA.GetAll().Where(m => m.City == "New York").SingleOrDefault();
            Assert.IsNotNull(meetup);
        }
    }
}
