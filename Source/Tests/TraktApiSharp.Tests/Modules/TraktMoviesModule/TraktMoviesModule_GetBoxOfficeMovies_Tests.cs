namespace TraktApiSharp.Tests.Modules.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private const string GET_BOX_OFFICE_MOVIES_URI = "movies/boxoffice";

        [Fact]
        public async Task Test_TraktMoviesModule_GetBoxOfficeMovies()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, BOX_OFFICE_MOVIES_JSON);
            TraktListResponse<ITraktBoxOfficeMovie> response = await client.Movies.GetBoxOfficeMoviesAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetBoxOfficeMovies_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_BOX_OFFICE_MOVIES_URI}?extended={EXTENDED_INFO}", BOX_OFFICE_MOVIES_JSON);
            TraktListResponse<ITraktBoxOfficeMovie> response = await client.Movies.GetBoxOfficeMoviesAsync(EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetBoxOfficeMovies_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_BOX_OFFICE_MOVIES_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act = () => client.Movies.GetBoxOfficeMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
