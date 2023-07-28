namespace TraktNet.Modules.Tests.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Seasons")]
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
        public async Task Test_TraktSeasonsModule_GetSeason_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}", SEASON_EPISODES_JSON);
            TraktListResponse<ITraktEpisode> response = await client.Seasons.GetSeasonAsync(TRAKT_SHOD_ID, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeason_With_ShowIds_TraktID()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}", SEASON_EPISODES_JSON);
            TraktListResponse<ITraktEpisode> response = await client.Seasons.GetSeasonAsync(showIds, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeason_With_ShowIds_Slug()
        {
            var showIds = new TraktShowIds
            {
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{SHOW_SLUG}/seasons/{SEASON_NR}", SEASON_EPISODES_JSON);
            TraktListResponse<ITraktEpisode> response = await client.Seasons.GetSeasonAsync(showIds, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeason_With_ShowIds()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID,
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}", SEASON_EPISODES_JSON);
            TraktListResponse<ITraktEpisode> response = await client.Seasons.GetSeasonAsync(showIds, SEASON_NR);

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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktSeasonNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktSeasonsModule_GetSeason_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, statusCode);

            try
            {
                await client.Seasons.GetSeasonAsync(SHOW_ID, SEASON_NR);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeason_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_URI, SEASON_EPISODES_JSON);

            Func<Task<TraktListResponse<ITraktEpisode>>> act = () => client.Seasons.GetSeasonAsync(default(ITraktShowIds), SEASON_NR);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonAsync(new TraktShowIds(), SEASON_NR);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonAsync(0, SEASON_NR);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
