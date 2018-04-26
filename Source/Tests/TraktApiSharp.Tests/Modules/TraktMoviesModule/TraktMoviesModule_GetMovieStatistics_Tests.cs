namespace TraktApiSharp.Tests.Modules.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Movies")]
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

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktMovieNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieStatistics_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_STATISTICS_URI, MOVIE_STATISTICS_JSON);

            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Movies.GetMovieStatisticsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieStatisticsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieStatisticsAsync("movie id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
