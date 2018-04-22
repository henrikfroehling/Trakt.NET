namespace TraktApiSharp.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        [Fact]
        public void Test_TraktUsersModule_GetStatistics()
        {
            const string username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}/stats", STATISTICS_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetStatisticsAsync(username).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Movies.Should().NotBeNull();
            responseValue.Movies.Plays.Should().Be(155);
            responseValue.Movies.Watched.Should().Be(114);
            responseValue.Movies.Minutes.Should().Be(15650);
            responseValue.Movies.Collected.Should().Be(933);
            responseValue.Movies.Ratings.Should().Be(256);
            responseValue.Movies.Comments.Should().Be(28);

            responseValue.Shows.Should().NotBeNull();
            responseValue.Shows.Watched.Should().Be(16);
            responseValue.Shows.Collected.Should().Be(7);
            responseValue.Shows.Ratings.Should().Be(63);
            responseValue.Shows.Comments.Should().Be(20);

            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Ratings.Should().Be(6);
            responseValue.Seasons.Comments.Should().Be(1);

            responseValue.Episodes.Should().NotBeNull();
            responseValue.Episodes.Plays.Should().Be(552);
            responseValue.Episodes.Watched.Should().Be(534);
            responseValue.Episodes.Minutes.Should().Be(17330);
            responseValue.Episodes.Collected.Should().Be(117);
            responseValue.Episodes.Ratings.Should().Be(64);
            responseValue.Episodes.Comments.Should().Be(14);

            responseValue.Network.Should().NotBeNull();
            responseValue.Network.Friends.Should().Be(1);
            responseValue.Network.Followers.Should().Be(4);
            responseValue.Network.Following.Should().Be(11);

            responseValue.Ratings.Should().NotBeNull();
            responseValue.Ratings.Total.Should().Be(389);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  18 }, { "2", 1 }, { "3", 4 }, { "4", 1 }, { "5", 10 },
                { "6",  9 }, { "7", 37 }, { "8", 37 }, { "9", 57 }, { "10", 215 }
            };

            responseValue.Ratings.Distribution.Should().NotBeNull().And.HaveCount(10).And.Contain(distribution);
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatisticsWithOAuthEnforced()
        {
            const string username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}/stats", STATISTICS_JSON);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetStatisticsAsync(username).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Movies.Should().NotBeNull();
            responseValue.Movies.Plays.Should().Be(155);
            responseValue.Movies.Watched.Should().Be(114);
            responseValue.Movies.Minutes.Should().Be(15650);
            responseValue.Movies.Collected.Should().Be(933);
            responseValue.Movies.Ratings.Should().Be(256);
            responseValue.Movies.Comments.Should().Be(28);

            responseValue.Shows.Should().NotBeNull();
            responseValue.Shows.Watched.Should().Be(16);
            responseValue.Shows.Collected.Should().Be(7);
            responseValue.Shows.Ratings.Should().Be(63);
            responseValue.Shows.Comments.Should().Be(20);

            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Ratings.Should().Be(6);
            responseValue.Seasons.Comments.Should().Be(1);

            responseValue.Episodes.Should().NotBeNull();
            responseValue.Episodes.Plays.Should().Be(552);
            responseValue.Episodes.Watched.Should().Be(534);
            responseValue.Episodes.Minutes.Should().Be(17330);
            responseValue.Episodes.Collected.Should().Be(117);
            responseValue.Episodes.Ratings.Should().Be(64);
            responseValue.Episodes.Comments.Should().Be(14);

            responseValue.Network.Should().NotBeNull();
            responseValue.Network.Friends.Should().Be(1);
            responseValue.Network.Followers.Should().Be(4);
            responseValue.Network.Following.Should().Be(11);

            responseValue.Ratings.Should().NotBeNull();
            responseValue.Ratings.Total.Should().Be(389);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  18 }, { "2", 1 }, { "3", 4 }, { "4", 1 }, { "5", 10 },
                { "6",  9 }, { "7", 37 }, { "8", 37 }, { "9", 57 }, { "10", 215 }
            };

            responseValue.Ratings.Distribution.Should().NotBeNull().And.HaveCount(10).And.Contain(distribution);
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatisticsExceptions()
        {
            const string username = "sean";
            var uri = $"users/{username}/stats";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktUserStatistics>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetStatisticsAsync(username);
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
        public void Test_TraktUsersModule_GetStatisticsArgumentExceptions()
        {
            Func<Task<TraktResponse<ITraktUserStatistics>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetStatisticsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetStatisticsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetStatisticsAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
