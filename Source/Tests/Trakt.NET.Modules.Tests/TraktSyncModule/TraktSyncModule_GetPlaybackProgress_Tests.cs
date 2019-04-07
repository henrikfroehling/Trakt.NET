namespace TraktNet.Modules.Tests.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Syncs.Playback;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string GET_PLAYBACK_PROGRESS_URI = "sync/playback";

        [Fact]
        public async Task Test_TraktSyncModule_GetPlaybackProgress()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_PLAYBACK_PROGRESS_URI,
                PLAYBACK_PROGRESS_JSON);

            TraktListResponse<ITraktSyncPlaybackProgressItem> response =
                await client.Sync.GetPlaybackProgressAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPlaybackProgress_With_Type()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PLAYBACK_PROGRESS_URI}/{PLAYBACK_PROGRESS_TYPE.UriName}",
                PLAYBACK_PROGRESS_JSON);

            TraktListResponse<ITraktSyncPlaybackProgressItem> response =
                await client.Sync.GetPlaybackProgressAsync(PLAYBACK_PROGRESS_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPlaybackProgress_With_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PLAYBACK_PROGRESS_URI}?limit={PLAYBACK_PROGRESS_LIMIT}",
                PLAYBACK_PROGRESS_JSON);

            TraktListResponse<ITraktSyncPlaybackProgressItem> response =
                await client.Sync.GetPlaybackProgressAsync(null, PLAYBACK_PROGRESS_LIMIT);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPlaybackProgress_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PLAYBACK_PROGRESS_URI}/{PLAYBACK_PROGRESS_TYPE.UriName}?limit={PLAYBACK_PROGRESS_LIMIT}",
                PLAYBACK_PROGRESS_JSON);

            TraktListResponse<ITraktSyncPlaybackProgressItem> response =
                await client.Sync.GetPlaybackProgressAsync(PLAYBACK_PROGRESS_TYPE, PLAYBACK_PROGRESS_LIMIT);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetPlaybackProgress_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
