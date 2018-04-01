namespace TraktApiSharp.Tests.Modules.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        [Fact]
        public void Test_TraktSeasonsModule_GetSeason()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}", SEASON_EPISODES_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWithExtendedInfo()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}?extended={extendedInfo}", SEASON_EPISODES_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWithTranslations()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const string translationLanguageCode = "en";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}" +
                                                      $"?translations={translationLanguageCode}",
                                                      SEASON_EPISODES_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr,
                                                                               null, translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWithExtendedInfoAndTranslations()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const string translationLanguageCode = "en";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}" +
                                                      $"?extended={extendedInfo}" +
                                                      $"&translations={translationLanguageCode}",
                                                      SEASON_EPISODES_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr,
                                                                               extendedInfo, translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWithAllTranslations()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const string translationLanguageCode = "all";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}" +
                                                      $"?translations={translationLanguageCode}",
                                                      SEASON_EPISODES_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr,
                                                                               null, translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWithExtendedInfoAndAllTranslations()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const string translationLanguageCode = "all";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}" +
                                                      $"?extended={extendedInfo}" +
                                                      $"&translations={translationLanguageCode}",
                                                      SEASON_EPISODES_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr,
                                                                               extendedInfo, translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr);
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
        public void Test_TraktSeasonsModule_GetSeasonArgumentExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}", SEASON_EPISODES_JSON);

            Func<Task<TraktListResponse<ITraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(null, seasonNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(string.Empty, seasonNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync("show id", seasonNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr, null, "eng");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr, null, "e");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr, null, "all");
            act.Should().NotThrow();
        }
    }
}
