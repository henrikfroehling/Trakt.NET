namespace TraktApiSharp.Tests.Modules.TraktRecommendationsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Recommendations")]
    public partial class TraktRecommendationsModule_Tests
    {
        [Fact]
        public void Test_TraktRecommendationsModule_GetUserMovieRecommendations()
        {
            TestUtility.SetupMockPaginationResponseWithOAuth("recommendations/movies", MOVIE_RECOMMENDATIONS_JSON, 1, 10);

            var response = TestUtility.MOCK_TEST_CLIENT.Recommendations.GetMovieRecommendationsAsync().Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.Page.Should().Be(1u);
            response.Limit.Should().Be(10u);
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetUserMovieRecommendationsWithLimit()
        {
            const uint limit = 4U;

            TestUtility.SetupMockPaginationResponseWithOAuth($"recommendations/movies?limit={limit}", MOVIE_RECOMMENDATIONS_JSON, 1, limit);

            var response = TestUtility.MOCK_TEST_CLIENT.Recommendations.GetMovieRecommendationsAsync(limit).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.Page.Should().Be(1u);
            response.Limit.Should().Be(limit);
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetUserMovieRecommendationsWithExtendedInfo()
        {
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth($"recommendations/movies?extended={extendedInfo}",
                                                             MOVIE_RECOMMENDATIONS_JSON, 1, 10);

            var response = TestUtility.MOCK_TEST_CLIENT.Recommendations.GetMovieRecommendationsAsync(null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.Page.Should().Be(1u);
            response.Limit.Should().Be(10u);
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetUserMovieRecommendationsComplete()
        {
            const uint limit = 4U;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"recommendations/movies?extended={extendedInfo}&limit={limit}",
                MOVIE_RECOMMENDATIONS_JSON, 1, limit);

            var response = TestUtility.MOCK_TEST_CLIENT.Recommendations.GetMovieRecommendationsAsync(limit, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.Page.Should().Be(1u);
            response.Limit.Should().Be(limit);
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetUserMovieRecommendationsExceptions()
        {
            const string uri = "recommendations/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktPagedResponse<ITraktMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Recommendations.GetMovieRecommendationsAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
