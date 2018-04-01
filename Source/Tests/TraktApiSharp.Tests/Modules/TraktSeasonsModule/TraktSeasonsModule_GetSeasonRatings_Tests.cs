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
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/ratings", SEASON_RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync(showId, seasonNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Rating.Should().Be(9.12881f);
            responseValue.Votes.Should().Be(1149);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  7 }, { "2", 5 }, { "3", 4 }, { "4", 2 }, { "5", 9 },
                { "6",  23 }, { "7", 45 }, { "8", 152 }, { "9", 282 }, { "10", 620 }
            };

            responseValue.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatingsExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/ratings";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktRating>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync(showId, seasonNr);
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
        public void Test_TraktSeasonsModule_GetSeasonRatingsArgumentExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/ratings", SEASON_RATINGS_JSON);

            Func<Task<TraktResponse<ITraktRating>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync(null, seasonNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync(string.Empty, seasonNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync("show id", seasonNr);
            act.Should().Throw<ArgumentException>();
        }
    }
}
