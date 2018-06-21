namespace TraktNet.Tests.Modules.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private readonly string GET_MOVIE_PEOPLE_URI = $"movies/{MOVIE_ID}/people";

        [Fact]
        public async Task Test_TraktMoviesModule_GetMoviePeople()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, MOVIE_PEOPLE_JSON);
            TraktResponse<ITraktCastAndCrew> response = await client.Movies.GetMoviePeopleAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCastAndCrew responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Art.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Crew.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Directing.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Sound.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Camera.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Lighting.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Editing.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMoviePeople_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_PEOPLE_URI}?extended={EXTENDED_INFO}", MOVIE_PEOPLE_JSON);
            TraktResponse<ITraktCastAndCrew> response = await client.Movies.GetMoviePeopleAsync(MOVIE_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCastAndCrew responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Art.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Crew.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Directing.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Sound.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Camera.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Lighting.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Editing.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktMovieNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, MOVIE_PEOPLE_JSON);

            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Movies.GetMoviePeopleAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMoviePeopleAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMoviePeopleAsync("movie id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
