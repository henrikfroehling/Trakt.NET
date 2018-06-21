namespace TraktNet.Tests.Modules.TraktEpisodesModule
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

    [Category("Modules.Episodes")]
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
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktEpisodeNotFoundException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeStatistics_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_STATISTICS_URI, EPISODE_STATISTICS_JSON);

            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Episodes.GetEpisodeStatisticsAsync(null, SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeStatisticsAsync(string.Empty, SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeStatisticsAsync("show id", SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeStatisticsAsync(SHOW_ID, SEASON_NR, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
