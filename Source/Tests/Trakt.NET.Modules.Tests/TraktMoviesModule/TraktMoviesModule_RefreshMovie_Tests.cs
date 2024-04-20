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
        private readonly string REFRESH_MOVIE_URI = $"movies/{MOVIE_ID}/refresh";

        [Fact]
        public async Task Test_TraktMoviesModule_RefreshMovie()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REFRESH_MOVIE_URI, HttpStatusCode.Created);
            TraktNoContentResponse response = await client.Movies.RefreshMovieAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktMoviesModule_RefreshMovie_With_TraktID()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"movies/{TRAKT_MOVIE_ID}/refresh", HttpStatusCode.Created);
            TraktNoContentResponse response = await client.Movies.RefreshMovieAsync(TRAKT_MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktMoviesModule_RefreshMovie_With_MovieIds_TraktID()
        {
            var movieIds = new TraktMovieIds
            {
                Trakt = TRAKT_MOVIE_ID
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"movies/{TRAKT_MOVIE_ID}/refresh", HttpStatusCode.Created);
            TraktNoContentResponse response = await client.Movies.RefreshMovieAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktMoviesModule_RefreshMovie_With_MovieIds_Slug()
        {
            var movieIds = new TraktMovieIds
            {
                Slug = MOVIE_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"movies/{MOVIE_SLUG}/refresh", HttpStatusCode.Created);
            TraktNoContentResponse response = await client.Movies.RefreshMovieAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktMoviesModule_RefreshMovie_With_MovieIds()
        {
            var movieIds = new TraktMovieIds
            {
                Trakt = TRAKT_MOVIE_ID,
                Slug = MOVIE_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"movies/{TRAKT_MOVIE_ID}/refresh", HttpStatusCode.Created);
            TraktNoContentResponse response = await client.Movies.RefreshMovieAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktMoviesModule_RefreshMovie_With_Movie()
        {
            var movie = new TraktMovie
            {
                Ids = new TraktMovieIds
                {
                    Trakt = TRAKT_MOVIE_ID,
                    Slug = MOVIE_SLUG
                }
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"movies/{TRAKT_MOVIE_ID}/refresh", HttpStatusCode.Created);
            TraktNoContentResponse response = await client.Movies.RefreshMovieAsync(movie);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
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
        [InlineData((HttpStatusCode)426, typeof(TraktFailedVIPValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktMoviesModule_RefreshMovie_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REFRESH_MOVIE_URI, statusCode);

            try
            {
                await client.Movies.RefreshMovieAsync(MOVIE_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktMoviesModule_RefreshMovie_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REFRESH_MOVIE_URI, HttpStatusCode.Created);

            Func<Task<TraktNoContentResponse>> act = () => client.Movies.RefreshMovieAsync(default(ITraktMovieIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Movies.RefreshMovieAsync(default(ITraktMovie));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Movies.RefreshMovieAsync(new TraktMovieIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.RefreshMovieAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
