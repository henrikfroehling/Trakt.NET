namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktShowsPopularRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsPopularRequestIsNotAbstract()
        {
            typeof(TraktShowsPopularRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsPopularRequestIsSealed()
        {
            typeof(TraktShowsPopularRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsPopularRequestIsSubclassOfATraktShowsRequest()
        {
            typeof(TraktShowsPopularRequest).IsSubclassOf(typeof(ATraktShowsRequest<TraktShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsPopularRequestHasAuthorizationNotRequired()
        {
            var request = new TraktShowsPopularRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsPopularRequestHasValidUriTemplate()
        {
            var request = new TraktShowsPopularRequest(null);
            request.UriTemplate.Should().Be("shows/popular{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}");
        }
    }
}
