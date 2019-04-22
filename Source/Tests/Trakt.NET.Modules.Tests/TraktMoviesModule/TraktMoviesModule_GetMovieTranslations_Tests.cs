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

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktMovieNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieTranslations_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_TRANSLATIONS_URI, MOVIE_TRANSLATIONS_JSON);

            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieTranslationsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieTranslationsAsync("movie id");
            act.Should().Throw<ArgumentException>();
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
        public void Test_TraktMoviesModule_GetMovieTranslations_Single_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_TRANSLATIONS_URI}/{LANGUAGE_CODE}", MOVIE_TRANSLATIONS_JSON);

            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act = () => client.Movies.GetMovieTranslationsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieTranslationsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieTranslationsAsync("movie id");
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID, "eng");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Movies.GetMovieTranslationsAsync(MOVIE_ID, "e");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
