namespace TraktNet.Tests.Modules.TraktSeasonsModule
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

    [Category("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        private readonly string GET_SEASON_STATISTICS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/stats";

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonStatistics()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, SEASON_STATISTICS_JSON);
            TraktResponse<ITraktStatistics> response = await client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktStatistics responseValue = response.Value;

            responseValue.Watchers.Should().Be(232215);
            responseValue.Plays.Should().Be(2719701);
            responseValue.Collectors.Should().Be(91770);
            responseValue.CollectedEpisodes.Should().Be(907358);
            responseValue.Comments.Should().Be(6);
            responseValue.Lists.Should().Be(250);
            responseValue.Votes.Should().Be(1149);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktSeasonNotFoundException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, SEASON_STATISTICS_JSON);

            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Seasons.GetSeasonStatisticsAsync(null, SEASON_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetSeasonStatisticsAsync(string.Empty, SEASON_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetSeasonStatisticsAsync("show id", SEASON_NR);
            act.Should().Throw<ArgumentException>();
        }
    }
}
