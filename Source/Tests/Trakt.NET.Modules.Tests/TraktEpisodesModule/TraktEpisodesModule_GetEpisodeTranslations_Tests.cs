namespace TraktNet.Modules.Tests.TraktEpisodesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Episodes")]
    public partial class TraktEpisodesModule_Tests
    {
        private readonly string GET_EPISODE_TRANSLATIONS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/translations";

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeTranslations()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, EPISODE_TRANSLATIONS_JSON);
            TraktListResponse<ITraktEpisodeTranslation> response = await client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktEpisodeNotFoundException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeTranslations_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_TRANSLATIONS_URI, EPISODE_TRANSLATIONS_JSON);

            Func<Task<TraktListResponse<ITraktEpisodeTranslation>>> act = () => client.Episodes.GetEpisodeTranslationsAsync(null, SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeTranslationsAsync(string.Empty, SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeTranslationsAsync("show id", SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR, "e");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Episodes.GetEpisodeTranslationsAsync(SHOW_ID, SEASON_NR, EPISODE_NR, "eng");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
