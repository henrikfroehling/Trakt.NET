namespace TraktApiSharp.Tests.Modules.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        private readonly string GET_SEASON_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}";

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeason()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, SEASON_EPISODES_JSON);
            TraktListResponse<ITraktEpisode> response = await client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeason_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_URI}?extended={EXTENDED_INFO}",
                                                           SEASON_EPISODES_JSON);

            TraktListResponse<ITraktEpisode> response = await client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeason_With_Translations()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_URI}?translations={TRANSLATION_LANGUAGE_CODE}",
                                                           SEASON_EPISODES_JSON);

            TraktListResponse<ITraktEpisode> response = await client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR, null, TRANSLATION_LANGUAGE_CODE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeason_With_ExtendedInfo_And_Translations()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_URI}?extended={EXTENDED_INFO}&translations={TRANSLATION_LANGUAGE_CODE}",
                                                           SEASON_EPISODES_JSON);

            TraktListResponse<ITraktEpisode> response = await client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR, EXTENDED_INFO, TRANSLATION_LANGUAGE_CODE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeason_With_All_Translations()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_URI}?translations=all",
                                                           SEASON_EPISODES_JSON);

            TraktListResponse<ITraktEpisode> response = await client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR, null, "all");

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeason_With_ExtendedInfo_And_All_Translations()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_URI}?extended={EXTENDED_INFO}&translations=all",
                                                           SEASON_EPISODES_JSON);

            TraktListResponse<ITraktEpisode> response = await client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR, EXTENDED_INFO, "all");

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktSeasonNotFoundException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeason_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, SEASON_EPISODES_JSON);

            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(null, SEASON_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetSeasonAsync(string.Empty, SEASON_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetSeasonAsync("show id", SEASON_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR, null, "eng");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR, null, "e");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR, null, "all");
            act.Should().NotThrow();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetMultipleSeasons_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, SEASON_EPISODES_JSON);

            Func<Task<IEnumerable<TraktListResponse<ITraktEpisode>>>> act = () => client.Seasons.GetMultipleSeasonsAsync(null);
            act.Should().NotThrow();

            var queryParams = new TraktMultipleSeasonsQueryParams();
            act = () => client.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().NotThrow();

            queryParams = new TraktMultipleSeasonsQueryParams { { null, SEASON_NR } };
            act = () => client.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().Throw<ArgumentException>();

            queryParams = new TraktMultipleSeasonsQueryParams { { string.Empty, SEASON_NR } };
            act = () => client.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().Throw<ArgumentException>();

            queryParams = new TraktMultipleSeasonsQueryParams { { "show id", SEASON_NR } };
            act = () => client.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().Throw<ArgumentException>();

            queryParams = new TraktMultipleSeasonsQueryParams { { SHOW_ID, SEASON_NR, "eng" } };
            act = () => client.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().Throw<ArgumentOutOfRangeException>();

            queryParams = new TraktMultipleSeasonsQueryParams { { SHOW_ID, SEASON_NR, "e" } };
            act = () => client.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().Throw<ArgumentOutOfRangeException>();

            client = TestUtility.GetMockClient($"{GET_SEASON_URI}?translations=all", SEASON_EPISODES_JSON);

            queryParams = new TraktMultipleSeasonsQueryParams { { SHOW_ID, SEASON_NR, "all" } };
            act = () => client.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.Should().NotThrow();
        }
    }
}
