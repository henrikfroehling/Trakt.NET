namespace TraktNet.Tests.Modules.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Sync")]
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

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetLastActivities_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_LAST_ACTIVITIES_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
