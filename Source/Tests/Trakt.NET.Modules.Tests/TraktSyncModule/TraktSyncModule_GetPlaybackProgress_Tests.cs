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
    using TraktNet.Requests.Parameters;
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
                GET_PLAYBACK_PROGRESS_URI, PLAYBACK_PROGRESS_JSON, 1, 10, 1, PLAYBACK_PROGRESS_ITEM_COUNT);

            TraktPagedResponse<ITraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.ItemCount.Should().HaveValue().And.Be(PLAYBACK_PROGRESS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPlaybackProgress_With_Type()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PLAYBACK_PROGRESS_URI}/{PLAYBACK_PROGRESS_TYPE.UriName}",
                PLAYBACK_PROGRESS_JSON, 1, 10, 1, PLAYBACK_PROGRESS_ITEM_COUNT);

            TraktPagedResponse<ITraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(PLAYBACK_PROGRESS_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.ItemCount.Should().HaveValue().And.Be(PLAYBACK_PROGRESS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPlaybackProgress_With_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PLAYBACK_PROGRESS_URI}?page={PAGE}",
                PLAYBACK_PROGRESS_JSON, 1, 10, 1, PLAYBACK_PROGRESS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.ItemCount.Should().HaveValue().And.Be(PLAYBACK_PROGRESS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPlaybackProgress_With_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PLAYBACK_PROGRESS_URI}?limit={PLAYBACK_PROGRESS_LIMIT}",
                PLAYBACK_PROGRESS_JSON, 1, 10, 1, PLAYBACK_PROGRESS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, PLAYBACK_PROGRESS_LIMIT);

            TraktPagedResponse<ITraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.ItemCount.Should().HaveValue().And.Be(PLAYBACK_PROGRESS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPlaybackProgress_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PLAYBACK_PROGRESS_URI}?page={PAGE}&limit={PLAYBACK_PROGRESS_LIMIT}",
                PLAYBACK_PROGRESS_JSON, 1, 10, 1, PLAYBACK_PROGRESS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, PLAYBACK_PROGRESS_LIMIT);

            TraktPagedResponse<ITraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.ItemCount.Should().HaveValue().And.Be(PLAYBACK_PROGRESS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPlaybackProgress_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PLAYBACK_PROGRESS_URI}/{PLAYBACK_PROGRESS_TYPE.UriName}?page={PAGE}&limit={PLAYBACK_PROGRESS_LIMIT}",
                PLAYBACK_PROGRESS_JSON, 1, 10, 1, PLAYBACK_PROGRESS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, PLAYBACK_PROGRESS_LIMIT);

            TraktPagedResponse<ITraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(PLAYBACK_PROGRESS_TYPE, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.ItemCount.Should().HaveValue().And.Be(PLAYBACK_PROGRESS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
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
        public async Task Test_TraktSyncModule_GetPlaybackProgress_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PLAYBACK_PROGRESS_URI, statusCode);

            try
            {
                await client.Sync.GetPlaybackProgressAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
