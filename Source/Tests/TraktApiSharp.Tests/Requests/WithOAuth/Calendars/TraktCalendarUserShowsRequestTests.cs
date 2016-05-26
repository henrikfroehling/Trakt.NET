namespace TraktApiSharp.Tests.Requests.WithOAuth.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests.WithOAuth.Calendars;

    [TestClass]
    public class TraktCalendarUserShowsRequestTests
    {
        [TestMethod]
        public void TestTraktCalendarUserShowsRequestIsTraktCalendarAllRequest()
        {
            typeof(TraktCalendarUserRequest<TraktCalendarShow>).IsAssignableFrom(typeof(TraktCalendarUserShowsRequest)).Should().BeTrue();
        }
    }
}
