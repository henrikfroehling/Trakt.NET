namespace TraktApiSharp.Tests.Experimental.Requests.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars;

    [TestClass]
    public class TraktCalendarAllMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestIsNotAbstract()
        {
            typeof(TraktCalendarAllMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestIsSealed()
        {
            typeof(TraktCalendarAllMoviesRequest).IsSealed.Should().BeTrue();
        }

    }
}
