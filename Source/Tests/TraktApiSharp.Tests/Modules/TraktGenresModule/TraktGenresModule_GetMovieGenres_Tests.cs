namespace TraktApiSharp.Tests.Modules.TraktGenresModule
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Genres")]
    public partial class TraktGenresModule_Tests
    {
        private const string GENRES_MOVIES_URI = "genres/movies";

        [Fact]
        public async Task Test_TraktGenresModule_GetMovieGenres()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, MOVIE_GENRES_JSON);
            var response = await client.Genres.GetMovieGenresAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(32);
            response.Value.All(g => g.Type == TraktGenreType.Movies).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_ServerErrorException()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktGenresModule_GetMovieGenres_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GENRES_MOVIES_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktGenre>>> act = () => client.Genres.GetMovieGenresAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
