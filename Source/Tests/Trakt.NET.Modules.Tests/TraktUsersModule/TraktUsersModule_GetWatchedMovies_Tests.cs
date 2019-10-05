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
        private readonly string GET_WATCHED_MOVIES_URI = $"users/{USERNAME}/watched/movies";

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedMovies()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, WATCHED_MOVIES_JSON);
            TraktListResponse<ITraktWatchedMovie> response = await client.Users.GetWatchedMoviesAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedMovies_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, WATCHED_MOVIES_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktListResponse<ITraktWatchedMovie> response = await client.Users.GetWatchedMoviesAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedMovies_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_MOVIES_URI}?extended={EXTENDED_INFO}",
                WATCHED_MOVIES_JSON);

            TraktListResponse<ITraktWatchedMovie> response = await client.Users.GetWatchedMoviesAsync(USERNAME, EXTENDED_INFO);

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
        public async Task Test_TraktUsersModule_GetWatchedMovies_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, statusCode);

            try
            {
                await client.Users.GetWatchedMoviesAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, WATCHED_MOVIES_JSON);

            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetWatchedMoviesAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetWatchedMoviesAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
