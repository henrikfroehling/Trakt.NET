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
        private readonly string GET_MOVIE_RELEASES_URI = $"movies/{MOVIE_ID}/releases";

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieReleases()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, MOVIE_RELEASES_JSON);
            TraktListResponse<ITraktMovieRelease> response = await client.Movies.GetMovieReleasesAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
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
        public async Task Test_TraktMoviesModule_GetMovieReleases_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, statusCode);

            try
            {
                await client.Movies.GetMovieReleasesAsync(MOVIE_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieReleases_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, MOVIE_RELEASES_JSON);

            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieReleasesAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieReleasesAsync("movie id");
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieReleases_Single()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_RELEASES_URI}/{COUNTRY_CODE}", MOVIE_RELEASES_JSON);
            TraktListResponse<ITraktMovieRelease> response = await client.Movies.GetMovieReleasesAsync(MOVIE_ID, COUNTRY_CODE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieReleases_Single_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_RELEASES_URI}/{COUNTRY_CODE}", MOVIE_RELEASES_JSON);

            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieReleasesAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieReleasesAsync("movie id");
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID, "usa");
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();

            act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID, "u");
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }
    }
}
