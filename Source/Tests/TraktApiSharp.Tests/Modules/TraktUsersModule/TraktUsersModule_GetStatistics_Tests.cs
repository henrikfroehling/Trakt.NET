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
        private readonly string GET_STATISTICS_URI = $"users/{USERNAME}/stats";

        [Fact]
        public async Task Test_TraktUsersModule_GetStatistics()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, STATISTICS_JSON);
            TraktResponse<ITraktUserStatistics> response = await client.Users.GetStatisticsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserStatistics responseValue = response.Value;

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

            IDictionary<string, int> distribution = new Dictionary<string, int>()
            {
                { "1",  18 }, { "2", 1 }, { "3", 4 }, { "4", 1 }, { "5", 10 },
                { "6",  9 }, { "7", 37 }, { "8", 37 }, { "9", 57 }, { "10", 215 }
            };

            responseValue.Ratings.Distribution.Should().NotBeNull().And.HaveCount(10).And.Contain(distribution);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetStatistics_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_STATISTICS_URI, STATISTICS_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktResponse<ITraktUserStatistics> response = await client.Users.GetStatisticsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserStatistics responseValue = response.Value;

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

            IDictionary<string, int> distribution = new Dictionary<string, int>()
            {
                { "1",  18 }, { "2", 1 }, { "3", 4 }, { "4", 1 }, { "5", 10 },
                { "6",  9 }, { "7", 37 }, { "8", 37 }, { "9", 57 }, { "10", 215 }
            };

            responseValue.Ratings.Distribution.Should().NotBeNull().And.HaveCount(10).And.Contain(distribution);
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetStatistics_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, STATISTICS_JSON);

            Func<Task<TraktResponse<ITraktUserStatistics>>> act = () => client.Users.GetStatisticsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetStatisticsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetStatisticsAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
