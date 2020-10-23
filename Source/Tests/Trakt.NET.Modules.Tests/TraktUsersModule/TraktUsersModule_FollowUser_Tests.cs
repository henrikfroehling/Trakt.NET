namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Users.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string FOLLOW_USER_URI = $"users/{USERNAME}/follow";

        [Fact]
        public async Task Test_TraktUsersModule_FollowUser()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, FOLLOW_USER_RESPONSE_JSON);
            TraktResponse<ITraktUserFollowUserPostResponse> response = await client.Users.FollowUserAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserFollowUserPostResponse responseValue = response.Value;

            responseValue.ApprovedAt.Should().Be(DateTime.Parse("2014-11-15T09:41:34.704Z").ToUniversalTime());
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
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
        public async Task Test_TraktUsersModule_FollowUser_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, statusCode);

            try
            {
                await client.Users.FollowUserAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, FOLLOW_USER_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.FollowUserAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.FollowUserAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
