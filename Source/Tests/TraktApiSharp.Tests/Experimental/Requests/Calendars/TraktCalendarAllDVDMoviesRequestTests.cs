namespace TraktApiSharp.Tests.Experimental.Requests.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars;
    using TraktApiSharp.Objects.Get.Calendars;

    [TestClass]
    public class TraktCalendarAllDVDMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllDVDMoviesRequestIsNotAbstract()
        {
            typeof(TraktCalendarAllDVDMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllDVDMoviesRequestIsSealed()
        {
            typeof(TraktCalendarAllDVDMoviesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllDVDMoviesRequestIsSubclassOfATraktCalendarAllRequest()
        {
            typeof(TraktCalendarAllDVDMoviesRequest).IsSubclassOf(typeof(ATraktCalendarAllRequest<TraktCalendarMovie>)).Should().BeTrue();
        }
    }
}
