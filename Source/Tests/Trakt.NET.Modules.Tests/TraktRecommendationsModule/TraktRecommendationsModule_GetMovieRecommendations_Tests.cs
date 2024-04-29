namespace TraktNet.Modules.Tests.TraktRecommendationsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Recommendations")]
    public partial class TraktRecommendationsModule_Tests
    {
        private const string GET_MOVIE_RECOMMENDATIONS_URI = "recommendations/movies";

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_MOVIE_RECOMMENDATIONS_URI,
                                                                MOVIE_RECOMMENDATIONS_JSON, 1, 10, 1, MOVIE_RECOMMENDATIONS_COUNT);

            TraktPagedResponse<ITraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations_With_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_MOVIE_RECOMMENDATIONS_URI}?page={PAGE}",
                                                                MOVIE_RECOMMENDATIONS_JSON, PAGE, 10, 1, MOVIE_RECOMMENDATIONS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(pagedParameters: pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations_With_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_MOVIE_RECOMMENDATIONS_URI}?limit={LIMIT}",
                                                                MOVIE_RECOMMENDATIONS_JSON, 1, LIMIT, 1, MOVIE_RECOMMENDATIONS_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(pagedParameters: pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations_With_IgnoreCollected()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_MOVIE_RECOMMENDATIONS_URI}?ignore_collected=true",
                                                                MOVIE_RECOMMENDATIONS_JSON, 1, 10, 1, MOVIE_RECOMMENDATIONS_COUNT);

            TraktPagedResponse<ITraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(ignoreCollected: true);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations_With_IgnoreWatchlisted()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_MOVIE_RECOMMENDATIONS_URI}?ignore_watchlisted=true",
                                                                MOVIE_RECOMMENDATIONS_JSON, 1, 10, 1, MOVIE_RECOMMENDATIONS_COUNT);

            TraktPagedResponse<ITraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(ignoreWatchlisted: true);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_MOVIE_RECOMMENDATIONS_URI}?extended={EXTENDED_INFO}",
                                                                MOVIE_RECOMMENDATIONS_JSON, 1, 10, 1, MOVIE_RECOMMENDATIONS_COUNT);

            TraktPagedResponse<ITraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(extendedInfo: EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_MOVIE_RECOMMENDATIONS_URI}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                MOVIE_RECOMMENDATIONS_JSON, PAGE, LIMIT, 1, MOVIE_RECOMMENDATIONS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_MOVIE_RECOMMENDATIONS_URI}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                MOVIE_RECOMMENDATIONS_JSON, 2, LIMIT, 5, MOVIE_RECOMMENDATIONS_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_MOVIE_RECOMMENDATIONS_URI}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                MOVIE_RECOMMENDATIONS_JSON, 2, LIMIT, 2, MOVIE_RECOMMENDATIONS_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_MOVIE_RECOMMENDATIONS_URI}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                MOVIE_RECOMMENDATIONS_JSON, 1, LIMIT, 2, MOVIE_RECOMMENDATIONS_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_MOVIE_RECOMMENDATIONS_URI}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                MOVIE_RECOMMENDATIONS_JSON, 1, LIMIT, 1, MOVIE_RECOMMENDATIONS_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_MOVIE_RECOMMENDATIONS_URI}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                MOVIE_RECOMMENDATIONS_JSON, 2, LIMIT, 2, MOVIE_RECOMMENDATIONS_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetMockClient(client, $"{GET_MOVIE_RECOMMENDATIONS_URI}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                MOVIE_RECOMMENDATIONS_JSON, 1, LIMIT, 2, MOVIE_RECOMMENDATIONS_COUNT);

            response = await response.GetPreviousPageAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_MOVIE_RECOMMENDATIONS_URI}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                MOVIE_RECOMMENDATIONS_JSON, 1, LIMIT, 2, MOVIE_RECOMMENDATIONS_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktRecommendedMovie> response = await client.Recommendations.GetMovieRecommendationsAsync(true, true, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetMockClient(client, $"{GET_MOVIE_RECOMMENDATIONS_URI}" +
                $"?ignore_collected=true&ignore_watchlisted=true&extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                MOVIE_RECOMMENDATIONS_JSON, 2, LIMIT, 2, MOVIE_RECOMMENDATIONS_COUNT);

            response = await response.GetNextPageAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(MOVIE_RECOMMENDATIONS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(MOVIE_RECOMMENDATIONS_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktRecommendationsModule_GetMovieRecommendations_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_MOVIE_RECOMMENDATIONS_URI, statusCode);

            try
            {
                await client.Recommendations.GetMovieRecommendationsAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
