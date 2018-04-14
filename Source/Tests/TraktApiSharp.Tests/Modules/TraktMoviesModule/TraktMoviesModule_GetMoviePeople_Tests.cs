namespace TraktApiSharp.Tests.Modules.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeople()
        {
            const string movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/people", MOVIE_PEOPLE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(movieId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

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
        public void Test_TraktMoviesModule_GetMoviePeopleWithExtendedInfo()
        {
            const string movieId = "94024";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/people?extended={extendedInfo}", MOVIE_PEOPLE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(movieId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

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
        public void Test_TraktMoviesModule_GetMoviePeopleExceptions()
        {
            const string movieId = "94024";
            var uri = $"movies/{movieId}/people";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktCastAndCrew>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(movieId);
            act.Should().Throw<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMoviePeopleArgumentExceptions()
        {
            const string movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/people", MOVIE_PEOPLE_JSON);

            Func<Task<TraktResponse<ITraktCastAndCrew>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync("movie id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
