namespace TraktApiSharp.Tests.Modules.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasons()
        {
            const string showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons", SEASONS_ALL_FULL_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasonsWithExtendedInfo()
        {
            const string showId = "1390";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons?extended={extendedInfo}", SEASONS_ALL_FULL_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasonsWithTranslations()
        {
            const string showId = "1390";
            const string translationLanguageCode = "en";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons?translations={translationLanguageCode}", SEASONS_ALL_FULL_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, null, translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasonsWithExtendedInfoAndTranslations()
        {
            const string showId = "1390";
            const string translationLanguageCode = "en";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons" +
                                                      $"?extended={extendedInfo}" +
                                                      $"&translations={translationLanguageCode}",
                                                      SEASONS_ALL_FULL_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, extendedInfo,
                                                                                   translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasonsWithAllTranslations()
        {
            const string showId = "1390";
            const string translationLanguageCode = "all";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons?translations={translationLanguageCode}", SEASONS_ALL_FULL_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, null, translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasonsWithExtendedInfoAndAllTranslations()
        {
            const string showId = "1390";
            const string translationLanguageCode = "all";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons" +
                                                      $"?extended={extendedInfo}" +
                                                      $"&translations={translationLanguageCode}",
                                                      SEASONS_ALL_FULL_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, extendedInfo,
                                                                                   translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetAllSeasonsExceptions()
        {
            const string showId = "1390";
            var uri = $"shows/{showId}/seasons";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktSeason>>> act =
                act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

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
        public void Test_TraktSeasonsModule_GetAllSeasonsArgumentExceptions()
        {
            const string showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons", SEASONS_ALL_FULL_JSON);

            Func<Task<TraktListResponse<ITraktSeason>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync("show id");
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, null, "eng");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, null, "e");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, null, "all");
            act.Should().NotThrow();
        }
    }
}
