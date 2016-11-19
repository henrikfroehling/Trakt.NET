namespace TraktApiSharp.Tests.Experimental.Requests.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Seasons;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSeasonSingleRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestIsNotAbstract()
        {
            typeof(TraktSeasonSingleRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestIsSealed()
        {
            typeof(TraktSeasonSingleRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestIsSubclassOfATraktListGetByIdRequest()
        {
            typeof(TraktSeasonSingleRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktEpisode>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestHasAuthorizationNotRequired()
        {
            var request = new TraktSeasonSingleRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestHasValidUriTemplate()
        {
            var request = new TraktSeasonSingleRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktSeasonSingleRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }
    }
}
