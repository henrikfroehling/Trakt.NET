﻿namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_LIST_COMMENTS_URI = $"users/{USERNAME}/lists/{LIST_ID}/comments";

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_LIST_COMMENTS_URI,
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response = await client.Users.GetListCommentsAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/comments",
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);
            
            TraktPagedResponse<ITraktComment> response = await client.Users.GetListCommentsAsync(USERNAME, TRAKT_LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_ListIds_TraktID()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID
            };

            TraktClient client = TestUtility.GetMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/comments",
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);
            
            TraktPagedResponse<ITraktComment> response = await client.Users.GetListCommentsAsync(USERNAME, listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_ListIds_Slug()
        {
            var listIds = new TraktListIds
            {
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"users/{USERNAME}/lists/{LIST_SLUG}/comments",
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);
            
            TraktPagedResponse<ITraktComment> response = await client.Users.GetListCommentsAsync(USERNAME, listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_ListIds()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID,
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/comments",
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);
            
            TraktPagedResponse<ITraktComment> response = await client.Users.GetListCommentsAsync(USERNAME, listIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_List()
        {
            var list = new TraktList
            {
                Ids = new TraktListIds
                {
                    Trakt = TRAKT_LIST_ID,
                    Slug = LIST_SLUG
                }
            };

            TraktClient client = TestUtility.GetMockClient($"users/{USERNAME}/lists/{TRAKT_LIST_ID}/comments",
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response = await client.Users.GetListCommentsAsync(USERNAME, list);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_LIST_COMMENTS_URI,
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            client.Configuration.ForceAuthorization = true;
            TraktPagedResponse<ITraktComment> response = await client.Users.GetListCommentsAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_OAuth_Enforced_For_Username_Me()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"users/me/lists/{LIST_ID}/comments",
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response = await client.Users.GetListCommentsAsync("me", LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_SortOrder()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}",
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}?page={PAGE}",
                LIST_COMMENTS_JSON, PAGE, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}",
                LIST_COMMENTS_JSON, PAGE, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}?limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 1, LIST_COMMENTS_LIMIT, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 1, LIST_COMMENTS_LIMIT, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}?page={PAGE}&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, PAGE, LIST_COMMENTS_LIMIT, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, PAGE, LIST_COMMENTS_LIMIT, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=2&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 2, LIST_COMMENTS_LIMIT, 5, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=2&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 2, LIST_COMMENTS_LIMIT, 2, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=1&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 1, LIST_COMMENTS_LIMIT, 2, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=1&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 1, LIST_COMMENTS_LIMIT, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=2&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 2, LIST_COMMENTS_LIMIT, 2, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetMockClient(client,
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=1&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 1, LIST_COMMENTS_LIMIT, 2, LIST_COMMENTS_ITEM_COUNT);

            response = await response.GetPreviousPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=1&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 1, LIST_COMMENTS_LIMIT, 2, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetMockClient(client,
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=2&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 2, LIST_COMMENTS_LIMIT, 2, LIST_COMMENTS_ITEM_COUNT);

            response = await response.GetNextPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktListNotFoundException))]
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
        public async Task Test_TraktUsersModule_GetListComments_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, statusCode);

            try
            {
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, default(ITraktListIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetListCommentsAsync(USERNAME, default(ITraktList));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetListCommentsAsync(USERNAME, new TraktListIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetListCommentsAsync(USERNAME, 0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
