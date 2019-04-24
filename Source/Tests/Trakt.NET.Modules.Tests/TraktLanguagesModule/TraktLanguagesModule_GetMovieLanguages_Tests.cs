namespace TraktNet.Modules.Tests.TraktLanguagesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Languages")]
    public partial class TraktLanguagesModule_Tests
    {
        private const string LANGUAGES_MOVIES_URI = "languages/movies";

        [Fact]
        public async Task Test_TraktLanguagesModule_GetMovieLanguages()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, LANGUAGES_JSON);
            TraktListResponse<ITraktLanguage> response = await client.Languages.GetMovieLanguagesAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_ServerErrorException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetMovieLanguages_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_MOVIES_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetMovieLanguagesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
