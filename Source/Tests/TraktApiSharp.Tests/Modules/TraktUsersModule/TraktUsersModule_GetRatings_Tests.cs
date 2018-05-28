namespace TraktApiSharp.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Ratings;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_RATINGS_URI = $"users/{USERNAME}/ratings";

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, RATINGS_JSON);
            TraktListResponse<ITraktRatingsItem> response = await client.Users.GetRatingsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_RATINGS_URI, RATINGS_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktListResponse<ITraktRatingsItem> response = await client.Users.GetRatingsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_1()
        {
            var ratingsFilter = new int[] { 1 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_1_2()
        {
            var ratingsFilter = new int[] { 1, 2 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_1_2_3()
        {
            var ratingsFilter = new int[] { 1, 2, 3 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6_7()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6_7_8()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6_7_8_9()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6_7_8_9_10()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6_7_8_9_10_11()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_0_1_2_3_4_5_6_7_8_9_10()
        {
            var ratingsFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6_7_8_9_11()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_RatingsFilter_0_1_2_3_4_5_6_7_8_9()
        {
            var ratingsFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_RatingsFilter()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, null, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_Type_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}?extended={EXTENDED_INFO}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, null, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetRatings_Complete()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}" +
                $"/{BuildRatingsFilterString(ratingsFilter)}?extended={EXTENDED_INFO}",
                RATINGS_JSON);

            TraktListResponse<ITraktRatingsItem> response =
                await client.Users.GetRatingsAsync(USERNAME, RATINGS_ITEM_TYPE, ratingsFilter, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetRatings_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RATINGS_URI, RATINGS_JSON);

            Func<Task<TraktListResponse<ITraktRatingsItem>>> act = () => client.Users.GetRatingsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetRatingsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetRatingsAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
