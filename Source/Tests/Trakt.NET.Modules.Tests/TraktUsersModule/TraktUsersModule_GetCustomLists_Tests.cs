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
        public async Task Test_TraktUsersModule_GetCustomLists_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_CUSTOM_LISTS_URI, statusCode);

            try
            {
                await client.Users.GetCustomListsAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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
