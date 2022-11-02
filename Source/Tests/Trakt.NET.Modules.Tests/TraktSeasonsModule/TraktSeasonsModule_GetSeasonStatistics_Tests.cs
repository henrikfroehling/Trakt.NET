namespace TraktNet.Modules.Tests.TraktSeasonsModule
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

    [TestCategory("Modules.Seasons")]
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
        public async Task Test_TraktSeasonsModule_GetSeasonStatistics_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_STATISTICS_URI, statusCode);

            try
            {
                await client.Seasons.GetSeasonStatisticsAsync(SHOW_ID, SEASON_NR);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
