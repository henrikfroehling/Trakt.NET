namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_COLLECTION_MOVIES_URI = $"users/{USERNAME}/collection/movies";

        [Fact]
        public async Task Test_TraktUsersModule_GetCollectionMovies()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_MOVIES_URI, COLLECTION_MOVIES_JSON);
            TraktListResponse<ITraktCollectionMovie> response = await client.Users.GetCollectionMoviesAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetCollectionMovies_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, COLLECTION_MOVIES_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktListResponse<ITraktCollectionMovie> response = await client.Users.GetCollectionMoviesAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetCollectionMovies_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COLLECTION_MOVIES_URI}?extended={EXTENDED_INFO}",
                COLLECTION_MOVIES_JSON);

            TraktListResponse<ITraktCollectionMovie> response = await client.Users.GetCollectionMoviesAsync(USERNAME, EXTENDED_INFO);

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
        public async Task Test_TraktUsersModule_GetCollectionMovies_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_MOVIES_URI, statusCode);

            try
            {
                await client.Users.GetCollectionMoviesAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionMovies_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_MOVIES_URI, COLLECTION_MOVIES_JSON);

            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Users.GetCollectionMoviesAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetCollectionMoviesAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetCollectionMoviesAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
