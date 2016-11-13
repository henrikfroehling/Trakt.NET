namespace TraktApiSharp.Tests.Experimental.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars.OAuth;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktCalendarUserDVDMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarUserDVDMoviesRequestIsNotAbstract()
        {
            typeof(TraktCalendarUserDVDMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarUserDVDMoviesRequestIsSealed()
        {
            typeof(TraktCalendarUserDVDMoviesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarUserDVDMoviesRequestIsSubclassOfATraktCalendarUserRequest()
        {
            typeof(TraktCalendarUserDVDMoviesRequest).IsSubclassOf(typeof(ATraktCalendarUserRequest<TraktCalendarMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarUserDVDMoviesRequestHasAuthorizationRequired()
        {
            var request = new TraktCalendarUserDVDMoviesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarUserDVDMoviesRequestHasValidUriTemplate()
        {
            var request = new TraktCalendarUserDVDMoviesRequest(null);
            request.UriTemplate.Should().Be("calendars/my/dvd{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }
    }
}
