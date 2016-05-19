namespace TraktApiSharp.Tests.Requests.WithoutOAuth.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests.WithoutOAuth.Calendars;

    [TestClass]
    public class TraktCalendarAllShowsRequestTests
    {
        [TestMethod]
        public void TestTraktCalendarAllShowsRequestIsTraktCalendarAllRequest()
        {
            typeof(TraktCalendarAllRequest<TraktCalendarShow>).IsAssignableFrom(typeof(TraktCalendarAllShowsRequest)).Should().BeTrue();
        }
    }
}
