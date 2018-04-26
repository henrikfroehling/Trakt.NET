namespace TraktApiSharp.Tests.Modules.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
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
        private readonly string GET_MOVIE_RATINGS_URI = $"movies/{MOVIE_ID}/ratings";

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieRatings()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, MOVIE_RATINGS_JSON);
            TraktResponse<ITraktRating> response = await client.Movies.GetMovieRatingsAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktRating responseValue = response.Value;

            responseValue.Rating.Should().Be(8.31325f);
            responseValue.Votes.Should().Be(10359);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  185 }, { "2", 28 }, { "3", 34 }, { "4", 89 }, { "5", 184 },
                { "6",  630 }, { "7", 1244 }, { "8", 2509 }, { "9", 2622 }, { "10", 2834 }
            };

            responseValue.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktMovieNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieRatings_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, MOVIE_RATINGS_JSON);

            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieRatingsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieRatingsAsync("movie id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
