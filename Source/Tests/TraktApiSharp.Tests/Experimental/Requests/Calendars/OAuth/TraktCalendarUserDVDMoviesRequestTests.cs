namespace TraktApiSharp.Tests.Experimental.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars.OAuth;

    [TestClass]
    public class TraktCalendarUserDVDMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarUserDVDMoviesRequestIsNotAbstract()
        {
            typeof(TraktCalendarUserDVDMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarUserDVDMoviesRequestIsSealed()
        {
            typeof(TraktCalendarUserDVDMoviesRequest).IsSealed.Should().BeTrue();
        }
    }
}
