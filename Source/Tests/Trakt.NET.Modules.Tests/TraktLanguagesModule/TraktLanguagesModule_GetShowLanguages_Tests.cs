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
        private const string LANGUAGES_SHOWS_URI = "languages/shows";

        [Fact]
        public async Task Test_TraktLanguagesModule_GetShowLanguages()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, LANGUAGES_JSON);
            TraktListResponse<ITraktLanguage> response = await client.Languages.GetShowLanguagesAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_ServerErrorException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktLanguagesModule_GetShowLanguages_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(LANGUAGES_SHOWS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktLanguage>>> act = () => client.Languages.GetShowLanguagesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
