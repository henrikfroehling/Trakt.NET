namespace TraktApiSharp.Tests.Modules.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatistics()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/stats", SEASON_STATISTICS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync(showId, seasonNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Watchers.Should().Be(232215);
            responseValue.Plays.Should().Be(2719701);
            responseValue.Collectors.Should().Be(91770);
            responseValue.CollectedEpisodes.Should().Be(907358);
            responseValue.Comments.Should().Be(6);
            responseValue.Lists.Should().Be(250);
            responseValue.Votes.Should().Be(1149);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatisticsExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/stats";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktStatistics>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync(showId, seasonNr);
            act.Should().Throw<TraktSeasonNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonStatisticsArgumentExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/stats", SEASON_STATISTICS_JSON);

            Func<Task<TraktResponse<ITraktStatistics>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync(null, seasonNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync(string.Empty, seasonNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync("show id", seasonNr);
            act.Should().Throw<ArgumentException>();
        }
    }
}
