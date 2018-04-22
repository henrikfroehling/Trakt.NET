namespace TraktApiSharp.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        [Fact]
        public void Test_TraktUsersModule_GetWatching()
        {
            const string username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/watching", WATCHING_ITEM_MOVIE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync(username).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

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
        public void Test_TraktUsersModule_GetWatchingWithOAuthEnforced()
        {
            const string username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/watching", WATCHING_ITEM_MOVIE_JSON);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync(username).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

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
        public void Test_TraktUsersModule_GetWatchingComplete()
        {
            const string username = "sean";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/watching?extended={extendedInfo}", WATCHING_ITEM_MOVIE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync(username, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

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
        public void Test_TraktUsersModule_GetWatchingExceptions()
        {
            const string username = "sean";
            var uri = $"users/{username}/watching";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync(username);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchingArgumentExceptions()
        {
            Func<Task<TraktResponse<ITraktUserWatchingItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchingAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
