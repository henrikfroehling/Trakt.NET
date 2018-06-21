namespace TraktNet.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_COLLECTION_SHOWS_URI = $"users/{USERNAME}/collection/shows";

        [Fact]
        public async Task Test_TraktUsersModule_GetCollectionShows()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, COLLECTION_SHOWS_JSON);
            TraktListResponse<ITraktCollectionShow> response = await client.Users.GetCollectionShowsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetCollectionShows_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_SHOWS_URI, COLLECTION_SHOWS_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktListResponse<ITraktCollectionShow> response = await client.Users.GetCollectionShowsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetCollectionShows_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COLLECTION_SHOWS_URI}?extended={EXTENDED_INFO}",
                COLLECTION_SHOWS_JSON);

            TraktListResponse<ITraktCollectionShow> response = await client.Users.GetCollectionShowsAsync(USERNAME, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetCollectionShows_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COLLECTION_SHOWS_URI, COLLECTION_SHOWS_JSON);

            Func<Task<TraktListResponse<ITraktCollectionShow>>> act = () => client.Users.GetCollectionShowsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetCollectionShowsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetCollectionShowsAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
