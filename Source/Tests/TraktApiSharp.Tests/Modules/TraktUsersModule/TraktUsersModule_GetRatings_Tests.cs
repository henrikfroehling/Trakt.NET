namespace TraktApiSharp.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Ratings;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private const string ENCODED_COMMA = "%2C";

        [Fact]
        public void Test_TraktUsersModule_GetRatings()
        {
            const string username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithOAuthEnforced()
        {
            const string username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/ratings", RATINGS_JSON);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithType()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Movie;

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_1()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_1_2()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_1_2_3()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Show;
            var ratingsFilter = new int[] { 1, 2, 3 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Season;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Episode;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.All;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_10()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_10_11()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_0_1_2_3_4_5_6_7_8_9_10()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_11()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndRatingsFilter_0_1_2_3_4_5_6_7_8_9()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithRatingsFilter()
        {
            const string username = "sean";
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, null, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithTypeAndExtendedOption()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Movie;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings/{type.UriName}?extended={extendedInfo}",
                                                      RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsWithExtendedInfo()
        {
            const string username = "sean";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/ratings?extended={extendedInfo}",
                                                      RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, null, null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsComplete()
        {
            const string username = "sean";
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth(
                $"users/{username}/ratings/{type.UriName}/{ratingsFilterString}?extended={extendedInfo}",
                RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username, type, ratingsFilter, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatingsExceptions()
        {
            const string username = "sean";
            var uri = $"users/{username}/ratings";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktRatingsItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(username);
            act.Should().Throw<TraktNotFoundException>();

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
        public void Test_TraktUsersModule_GetRatingsArgumentExceptions()
        {
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetRatingsAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
