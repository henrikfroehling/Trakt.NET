namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Watched;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_WATCHED_SHOWS_URI = $"users/{USERNAME}/watched/shows";

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedShows()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_SHOWS_URI, WATCHED_SHOWS_JSON);
            TraktListResponse<ITraktWatchedShow> response = await client.Users.GetWatchedShowsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedShows_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_SHOWS_URI, WATCHED_SHOWS_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktListResponse<ITraktWatchedShow> response = await client.Users.GetWatchedShowsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedShows_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_SHOWS_URI}?extended={EXTENDED_INFO}",
                WATCHED_SHOWS_JSON);

            TraktListResponse<ITraktWatchedShow> response = await client.Users.GetWatchedShowsAsync(USERNAME, EXTENDED_INFO);

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
        public async Task Test_TraktUsersModule_GetWatchedShows_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_SHOWS_URI, statusCode);

            try
            {
                await client.Users.GetWatchedShowsAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedShows_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_SHOWS_URI, WATCHED_SHOWS_JSON);

            Func<Task<TraktListResponse<ITraktWatchedShow>>> act = () => client.Users.GetWatchedShowsAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetWatchedShowsAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetWatchedShowsAsync("user name");
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
