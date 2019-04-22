namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_WATCHING_URI = $"users/{USERNAME}/watching";

        [Fact]
        public async Task Test_TraktUsersModule_GetWatching()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, WATCHING_ITEM_MOVIE_JSON);
            TraktResponse<ITraktUserWatchingItem> response = await client.Users.GetWatchingAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserWatchingItem responseValue = response.Value;

            responseValue.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            responseValue.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            responseValue.Action.Should().Be(TraktHistoryActionType.Checkin);
            responseValue.Type.Should().Be(TraktSyncType.Movie);
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Super 8");
            responseValue.Movie.Year.Should().Be(2011);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(2U);
            responseValue.Movie.Ids.Slug.Should().Be("super-8-2011");
            responseValue.Movie.Ids.Imdb.Should().Be("tt1650062");
            responseValue.Movie.Ids.Tmdb.Should().Be(37686U);
            responseValue.Show.Should().BeNull();
            responseValue.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatching_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHING_URI, WATCHING_ITEM_MOVIE_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktResponse<ITraktUserWatchingItem> response = await client.Users.GetWatchingAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserWatchingItem responseValue = response.Value;

            responseValue.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            responseValue.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            responseValue.Action.Should().Be(TraktHistoryActionType.Checkin);
            responseValue.Type.Should().Be(TraktSyncType.Movie);
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Super 8");
            responseValue.Movie.Year.Should().Be(2011);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(2U);
            responseValue.Movie.Ids.Slug.Should().Be("super-8-2011");
            responseValue.Movie.Ids.Imdb.Should().Be("tt1650062");
            responseValue.Movie.Ids.Tmdb.Should().Be(37686U);
            responseValue.Show.Should().BeNull();
            responseValue.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatching_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHING_URI}?extended={EXTENDED_INFO}",
                WATCHING_ITEM_MOVIE_JSON);

            TraktResponse<ITraktUserWatchingItem> response = await client.Users.GetWatchingAsync(USERNAME, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserWatchingItem responseValue = response.Value;

            responseValue.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            responseValue.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            responseValue.Action.Should().Be(TraktHistoryActionType.Checkin);
            responseValue.Type.Should().Be(TraktSyncType.Movie);
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Super 8");
            responseValue.Movie.Year.Should().Be(2011);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(2U);
            responseValue.Movie.Ids.Slug.Should().Be("super-8-2011");
            responseValue.Movie.Ids.Imdb.Should().Be("tt1650062");
            responseValue.Movie.Ids.Tmdb.Should().Be(37686U);
            responseValue.Show.Should().BeNull();
            responseValue.Episode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatching_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, WATCHING_ITEM_MOVIE_JSON);

            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act = () => client.Users.GetWatchingAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetWatchingAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetWatchingAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
