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
        private readonly string UNLIKE_LIST_URI = $"users/{USERNAME}/lists/{LIST_ID}/like";

        [Fact]
        public async Task Test_TraktUsersModule_UnlikeList()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UNLIKE_LIST_URI, HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.UnlikeListAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
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
        public async Task Test_TraktUsersModule_UnlikeList_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UNLIKE_LIST_URI, statusCode);

            try
            {
                await client.Users.UnlikeListAsync(USERNAME, LIST_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktUsersModule_UnlikeList_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UNLIKE_LIST_URI, HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = () => client.Users.UnlikeListAsync(null, LIST_ID);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.UnlikeListAsync(string.Empty, LIST_ID);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.UnlikeListAsync("user name", LIST_ID);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.UnlikeListAsync(USERNAME, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.UnlikeListAsync(USERNAME, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.UnlikeListAsync(USERNAME, "list id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
