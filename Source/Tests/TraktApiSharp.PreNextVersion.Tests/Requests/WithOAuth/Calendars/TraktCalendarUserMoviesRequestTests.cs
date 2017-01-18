namespace TraktApiSharp.Tests.Requests.WithOAuth.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests.WithOAuth.Calendars;

    [TestClass]
    public class TraktCalendarUserMoviesRequestTests
    {
        [TestMethod]
        public void TestTraktCalendarUserMoviesRequestIsTraktCalendarAllRequest()
        {
            typeof(TraktCalendarUserRequest<TraktCalendarMovie>).IsAssignableFrom(typeof(TraktCalendarUserMoviesRequest)).Should().BeTrue();
        }
    }
}
