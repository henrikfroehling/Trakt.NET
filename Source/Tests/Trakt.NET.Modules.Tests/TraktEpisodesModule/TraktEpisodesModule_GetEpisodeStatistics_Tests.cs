namespace TraktNet.Modules.Tests.TraktEpisodesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Episodes")]
    public partial class TraktEpisodesModule_Tests
    {
        private readonly string GET_EPISODE_STATISTICS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/stats";

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeStatistics()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, EPISODE_STATISTICS_JSON);
            TraktResponse<ITraktStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktStatistics responseValue = response.Value;

            responseValue.Watchers.Should().Be(233273);
            responseValue.Plays.Should().Be(303464);
            responseValue.Collectors.Should().Be(92759);
            responseValue.CollectedEpisodes.Should().NotHaveValue();
            responseValue.Comments.Should().Be(4);
            responseValue.Lists.Should().Be(418);
            responseValue.Votes.Should().Be(3919);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeStatistics_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/stats",
                EPISODE_STATISTICS_JSON);

            TraktResponse<ITraktStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(TRAKT_SHOD_ID, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeStatistics_With_ShowIds_TraktID()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/stats",
                EPISODE_STATISTICS_JSON);

            TraktResponse<ITraktStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(showIds, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeStatistics_With_ShowIds_Slug()
        {
            var showIds = new TraktShowIds
            {
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{SHOW_SLUG}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/stats",
                EPISODE_STATISTICS_JSON);

            TraktResponse<ITraktStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(showIds, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeStatistics_With_ShowIds()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID,
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/stats",
                EPISODE_STATISTICS_JSON);

            TraktResponse<ITraktStatistics> response = await client.Episodes.GetEpisodeStatisticsAsync(showIds, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktEpisodeNotFoundException))]
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
        public async Task Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, statusCode);

            try
            {
                await client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, EPISODE_STATISTICS_JSON);

            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(default(ITraktShowIds), SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeStatisticsAsync(new TraktShowIds(), SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeStatisticsAsync(0, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
