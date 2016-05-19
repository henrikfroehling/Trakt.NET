namespace TraktApiSharp.Tests.Requests.WithoutOAuth.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests.WithoutOAuth.Calendars;

    [TestClass]
    public class TraktCalendarAllMoviesRequestTests
    {
        [TestMethod]
        public void TestTraktCalendarAllMoviesRequestIsTraktCalendarAllRequest()
        {
            typeof(TraktCalendarAllRequest<TraktCalendarMovie>).IsAssignableFrom(typeof(TraktCalendarAllMoviesRequest)).Should().BeTrue();
        }
    }
}
