namespace TraktNet.Modules.Tests.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string GET_LAST_ACTIVITIES_URI = "sync/last_activities";

        [Fact]
        public async Task Test_TraktSyncModule_GetLastActivities()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, LAST_ACTIVITIES_JSON);
            TraktResponse<ITraktSyncLastActivities> response = await client.Sync.GetLastActivitiesAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktSyncLastActivities responseValue = response.Value;

            responseValue.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());
            responseValue.Movies.Should().NotBeNull();
            responseValue.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
            responseValue.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
            responseValue.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
            responseValue.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
            responseValue.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            responseValue.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            responseValue.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

            responseValue.Episodes.Should().NotBeNull();
            responseValue.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            responseValue.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            responseValue.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            responseValue.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            responseValue.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            responseValue.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

            responseValue.Shows.Should().NotBeNull();
            responseValue.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
            responseValue.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
            responseValue.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
            responseValue.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
            responseValue.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
            responseValue.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
            responseValue.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

            responseValue.Comments.Should().NotBeNull();
            responseValue.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

            responseValue.Lists.Should().NotBeNull();
            responseValue.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
            responseValue.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
            responseValue.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
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
        public async Task Test_TraktSyncModule_GetLastActivities_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, statusCode);

            try
            {
                await client.Sync.GetLastActivitiesAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
