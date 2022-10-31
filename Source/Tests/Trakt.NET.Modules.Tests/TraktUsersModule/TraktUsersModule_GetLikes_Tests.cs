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
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private const string GET_LIKES_URI = "users/likes";

        [Fact]
        public async Task Test_TraktUsersModule_GetLikes()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIKES_URI, LIKES_JSON, 1, 10, 1, LIKES_ITEM_COUNT);
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
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}", LIKES_JSON, 1, 10, 1, LIKES_ITEM_COUNT);
            
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
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIKES_URI}/{LIKE_TYPE.UriName}?page={PAGE}", LIKES_JSON, PAGE, 10, 1, LIKES_ITEM_COUNT);
            
            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(LIKE_TYPE, pagedParameters);

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
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(LIKE_TYPE, pagedParameters);

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
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(null, pagedParameters);

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
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(null, pagedParameters);

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
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(null, pagedParameters);

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
            TraktPagedResponse<ITraktUserLikeItem> response = await client.Users.GetLikesAsync(LIKE_TYPE, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIKES_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
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
                await client.Users.GetLikesAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
