namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users.Statistics;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
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
        public async Task Test_TraktUsersModule_GetStatistics_With_OAuth_Enforced_For_Username_Me()
        {
            TraktClient client = TestUtility.GetOAuthMockClient("users/me/stats", STATISTICS_JSON);
            TraktResponse<ITraktUserStatistics> response = await client.Users.GetStatisticsAsync("me");

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
        public async Task Test_TraktUsersModule_GetStatistics_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_STATISTICS_URI, statusCode);

            try
            {
                await client.Users.GetStatisticsAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
