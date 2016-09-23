namespace TraktApiSharp.Tests.Experimental.Requests.Calendars.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Calendars.OAuth;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktCalendarUserMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarUserMoviesRequestIsNotAbstract()
        {
            typeof(TraktCalendarUserMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarUserMoviesRequestIsSealed()
        {
            typeof(TraktCalendarUserMoviesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarUserMoviesRequestIsSubclassOfATraktCalendarAllRequest()
        {
            typeof(TraktCalendarUserMoviesRequest).IsSubclassOf(typeof(ATraktCalendarUserRequest<TraktCalendarMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktCalendarUserMoviesRequestHasAuthorizationRequired()
        {
            var request = new TraktCalendarUserMoviesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }
    }
}
