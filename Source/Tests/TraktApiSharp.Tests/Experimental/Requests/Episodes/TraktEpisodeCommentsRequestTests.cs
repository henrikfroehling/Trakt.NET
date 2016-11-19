namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Episodes;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktEpisodeCommentsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestIsNotAbstract()
        {
            typeof(TraktEpisodeCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestIsSealed()
        {
            typeof(TraktEpisodeCommentsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestIsSubclassOfATraktPaginationGetByIdRequest()
        {
            typeof(TraktEpisodeCommentsRequest).IsSubclassOf(typeof(ATraktPaginationGetByIdRequest<TraktComment>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktEpisodeCommentsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestHasValidUriTemplate()
        {
            var request = new TraktEpisodeCommentsRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/comments{/sorting}{?page,limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktEpisodeCommentsRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestHasSeasonNumberProperty()
        {
            var sortingPropertyInfo = typeof(TraktEpisodeCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SeasonNumber")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestHasEpisodeNumberProperty()
        {
            var sortingPropertyInfo = typeof(TraktEpisodeCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "EpisodeNumber")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint));
        }
    }
}
