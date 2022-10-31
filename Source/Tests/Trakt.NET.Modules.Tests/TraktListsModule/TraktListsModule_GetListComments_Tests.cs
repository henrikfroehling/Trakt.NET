namespace TraktNet.Modules.Tests.TraktListsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Lists")]
    public partial class TraktListsModule_Tests
    {
        private readonly string GET_LIST_COMMENTS_URI = $"lists/{LIST_ID}/comments";

        [Fact]
        public async Task Test_TraktListsModule_GetListComments()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI,
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response = await client.Lists.GetListCommentsAsync(LIST_ID);

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
        public async Task Test_TraktListsModule_GetListComments_With_SortOrder()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}",
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response =
                await client.Lists.GetListCommentsAsync(LIST_ID, COMMENT_SORT_ORDER);

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
        public async Task Test_TraktListsModule_GetListComments_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_COMMENTS_URI}?page={PAGE}",
                LIST_COMMENTS_JSON, PAGE, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktComment> response =
                await client.Lists.GetListCommentsAsync(LIST_ID, null, pagedParameters);

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
        public async Task Test_TraktListsModule_GetListComments_With_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}",
                LIST_COMMENTS_JSON, PAGE, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktComment> response =
                await client.Lists.GetListCommentsAsync(LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

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
        public async Task Test_TraktListsModule_GetListComments_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}?limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 1, LIST_COMMENTS_LIMIT, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Lists.GetListCommentsAsync(LIST_ID, null, pagedParameters);

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
        public async Task Test_TraktListsModule_GetListComments_With_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 1, LIST_COMMENTS_LIMIT, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Lists.GetListCommentsAsync(LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

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
        public async Task Test_TraktListsModule_GetListComments_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}?page={PAGE}&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, PAGE, LIST_COMMENTS_LIMIT, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Lists.GetListCommentsAsync(LIST_ID, null, pagedParameters);

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
        public async Task Test_TraktListsModule_GetListComments_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, PAGE, LIST_COMMENTS_LIMIT, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Lists.GetListCommentsAsync(LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
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
        public async Task Test_TraktListsModule_GetListComments_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, statusCode);

            try
            {
                await client.Lists.GetListCommentsAsync(LIST_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListComments_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_LIST_COMMENTS_URI,
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Lists.GetListCommentsAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListCommentsAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Lists.GetListCommentsAsync("list id");
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
