using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Service.Tests
{
    [TestClass]
    public class MeetupTest
    {
        [TestMethod]
        public void Check_that_DatesOverlap_returns_expected()
        {
            var muService = new MeetUpService();
            // Prepare periods
            DateTime startA = DateTime.ParseExact("14/12/2015","dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime endA = DateTime.ParseExact("20/12/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime startB = DateTime.ParseExact("13/12/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime endB = DateTime.ParseExact("25/12/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //  14/12/2015 - 20/12/2015 overlaps with 13/12/2015 - 25/12/2015 -> Expected: TRUE
            bool test_true = muService.DatesOverlap(startA, endA, startB, endB);

            // Adjust periods
            startA = DateTime.ParseExact("14/12/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            endA = DateTime.ParseExact("16/12/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            startB = DateTime.ParseExact("20/12/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            endB = DateTime.ParseExact("26/12/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            // 14/12/2015 - 16/12/2015 does not overlap with 20/12/2015 - 26/12/2015 -> Expected: FALSE
            bool test_false = muService.DatesOverlap(startA, endA, startB, endB);

            // Assertions
            Assert.IsTrue(test_true);
            Assert.IsFalse(test_false);

        }
    }
}
