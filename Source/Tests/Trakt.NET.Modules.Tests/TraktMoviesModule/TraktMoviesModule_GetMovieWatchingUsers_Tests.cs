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
    using TraktNet.Objects.Get.Users;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private readonly string GET_MOVIE_WATCHING_USERS_URI = $"movies/{MOVIE_ID}/watching";

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieWatchingUsers()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, MOVIE_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieWatchingUsers_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"movies/{TRAKT_MOVIE_ID}/watching", MOVIE_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Movies.GetMovieWatchingUsersAsync(TRAKT_MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieWatchingUsers_With_MovieIds_TraktID()
        {
            var movieIds = new TraktMovieIds
            {
                Trakt = TRAKT_MOVIE_ID
            };

            TraktClient client = TestUtility.GetMockClient($"movies/{TRAKT_MOVIE_ID}/watching", MOVIE_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Movies.GetMovieWatchingUsersAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieWatchingUsers_With_MovieIds_Slug()
        {
            var movieIds = new TraktMovieIds
            {
                Slug = MOVIE_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"movies/{MOVIE_SLUG}/watching", MOVIE_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Movies.GetMovieWatchingUsersAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieWatchingUsers_With_MovieIds()
        {
            var movieIds = new TraktMovieIds
            {
                Trakt = TRAKT_MOVIE_ID,
                Slug = MOVIE_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"movies/{TRAKT_MOVIE_ID}/watching", MOVIE_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Movies.GetMovieWatchingUsersAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieWatchingUsers_With_Movie()
        {
            var movie = new TraktMovie
            {
                Ids = new TraktMovieIds
                {
                    Trakt = TRAKT_MOVIE_ID,
                    Slug = MOVIE_SLUG
                }
            };

            TraktClient client = TestUtility.GetMockClient($"movies/{TRAKT_MOVIE_ID}/watching", MOVIE_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Movies.GetMovieWatchingUsersAsync(movie);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieWatchingUsers_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_WATCHING_USERS_URI}?extended={EXTENDED_INFO}", MOVIE_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Should().NotBeNull().And.HaveCount(3);
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
        public async Task Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, statusCode);

            try
            {
                await client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, MOVIE_WATCHING_USERS_JSON);

            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(default(ITraktMovieIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Movies.GetMovieWatchingUsersAsync(default(ITraktMovie));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Movies.GetMovieWatchingUsersAsync(new TraktMovieIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieWatchingUsersAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
