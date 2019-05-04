namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Users;
    using TraktNet.Objects.Post.Users.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string REORDER_CUSTOM_LISTS_URI = $"users/{USERNAME}/lists/reorder";

        [Fact]
        public async Task Test_TraktUsersModule_ReorderCustomLists()
        {
            ITraktUserCustomListsReorderPost customListsReorderPost = new TraktUserCustomListsReorderPost
            {
                Rank = REORDERED_CUSTOM_LISTS
            };

            string postJson = await TestUtility.SerializeObject(customListsReorderPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, postJson, CUSTOM_LISTS_REORDER_POST_RESPONSE_JSON);
            TraktResponse<ITraktUserCustomListsReorderPostResponse> response = await client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserCustomListsReorderPostResponse responseValue = response.Value;

            responseValue.Updated.Should().Be(6);
            responseValue.SkippedIds.Should().NotBeNull().And.HaveCount(1);
            responseValue.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ReorderCustomLists_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(USERNAME, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktUsersModule_ReorderCustomLists_ArgumentExceptions()
        {
            ITraktUserCustomListsReorderPost customListsReorderPost = new TraktUserCustomListsReorderPost
            {
                Rank = REORDERED_CUSTOM_LISTS
            };

            string postJson = await TestUtility.SerializeObject(customListsReorderPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_CUSTOM_LISTS_URI, postJson, CUSTOM_LISTS_REORDER_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktUserCustomListsReorderPostResponse>>> act = () => client.Users.ReorderCustomListsAsync(null, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.ReorderCustomListsAsync(string.Empty, REORDERED_CUSTOM_LISTS);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.ReorderCustomListsAsync("user name", REORDERED_CUSTOM_LISTS);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.ReorderCustomListsAsync(USERNAME, null);
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
