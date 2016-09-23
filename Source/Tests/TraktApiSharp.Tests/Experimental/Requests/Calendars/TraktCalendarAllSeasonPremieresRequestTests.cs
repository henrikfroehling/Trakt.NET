namespace TraktApiSharp.Tests.Experimental.Requests.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars;

    [TestClass]
    public class TraktCalendarAllSeasonPremieresRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Seasons")]
        public void TestTraktCalendarAllSeasonPremieresRequestIsNotAbstract()
        {
            typeof(TraktCalendarAllSeasonPremieresRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Seasons")]
        public void TestTraktCalendarAllSeasonPremieresRequestIsSealed()
        {
            typeof(TraktCalendarAllSeasonPremieresRequest).IsSealed.Should().BeTrue();
        }
    }
}
