namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Episodes;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktEpisodeRatingsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestIsNotAbstract()
        {
            typeof(TraktEpisodeRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestIsSealed()
        {
            typeof(TraktEpisodeRatingsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktEpisodeRatingsRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktRating>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktEpisodeRatingsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestHasValidUriTemplate()
        {
            var request = new TraktEpisodeRatingsRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/ratings");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktEpisodeRatingsRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestImplementsITraktValidatableInterface()
        {
            typeof(TraktEpisodeRatingsRequest).GetInterfaces().Should().Contain(typeof(ITraktValidatable));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestValidation()
        {
            var request = new TraktEpisodeRatingsRequest(null) { EpisodeNumber = 0 };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            request.EpisodeNumber = 1;
            act.ShouldNotThrow();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestHasSeasonNumberProperty()
        {
            var sortingPropertyInfo = typeof(TraktEpisodeRatingsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SeasonNumber")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestHasEpisodeNumberProperty()
        {
            var sortingPropertyInfo = typeof(TraktEpisodeRatingsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "EpisodeNumber")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktEpisodeRatingsRequest).GetMethods()
                                                               .Where(m => m.Name == "GetUriPathParameters")
                                                               .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestUriParamsWithoutSeasonNumberAndEpisodeNumber()
        {
            var request = new TraktEpisodeRatingsRequest(null);

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>()
            {
                ["season"] = $"{request.SeasonNumber}",
                ["episode"] = $"{request.EpisodeNumber}"
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestUriParamsWithoutEpisodeNumber()
        {
            var request = new TraktEpisodeRatingsRequest(null)
            {
                SeasonNumber = 1
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>()
            {
                ["season"] = $"{request.SeasonNumber}",
                ["episode"] = $"{request.EpisodeNumber}"
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktEpisodeRatingsRequestUriParams()
        {
            var request = new TraktEpisodeRatingsRequest(null)
            {
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>()
            {
                ["season"] = $"{request.SeasonNumber}",
                ["episode"] = $"{request.EpisodeNumber}"
            });
        }
    }
}
