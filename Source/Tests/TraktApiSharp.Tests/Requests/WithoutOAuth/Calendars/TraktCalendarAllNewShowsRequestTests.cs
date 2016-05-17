namespace TraktApiSharp.Tests.Requests.WithoutOAuth.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests.WithoutOAuth.Calendars;

    [TestClass]
    public class TraktCalendarAllNewShowsRequestTests
    {
        [TestMethod]
        public void TestTraktCalendarAllNewShowsRequestIsTraktCalendarAllRequest()
        {
            typeof(TraktCalendarAllRequest<TraktCalendarShow>).IsAssignableFrom(typeof(TraktCalendarAllNewShowsRequest)).Should().BeTrue();
        }
    }
}
