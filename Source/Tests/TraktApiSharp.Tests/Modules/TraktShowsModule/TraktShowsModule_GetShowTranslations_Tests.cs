namespace TraktNet.Tests.Modules.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string GET_SHOW_TRANSLATIONS_URI = $"shows/{SHOW_ID}/translations";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowTranslations()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, SHOW_TRANSLATIONS_JSON);
            TraktListResponse<ITraktShowTranslation> response = await client.Shows.GetShowTranslationsAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowTranslations_With_LanguageCode()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SHOW_TRANSLATIONS_URI}/{ LANGUAGE_CODE}", SHOW_TRANSLATIONS_JSON);
            TraktListResponse<ITraktShowTranslation> response = await client.Shows.GetShowTranslationsAsync(SHOW_ID, LANGUAGE_CODE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktShowNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, SHOW_TRANSLATIONS_JSON);

            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowTranslationsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowTranslationsAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowTranslations_With_LanguageCode_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_TRANSLATIONS_URI, SHOW_TRANSLATIONS_JSON);

            Func<Task<TraktListResponse<ITraktShowTranslation>>> act = () => client.Shows.GetShowTranslationsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowTranslationsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowTranslationsAsync("show id");
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID, "eng");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Shows.GetShowTranslationsAsync(SHOW_ID, "e");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
