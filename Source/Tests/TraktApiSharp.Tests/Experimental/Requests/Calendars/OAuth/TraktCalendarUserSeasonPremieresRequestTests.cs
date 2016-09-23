namespace TraktApiSharp.Tests.Experimental.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars.OAuth;
    using TraktApiSharp.Objects.Get.Calendars;

    [TestClass]
    public class TraktCalendarUserSeasonPremieresRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserSeasonPremieresRequestIsNotAbstract()
        {
            typeof(TraktCalendarUserSeasonPremieresRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserSeasonPremieresRequestIsSealed()
        {
            typeof(TraktCalendarUserSeasonPremieresRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserSeasonPremieresRequestIsSubclassOfATraktCalendarUserRequest()
        {
            typeof(TraktCalendarUserSeasonPremieresRequest).IsSubclassOf(typeof(ATraktCalendarUserRequest<TraktCalendarShow>)).Should().BeTrue();
        }
    }
}
