namespace TraktApiSharp.Tests.Experimental.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars.OAuth;

    [TestClass]
    public class TraktCalendarUserMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarUserMoviesRequestIsNotAbstract()
        {
            typeof(TraktCalendarUserMoviesRequest).IsAbstract.Should().BeFalse();
        }
    }
}
