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
        public async Task Test_TraktUsersModule_GetComments_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_URI, statusCode);

            try
            {
                await client.Users.GetCommentsAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetComments_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_COMMENTS_URI, USER_COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Users.GetCommentsAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetCommentsAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetCommentsAsync("user name");
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
