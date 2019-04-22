namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users.Lists;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_CUSTOM_LISTS_URI = $"users/{USERNAME}/lists";

        [Fact]
        public async Task Test_TraktUsersModule_GetCustomLists()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, CUSTOM_LISTS_JSON);
            TraktListResponse<ITraktList> response = await client.Users.GetCustomListsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetCustomLists_With_OAuth_Enfored()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_CUSTOM_LISTS_URI, CUSTOM_LISTS_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktListResponse<ITraktList> response = await client.Users.GetCustomListsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCustomLists_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, CUSTOM_LISTS_JSON);

            Func<Task<TraktListResponse<ITraktList>>> act = () => client.Users.GetCustomListsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetCustomListsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetCustomListsAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
