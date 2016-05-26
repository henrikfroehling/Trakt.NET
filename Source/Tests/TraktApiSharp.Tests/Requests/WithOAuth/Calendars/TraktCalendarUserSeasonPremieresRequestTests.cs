namespace TraktApiSharp.Tests.Requests.WithOAuth.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests.WithOAuth.Calendars;

    [TestClass]
    public class TraktCalendarUserSeasonPremieresRequestTests
    {
        [TestMethod]
        public void TestTraktCalendarUserSeasonPremieresRequestIsTraktCalendarAllRequest()
        {
            typeof(TraktCalendarUserRequest<TraktCalendarShow>).IsAssignableFrom(typeof(TraktCalendarUserSeasonPremieresRequest)).Should().BeTrue();
        }
    }
}
