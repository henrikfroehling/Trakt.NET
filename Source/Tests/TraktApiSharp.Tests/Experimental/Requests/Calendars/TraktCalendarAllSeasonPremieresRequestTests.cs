namespace TraktApiSharp.Tests.Experimental.Requests.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktCalendarAllSeasonPremieresRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Seasons")]
        public void TestTraktCalendarAllSeasonPremieresRequestIsNotAbstract()
        {
            typeof(TraktCalendarAllSeasonPremieresRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Seasons")]
        public void TestTraktCalendarAllSeasonPremieresRequestIsSealed()
        {
            typeof(TraktCalendarAllSeasonPremieresRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Seasons")]
        public void TestTraktCalendarAllSeasonPremieresRequestIsSubclassOfATraktCalendarAllRequest()
        {
            typeof(TraktCalendarAllSeasonPremieresRequest).IsSubclassOf(typeof(ATraktCalendarAllRequest<TraktCalendarShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Seasons")]
        public void TestTraktCalendarAllSeasonPremieresRequestHasAuthorizationNotRequired()
        {
            var request = new TraktCalendarAllSeasonPremieresRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }
    }
}
