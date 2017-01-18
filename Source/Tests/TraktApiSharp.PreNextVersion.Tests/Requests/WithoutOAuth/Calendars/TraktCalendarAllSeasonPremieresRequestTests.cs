namespace TraktApiSharp.Tests.Requests.WithoutOAuth.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests.WithoutOAuth.Calendars;

    [TestClass]
    public class TraktCalendarAllSeasonPremieresRequestTests
    {
        [TestMethod]
        public void TestTraktCalendarAllSeasonPremieresRequestIsTraktCalendarAllRequest()
        {
            typeof(TraktCalendarAllRequest<TraktCalendarShow>).IsAssignableFrom(typeof(TraktCalendarAllSeasonPremieresRequest)).Should().BeTrue();
        }
    }
}
