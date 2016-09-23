namespace TraktApiSharp.Tests.Experimental.Requests.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars;

    [TestClass]
    public class TraktCalendarAllNewShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllNewShowsRequestIsNotAbstract()
        {
            typeof(TraktCalendarAllNewShowsRequest).IsAbstract.Should().BeFalse();
        }

    }
}
