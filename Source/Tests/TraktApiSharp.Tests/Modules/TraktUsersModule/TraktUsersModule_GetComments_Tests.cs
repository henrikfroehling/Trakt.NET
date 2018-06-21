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
        private readonly string GET_COMMENTS_URI = $"users/{USERNAME}/comments";

        [Fact]
        public async Task Test_TraktUsersModule_GetComments()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_COMMENTS_URI,
                USER_COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response = await client.Users.GetCommentsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_COMMENTS_URI,
                USER_COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            client.Configuration.ForceAuthorization = true;

            TraktPagedResponse<ITraktUserComment> response = await client.Users.GetCommentsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_CommentType()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}",
                USER_COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_CommentType_And_ObjectType()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}/{OBJECT_TYPE.UriName}",
                USER_COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE, OBJECT_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_CommentType_And_ObjectType_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}/{OBJECT_TYPE.UriName}?extended={EXTENDED_INFO}",
                USER_COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE, OBJECT_TYPE, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_CommentType_And_ObjectType_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}/{OBJECT_TYPE.UriName}?page={PAGE}",
                USER_COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE, OBJECT_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_CommentType_And_ObjectType_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}/{OBJECT_TYPE.UriName}?limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, 1, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE, OBJECT_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_CommentType_And_ObjectType_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}/{OBJECT_TYPE.UriName}?page={PAGE}&limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, PAGE, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE, OBJECT_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_CommentType_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}?extended={EXTENDED_INFO}",
                USER_COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE, null, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_CommentType_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}",
                USER_COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_CommentType_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}?extended={EXTENDED_INFO}&limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, 1, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_CommentType_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}&limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, PAGE, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_CommentType_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}?page={PAGE}",
                USER_COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_CommentType_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}?limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, 1, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_CommentType_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}?page={PAGE}&limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, PAGE, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_ObjectType()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{OBJECT_TYPE.UriName}",
                USER_COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, OBJECT_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_ObjectType_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{OBJECT_TYPE.UriName}?extended={EXTENDED_INFO}",
                USER_COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, OBJECT_TYPE, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_ObjectType_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{OBJECT_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}",
                USER_COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, OBJECT_TYPE, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_ObjectType_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{OBJECT_TYPE.UriName}?extended={EXTENDED_INFO}&limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, 1, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, OBJECT_TYPE, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_ObjectType_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{OBJECT_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}&limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, PAGE, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, OBJECT_TYPE, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_ObjectType_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{OBJECT_TYPE.UriName}?page={PAGE}",
                USER_COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, OBJECT_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_ObjectType_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{OBJECT_TYPE.UriName}?limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, 1, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, OBJECT_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_ObjectType_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{OBJECT_TYPE.UriName}?page={PAGE}&limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, PAGE, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, OBJECT_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}?extended={EXTENDED_INFO}",
                USER_COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, null, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                USER_COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}?extended={EXTENDED_INFO}&limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, 1, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, PAGE, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}?page={PAGE}",
                USER_COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}?limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, 1, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}?page={PAGE}&limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, PAGE, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, null, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_URI}/{COMMENT_TYPE.UriName}/{OBJECT_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page={PAGE}&limit={COMMENTS_LIMIT}",
                USER_COMMENTS_JSON, PAGE, COMMENTS_LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Users.GetCommentsAsync(USERNAME, COMMENT_TYPE, OBJECT_TYPE,
                                                    null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetComments_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_COMMENTS_URI, USER_COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetCommentsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetCommentsAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
