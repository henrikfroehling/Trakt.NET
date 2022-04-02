namespace TraktNet.Modules.Tests.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Basic;
    using TraktNet.Objects.Post.Basic.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string REORDER_WATCHLIST_ITEMS_URI = "sync/watchlist/reorder";

        [Fact]
        public async Task Test_TraktSyncModule_ReorderWatchlistItems()
        {
            ITraktListItemsReorderPost watchlistItemsReorderPost = new TraktListItemsReorderPost
            {
                Rank = REORDERED_ITEMS
            };

            string postJson = await TestUtility.SerializeObject(watchlistItemsReorderPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_WATCHLIST_ITEMS_URI, postJson, ITEMS_REORDER_POST_RESPONSE_JSON);
            TraktResponse<ITraktListItemsReorderPostResponse> response = await client.Sync.ReorderWatchlistItemsAsync(REORDERED_ITEMS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktListItemsReorderPostResponse responseValue = response.Value;

            responseValue.Updated.Should().Be(6);
            responseValue.SkippedIds.Should().NotBeNull().And.HaveCount(1);
            responseValue.SkippedIds.Should().BeEquivalentTo(new List<uint> { 12 });
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
        public async Task Test_TraktSyncModule_ReorderWatchlistItems_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_WATCHLIST_ITEMS_URI, statusCode);

            try
            {
                await client.Sync.ReorderWatchlistItemsAsync(REORDERED_ITEMS);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktSyncModule_ReorderWatchlistItems_ArgumentExceptions()
        {
            ITraktListItemsReorderPost watchlistItemsReorderPost = new TraktListItemsReorderPost
            {
                Rank = REORDERED_ITEMS
            };

            string postJson = await TestUtility.SerializeObject(watchlistItemsReorderPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REORDER_WATCHLIST_ITEMS_URI, postJson, ITEMS_REORDER_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktListItemsReorderPostResponse>>> act = () => client.Sync.ReorderWatchlistItemsAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
