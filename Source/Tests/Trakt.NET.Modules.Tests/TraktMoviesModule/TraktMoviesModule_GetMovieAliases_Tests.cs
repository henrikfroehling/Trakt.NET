namespace TraktNet.Modules.Tests.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private readonly string GET_MOVIE_ALIASES_URI = $"movies/{MOVIE_ID}/aliases";

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieAliases()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, MOVIE_ALIASES_JSON);
            TraktListResponse<ITraktMovieAlias> response = await client.Movies.GetMovieAliasesAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieAliases_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"movies/{TRAKT_MOVIE_ID}/aliases", MOVIE_ALIASES_JSON);
            TraktListResponse<ITraktMovieAlias> response = await client.Movies.GetMovieAliasesAsync(TRAKT_MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieAliases_With_MovieIds_TraktID()
        {
            var movieIds = new TraktMovieIds
            {
                Trakt = TRAKT_MOVIE_ID
            };

            TraktClient client = TestUtility.GetMockClient($"movies/{TRAKT_MOVIE_ID}/aliases", MOVIE_ALIASES_JSON);
            TraktListResponse<ITraktMovieAlias> response = await client.Movies.GetMovieAliasesAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieAliases_With_MovieIds_Slug()
        {
            var movieIds = new TraktMovieIds
            {
                Slug = MOVIE_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"movies/{MOVIE_SLUG}/aliases", MOVIE_ALIASES_JSON);
            TraktListResponse<ITraktMovieAlias> response = await client.Movies.GetMovieAliasesAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieAliases_With_MovieIds()
        {
            var movieIds = new TraktMovieIds
            {
                Trakt = TRAKT_MOVIE_ID,
                Slug = MOVIE_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"movies/{TRAKT_MOVIE_ID}/aliases", MOVIE_ALIASES_JSON);
            TraktListResponse<ITraktMovieAlias> response = await client.Movies.GetMovieAliasesAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
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
        public async Task Test_TraktMoviesModule_GetMovieAliases_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, statusCode);

            try
            {
                await client.Movies.GetMovieAliasesAsync(MOVIE_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieAliases_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, MOVIE_ALIASES_JSON);

            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(default(ITraktMovieIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Movies.GetMovieAliasesAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
