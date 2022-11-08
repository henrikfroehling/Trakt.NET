﻿namespace TraktNet.Modules.Tests.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private readonly string GET_MOVIE_STATISTICS_URI = $"movies/{MOVIE_ID}/stats";

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieStatistics()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, MOVIE_STATISTICS_JSON);
            TraktResponse<ITraktStatistics> response = await client.Movies.GetMovieStatisticsAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();

            ITraktStatistics responseValue = response.Value;

            responseValue.Watchers.Should().Be(40619);
            responseValue.Plays.Should().Be(64620);
            responseValue.Collectors.Should().Be(17519);
            responseValue.CollectedEpisodes.Should().NotHaveValue();
            responseValue.Comments.Should().Be(99);
            responseValue.Lists.Should().Be(17089);
            responseValue.Votes.Should().Be(10359);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktMovieNotFoundException))]
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
        public async Task Test_TraktMoviesModule_GetMovieStatistics_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, statusCode);

            try
            {
                await client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
