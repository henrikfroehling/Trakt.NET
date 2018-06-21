namespace TraktNet.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private const string GET_LIKES_URI = "users/likes";

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_LIKES_URI,
                LIKES_JSON, 1, 10, 1, LIKES_ITEM_COUNT);

            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes_With_Type()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}",
                LIKES_JSON, 1, 10, 1, LIKES_ITEM_COUNT);

            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(LIKE_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes_With_Type_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?page={PAGE}",
                LIKES_JSON, PAGE, 10, 1, LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserLikeItem> response =
                await client.Users.GetLikesAsync(LIKE_TYPE, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes_With_Type_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?limit={LIKES_LIMIT}",
                LIKES_JSON, 1, LIKES_LIMIT, 1, LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIKES_LIMIT);

            TraktPagedResponse<ITraktUserLikeItem> response =
                await client.Users.GetLikesAsync(LIKE_TYPE, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIKES_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes_With_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_LIKES_URI}?page={PAGE}",
                LIKES_JSON, PAGE, 10, 1, LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserLikeItem> response =
                await client.Users.GetLikesAsync(null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes_With_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_LIKES_URI}?limit={LIKES_LIMIT}",
                LIKES_JSON, 1, LIKES_LIMIT, 1, LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIKES_LIMIT);

            TraktPagedResponse<ITraktUserLikeItem> response =
                await client.Users.GetLikesAsync(null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIKES_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_LIKES_URI}?page={PAGE}&limit={LIKES_LIMIT}",
                LIKES_JSON, PAGE, LIKES_LIMIT, 1, LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIKES_LIMIT);

            TraktPagedResponse<ITraktUserLikeItem> response =
                await client.Users.GetLikesAsync(null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIKES_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?page={PAGE}&limit={LIKES_LIMIT}",
                LIKES_JSON, PAGE, LIKES_LIMIT, 1, LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIKES_LIMIT);

            TraktPagedResponse<ITraktUserLikeItem> response =
                await client.Users.GetLikesAsync(LIKE_TYPE, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIKES_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetLikes_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIKES_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktUserLikeItem>>> act = () => client.Users.GetLikesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
