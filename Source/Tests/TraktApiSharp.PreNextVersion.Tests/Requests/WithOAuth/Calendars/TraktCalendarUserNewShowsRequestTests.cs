namespace TraktApiSharp.Tests.Requests.WithOAuth.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests.WithOAuth.Calendars;

    [TestClass]
    public class TraktCalendarUserNewShowsRequestTests
    {
        [TestMethod]
        public void TestTraktCalendarUserNewShowsRequestIsTraktCalendarAllRequest()
        {
            typeof(TraktCalendarUserRequest<TraktCalendarShow>).IsAssignableFrom(typeof(TraktCalendarUserNewShowsRequest)).Should().BeTrue();
        }
    }
}
