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
    using TraktNet.Parameters;
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
        public async Task Test_TraktUsersModule_GetListLikes_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/likes",
                LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_ITEM_COUNT);

            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, TRAKT_LIST_ID);

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
        public async Task Test_TraktUsersModule_GetListLikes_With_ListIds_TraktID()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID
            };

            TraktClient client = TestUtility.GetMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/likes",
                LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_ITEM_COUNT);

            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, listIds);

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
        public async Task Test_TraktUsersModule_GetListLikes_With_ListIds_Slug()
        {
            var listIds = new TraktListIds
            {
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"users/{USERNAME}/lists/{LIST_SLUG}/likes",
                LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_ITEM_COUNT);

            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, listIds);

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
        public async Task Test_TraktUsersModule_GetListLikes_With_ListIds()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID,
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/likes",
                LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_ITEM_COUNT);

            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, listIds);

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

        [Fact]
        public async Task Test_TraktUsersModule_GetListLikes_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page=2&limit={LIST_LIKES_LIMIT}",
                LIST_LIKES_JSON, 2, LIST_LIKES_LIMIT, 5, LIST_LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIST_LIKES_LIMIT);
            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, LIST_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIST_LIKES_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListLikes_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page=2&limit={LIST_LIKES_LIMIT}",
                LIST_LIKES_JSON, 2, LIST_LIKES_LIMIT, 2, LIST_LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIST_LIKES_LIMIT);
            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, LIST_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIST_LIKES_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListLikes_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page=1&limit={LIST_LIKES_LIMIT}",
                LIST_LIKES_JSON, 1, LIST_LIKES_LIMIT, 2, LIST_LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIST_LIKES_LIMIT);
            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, LIST_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIST_LIKES_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListLikes_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page=1&limit={LIST_LIKES_LIMIT}",
                LIST_LIKES_JSON, 1, LIST_LIKES_LIMIT, 1, LIST_LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIST_LIKES_LIMIT);
            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, LIST_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIST_LIKES_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListLikes_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page=2&limit={LIST_LIKES_LIMIT}",
                LIST_LIKES_JSON, 2, LIST_LIKES_LIMIT, 2, LIST_LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIST_LIKES_LIMIT);
            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, LIST_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIST_LIKES_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetMockClient(client, $"{GET_LIST_LIKES_URI}?page=1&limit={LIST_LIKES_LIMIT}",
                LIST_LIKES_JSON, 1, LIST_LIKES_LIMIT, 2, LIST_LIKES_ITEM_COUNT);

            response = await response.GetPreviousPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIST_LIKES_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListLikes_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_LIKES_URI}?page=1&limit={LIST_LIKES_LIMIT}",
                LIST_LIKES_JSON, 1, LIST_LIKES_LIMIT, 2, LIST_LIKES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIST_LIKES_LIMIT);
            TraktPagedResponse<ITraktListLike> response = await client.Users.GetListLikesAsync(USERNAME, LIST_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIST_LIKES_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetMockClient(client, $"{GET_LIST_LIKES_URI}?page=2&limit={LIST_LIKES_LIMIT}",
                LIST_LIKES_JSON, 2, LIST_LIKES_LIMIT, 2, LIST_LIKES_ITEM_COUNT);

            response = await response.GetNextPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_LIKES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_LIKES_ITEM_COUNT);
            response.Limit.Should().Be(LIST_LIKES_LIMIT);
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
        public async Task Test_TraktUsersModule_GetListLikes_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_LIKES_URI, LIST_LIKES_JSON, 1, 10, 1, LIST_LIKES_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktListLike>>> act = () => client.Users.GetListLikesAsync(USERNAME, default(ITraktListIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetListLikesAsync(USERNAME, new TraktListIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetListLikesAsync(USERNAME, 0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
