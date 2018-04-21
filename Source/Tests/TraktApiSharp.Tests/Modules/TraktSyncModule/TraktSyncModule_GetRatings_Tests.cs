namespace TraktApiSharp.Tests.Modules.TraktSyncModule
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

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string ENCODED_COMMA = "%2C";

        [Fact]
        public void Test_TraktSyncModule_GetRatings()
        {
            TestUtility.SetupMockResponseWithOAuth($"sync/ratings", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync().Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithType()
        {
            var type = TraktRatingsItemType.Movie;

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_1()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_1_2()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_1_2_3()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_10()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_10_11()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_0_1_2_3_4_5_6_7_8_9_10()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_11()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndRatingsFilter_0_1_2_3_4_5_6_7_8_9()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithRatingsFilter()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(null, ratingsFilter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithTypeAndExtendedOption()
        {
            var type = TraktRatingsItemType.Movie;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}?extended={extendedInfo}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsWithExtendedInfo()
        {
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings?extended={extendedInfo}", RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(null, null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsComplete()
        {
            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var ratingsFilterString = string.Join(ENCODED_COMMA, ratingsFilter);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithOAuth(
                $"sync/ratings/{type.UriName}/{ratingsFilterString}?extended={extendedInfo}",
                RATINGS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktSyncModule_GetRatingsExceptions()
        {
            const string uri = "sync/ratings";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktListResponse<ITraktRatingsItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
