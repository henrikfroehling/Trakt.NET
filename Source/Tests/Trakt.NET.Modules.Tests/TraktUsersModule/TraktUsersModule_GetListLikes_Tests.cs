namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_LIST_LIKES_URI = $"users/{USERNAME}/lists/{LIST_ID}/likes";

        [Fact]
        public async Task Test_TraktUsersModule_GetListLikes()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_LIKES_URI, LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_ITEM_COUNT);

            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListLikes_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LIST_LIKES_URI, LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_ITEM_COUNT);
            client.Configuration.ForceAuthorization = true;

            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListLikes_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page={PAGE}",
                LIST_LIKES_JSON, PAGE, 10, 1, LIST_LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, LIST_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListLikes_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?limit={LIST_LIKES_LIMIT}",
                LIST_LIKES_JSON, 1, LIST_LIKES_LIMIT, 1, LIST_LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIST_LIKES_LIMIT);

            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, LIST_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIST_LIKES_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListLikes_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page={PAGE}&limit={LIST_LIKES_LIMIT}",
                LIST_LIKES_JSON, PAGE, LIST_LIKES_LIMIT, 1, LIST_LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIST_LIKES_LIMIT);

            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, LIST_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIST_LIKES_LIMIT);
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
        public async Task Test_TraktUsersModule_GetListLikes_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_LIKES_URI, statusCode);

            try
            {
                await client.Users.GetListLikesAsync(USERNAME, LIST_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListLikes_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_LIKES_URI, LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktListLike>>> act = () => client.Users.GetListLikesAsync(null, LIST_ID);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetListLikesAsync(string.Empty, LIST_ID);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetListLikesAsync("user name", LIST_ID);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetListLikesAsync(USERNAME, null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetListLikesAsync(USERNAME, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetListLikesAsync(USERNAME, "list id");
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
