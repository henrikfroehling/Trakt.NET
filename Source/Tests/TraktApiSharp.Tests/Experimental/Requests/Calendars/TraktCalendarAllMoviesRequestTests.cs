namespace TraktApiSharp.Tests.Experimental.Requests.Calendars
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktCalendarAllMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestIsNotAbstract()
        {
            typeof(TraktCalendarAllMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestIsSealed()
        {
            typeof(TraktCalendarAllMoviesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestIsSubclassOfATraktCalendarAllRequest()
        {
            typeof(TraktCalendarAllMoviesRequest).IsSubclassOf(typeof(ATraktCalendarAllRequest<TraktCalendarMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestHasAuthorizationNotRequired()
        {
            var request = new TraktCalendarAllMoviesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarAllMoviesRequestHasValidUriTemplate()
        {
            var request = new TraktCalendarAllMoviesRequest(null);
            request.UriTemplate.Should().Be("calendars/all/movies{/start_date}{/days}{?extended,query,years,genres,languages,countries,runtimes,ratings}");
        }
    }
}
