namespace TraktApiSharp.Tests.Experimental.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars.OAuth;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests;

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

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserSeasonPremieresRequestHasAuthorizationRequired()
        {
            var request = new TraktCalendarUserSeasonPremieresRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarUserSeasonPremieresRequestHasValidUriTemplate()
        {
            var request = new TraktCalendarUserSeasonPremieresRequest(null);
            request.UriTemplate.Should().Be("calendars/my/shows/premieres{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }
    }
}
