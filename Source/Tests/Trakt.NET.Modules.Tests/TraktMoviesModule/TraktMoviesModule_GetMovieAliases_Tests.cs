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
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktMovieNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieAliases_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_ALIASES_URI, MOVIE_ALIASES_JSON);

            Func<Task<TraktListResponse<ITraktMovieAlias>>> act = () => client.Movies.GetMovieAliasesAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieAliasesAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieAliasesAsync("movie id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
