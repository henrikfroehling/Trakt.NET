namespace TraktApiSharp.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_CUSTOM_LIST_ITEMS_URI = $"users/{USERNAME}/lists/{LIST_ID}/items";

        [Fact]
        public async Task Test_TraktUsersModule_GetCustomListItems()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, LIST_ITEMS_JSON);

            TraktPagedResponse<ITraktListItem> response =
                await client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(5);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetCustomListItems_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_CUSTOM_LIST_ITEMS_URI, LIST_ITEMS_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktPagedResponse<ITraktListItem> response =
                await client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(5);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetCustomListItems_With_Type()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_CUSTOM_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}",
                LIST_ITEMS_JSON);

            TraktPagedResponse<ITraktListItem> response =
                await client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID, LIST_ITEM_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(5);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetCustomListItems_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_CUSTOM_LIST_ITEMS_URI}?extended={EXTENDED_INFO}",
                LIST_ITEMS_JSON);

            TraktPagedResponse<ITraktListItem> response =
                await client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(5);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetCustomListItems_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_CUSTOM_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}",
                LIST_ITEMS_JSON);

            TraktPagedResponse<ITraktListItem> response =
                await client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID, LIST_ITEM_TYPE, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(5);
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktListNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomListItems_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LIST_ITEMS_URI, LIST_ITEMS_JSON);

            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Users.GetCustomListItemsAsync(null, LIST_ID);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetCustomListItemsAsync(string.Empty, LIST_ID);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetCustomListItemsAsync("user name", LIST_ID);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetCustomListItemsAsync(USERNAME, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetCustomListItemsAsync(USERNAME, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetCustomListItemsAsync(USERNAME, "list id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
