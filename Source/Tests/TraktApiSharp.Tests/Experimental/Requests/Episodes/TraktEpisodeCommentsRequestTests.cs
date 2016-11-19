namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
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
        public void TestTraktEpisodeCommentsRequestImplementsITraktValidatableInterface()
        {
            typeof(TraktEpisodeCommentsRequest).GetInterfaces().Should().Contain(typeof(ITraktValidatable));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestValidation()
        {
            var request = new TraktEpisodeCommentsRequest(null) { EpisodeNumber = 0 };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            request.EpisodeNumber = 1;
            act.ShouldNotThrow();
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

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestHasSortingProperty()
        {
            var sortingPropertyInfo = typeof(TraktEpisodeCommentsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Sorting")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktCommentSortOrder));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktEpisodeCommentsRequest).GetMethods()
                                                                .Where(m => m.Name == "GetUriPathParameters")
                                                                .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestUriParamsWithoutSeasonNumberAndEpisodeNumberAndSorting()
        {
            var request = new TraktEpisodeCommentsRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>()
            {
                ["season"] = $"{request.SeasonNumber}",
                ["episode"] = $"{request.EpisodeNumber}"
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestUriParamsWithoutSeasonNumberAndSorting()
        {
            var request = new TraktEpisodeCommentsRequest(null) { EpisodeNumber = 1 };
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            uriParams.Should().Contain(new Dictionary<string, object>()
            {
                ["season"] = $"{request.SeasonNumber}",
                ["episode"] = $"{request.EpisodeNumber}"
            });
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestUriParamsWithoutSorting()
        {
            var request = new TraktEpisodeCommentsRequest(null)
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

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktEpisodeCommentsRequestUriParamsWithUnspecifiedSorting()
        {
            var sorting = TraktCommentSortOrder.Unspecified;

            var request = new TraktEpisodeCommentsRequest(null)
            {
                SeasonNumber = 1,
                EpisodeNumber = 1,
                Sorting = sorting
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
        public void TestTraktEpisodeCommentsRequestUriParamsWithSorting()
        {
            var sorting = TraktCommentSortOrder.Newest;

            var request = new TraktEpisodeCommentsRequest(null)
            {
                SeasonNumber = 1,
                EpisodeNumber = 1,
                Sorting = sorting
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>()
            {
                ["season"] = $"{request.SeasonNumber}",
                ["episode"] = $"{request.EpisodeNumber}",
                ["sorting"] = sorting.UriName
            });
        }
    }
}
