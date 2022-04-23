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

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private readonly string GET_MOVIE_TRANSLATIONS_URI = $"movies/{MOVIE_ID}/translations";

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieTranslations()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, MOVIE_TRANSLATIONS_JSON);
            TraktListResponse<ITraktMovieTranslation> response = await client.Movies.GetMovieTranslationsAsync(MOVIE_ID);

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
        public async Task Test_TraktMoviesModule_GetMovieTranslations_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, statusCode);

            try
            {
                await client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieTranslations_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, MOVIE_TRANSLATIONS_JSON);

            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieTranslationsAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieTranslationsAsync("movie id");
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieTranslations_Single()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_TRANSLATIONS_URI}/{LANGUAGE_CODE}", MOVIE_TRANSLATIONS_JSON);
            TraktListResponse<ITraktMovieTranslation> response = await client.Movies.GetMovieTranslationsAsync(MOVIE_ID, LANGUAGE_CODE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieTranslations_Single_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_TRANSLATIONS_URI}/{LANGUAGE_CODE}", MOVIE_TRANSLATIONS_JSON);

            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieTranslationsAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieTranslationsAsync("movie id");
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID, "eng");
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();

            act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID, "e");
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }
    }
}
