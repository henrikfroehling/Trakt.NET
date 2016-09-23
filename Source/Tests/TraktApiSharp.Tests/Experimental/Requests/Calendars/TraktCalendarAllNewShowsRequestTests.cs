namespace TraktApiSharp.Tests.Experimental.Requests.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktCalendarAllNewShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllNewShowsRequestIsNotAbstract()
        {
            typeof(TraktCalendarAllNewShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllNewShowsRequestIsSealed()
        {
            typeof(TraktCalendarAllNewShowsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllNewShowsRequestIsSubclassOfATraktCalendarAllRequest()
        {
            typeof(TraktCalendarAllNewShowsRequest).IsSubclassOf(typeof(ATraktCalendarAllRequest<TraktCalendarShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Shows")]
        public void TestTraktCalendarAllNewShowsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktCalendarAllNewShowsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

    }
}
