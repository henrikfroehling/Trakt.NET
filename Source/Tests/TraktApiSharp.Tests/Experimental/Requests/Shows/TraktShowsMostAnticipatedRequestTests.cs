namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows.Common;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktShowsMostAnticipatedRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostAnticipatedRequestIsNotAbstract()
        {
            typeof(TraktShowsMostAnticipatedRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostAnticipatedRequestIsSealed()
        {
            typeof(TraktShowsMostAnticipatedRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostAnticipatedRequestIsSubclassOfATraktMoviesRequest()
        {
            typeof(TraktShowsMostAnticipatedRequest).IsSubclassOf(typeof(ATraktMoviesRequest<TraktMostAnticipatedShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostAnticipatedRequestHasAuthorizationNotRequired()
        {
            var request = new TraktShowsMostAnticipatedRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostAnticipatedRequestHasValidUriTemplate()
        {
            var request = new TraktShowsMostAnticipatedRequest(null);
            request.UriTemplate.Should().Be("shows/anticipated{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}");
        }
    }
}
