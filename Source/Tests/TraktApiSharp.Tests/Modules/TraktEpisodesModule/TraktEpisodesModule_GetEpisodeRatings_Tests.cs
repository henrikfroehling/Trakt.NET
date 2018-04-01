namespace TraktApiSharp.Tests.Modules.TraktEpisodesModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Episodes")]
    public partial class TraktEpisodesModule_Tests
    {
        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/ratings", EPISODE_RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Rating.Should().Be(8.54044f);
            responseValue.Votes.Should().Be(3919);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  59 }, { "2", 11 }, { "3", 2 }, { "4", 14 }, { "5", 58 },
                { "6",  233 }, { "7", 492 }, { "8", 835 }, { "9", 635 }, { "10", 1580 }
            };

            responseValue.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatingsExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 0U;
            const uint episodeNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/ratings";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktRating>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(showId, seasonNr, episodeNr);
            act.Should().Throw<TraktEpisodeNotFoundException>();

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
        public void Test_TraktEpisodesModule_GetEpisodeRatingsArgumentExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 0U;
            const uint episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/ratings", EPISODE_RATINGS_JSON);

            Func<Task<TraktResponse<ITraktRating>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(null, seasonNr, episodeNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(string.Empty, seasonNr, episodeNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync("show id", seasonNr, episodeNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(showId, seasonNr, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
