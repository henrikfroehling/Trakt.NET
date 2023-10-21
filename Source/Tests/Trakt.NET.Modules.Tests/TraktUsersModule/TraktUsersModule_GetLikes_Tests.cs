namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private const string GET_LIKES_URI = $"users/{USERNAME}/likes";

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIKES_URI, LIKES_JSON, 1, 10, 1, LIKES_ITEM_COUNT);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME);

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
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}", LIKES_JSON, 1, 10, 1, LIKES_ITEM_COUNT);
            
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME, LIKE_TYPE);

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
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?page={PAGE}", LIKES_JSON, PAGE, 10, 1, LIKES_ITEM_COUNT);
            
            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME, LIKE_TYPE, pagedParameters);

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
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?limit={LIKES_LIMIT}", LIKES_JSON, 1, LIKES_LIMIT, 1, LIKES_ITEM_COUNT);
            
            var pagedParameters = new TraktPagedParameters(null, LIKES_LIMIT);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME, LIKE_TYPE, pagedParameters);

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
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}?page={PAGE}", LIKES_JSON, PAGE, 10, 1, LIKES_ITEM_COUNT);
            
            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME, null, pagedParameters);

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
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}?limit={LIKES_LIMIT}", LIKES_JSON, 1, LIKES_LIMIT, 1, LIKES_ITEM_COUNT);
            
            var pagedParameters = new TraktPagedParameters(null, LIKES_LIMIT);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME, null, pagedParameters);

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
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}?page={PAGE}&limit={LIKES_LIMIT}", LIKES_JSON, PAGE, LIKES_LIMIT, 1, LIKES_ITEM_COUNT);
            
            var pagedParameters = new TraktPagedParameters(PAGE, LIKES_LIMIT);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME, null, pagedParameters);

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
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?page={PAGE}&limit={LIKES_LIMIT}",
                LIKES_JSON, PAGE, LIKES_LIMIT, 1, LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIKES_LIMIT);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME, LIKE_TYPE, pagedParameters);

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
        public async Task Test_TraktUsersModule_GetLikes_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?page=2&limit={LIKES_LIMIT}",
                LIKES_JSON, 2, LIKES_LIMIT, 5, LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIKES_LIMIT);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME, LIKE_TYPE, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIKES_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?page=2&limit={LIKES_LIMIT}",
                LIKES_JSON, 2, LIKES_LIMIT, 2, LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIKES_LIMIT);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME, LIKE_TYPE, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIKES_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?page=1&limit={LIKES_LIMIT}",
                LIKES_JSON, 1, LIKES_LIMIT, 2, LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIKES_LIMIT);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME, LIKE_TYPE, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIKES_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?page=1&limit={LIKES_LIMIT}",
                LIKES_JSON, 1, LIKES_LIMIT, 1, LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIKES_LIMIT);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME, LIKE_TYPE, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIKES_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?page=2&limit={LIKES_LIMIT}",
                LIKES_JSON, 2, LIKES_LIMIT, 2, LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIKES_LIMIT);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME, LIKE_TYPE, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIKES_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetMockClient(client,
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?page=1&limit={LIKES_LIMIT}",
                LIKES_JSON, 1, LIKES_LIMIT, 2, LIKES_ITEM_COUNT);

            response = await response.GetPreviousPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIKES_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?page=1&limit={LIKES_LIMIT}",
                LIKES_JSON, 1, LIKES_LIMIT, 2, LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIKES_LIMIT);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(USERNAME, LIKE_TYPE, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIKES_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetMockClient(client,
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?page=2&limit={LIKES_LIMIT}",
                LIKES_JSON, 2, LIKES_LIMIT, 2, LIKES_ITEM_COUNT);

            response = await response.GetNextPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIKES_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
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
        public async Task Test_TraktUsersModule_GetLikes_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIKES_URI, statusCode);

            try
            {
                await client.Users.GetLikesAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
