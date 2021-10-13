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
        private readonly string LIKE_LIST_URI = $"users/{USERNAME}/lists/{LIST_ID}/like";

        [Fact]
        public async Task Test_TraktUsersModule_LikeList()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Users.LikeListAsync(USERNAME, LIST_ID);

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
        public async Task Test_TraktUsersModule_LikeList_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, statusCode);

            try
            {
                await client.Users.LikeListAsync(USERNAME, LIST_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_LikeList_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_LIST_URI, HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = () => client.Users.LikeListAsync(null, LIST_ID);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.LikeListAsync(string.Empty, LIST_ID);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.LikeListAsync("user name", LIST_ID);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.LikeListAsync(USERNAME, null);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.LikeListAsync(USERNAME, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.LikeListAsync(USERNAME, "list id");
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
