namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string UNFOLLOW_USER_URI = $"users/{USERNAME}/follow";

        [Fact]
        public async Task Test_TraktUsersModule_UnfollowUser()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UNFOLLOW_USER_URI, HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.UnfollowUserAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
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
        public async Task Test_TraktUsersModule_UnfollowUser_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UNFOLLOW_USER_URI, statusCode);

            try
            {
                await client.Users.UnfollowUserAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktUsersModule_UnfollowUser_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UNFOLLOW_USER_URI, HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = () => client.Users.UnfollowUserAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.UnfollowUserAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.UnfollowUserAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
