namespace TraktApiSharp.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string LIKE_LIST_URI = $"users/{USERNAME}/lists/{LIST_ID}/like";

        [Fact]
        public async Task Test_TraktUsersModule_LikeList()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.LikeListAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, HttpStatusCode.NotFound);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktListNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, HttpStatusCode.Conflict);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, (HttpStatusCode)412);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, (HttpStatusCode)422);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, (HttpStatusCode)429);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, (HttpStatusCode)503);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, (HttpStatusCode)504);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, (HttpStatusCode)520);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, (HttpStatusCode)521);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, (HttpStatusCode)522);
            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_LikeList_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(null, LIST_ID);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.LikeListAsync(string.Empty, LIST_ID);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.LikeListAsync("user name", LIST_ID);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.LikeListAsync(USERNAME, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.LikeListAsync(USERNAME, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.LikeListAsync(USERNAME, "list id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
