namespace TraktNet.Modules.Tests.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using TraktNet.Objects.Post.Syncs.Watchlist.Responses;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string REMOVE_WATCHLIST_ITEMS_URI = "sync/watchlist/remove";

        [Fact]
        public async Task Test_TraktSyncModule_RemoveWatchlistItems()
        {
            string postJson = await TestUtility.SerializeObject(RemoveWatchlistPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHLIST_ITEMS_URI, postJson, WATCHLIST_REMOVE_POST_RESPONSE_JSON);
            TraktResponse<ITraktSyncWatchlistRemovePostResponse> response = await client.Sync.RemoveWatchlistItemsAsync(RemoveWatchlistPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktSyncWatchlistRemovePostResponse responseValue = response.Value;

            responseValue.Deleted.Should().NotBeNull();
            responseValue.Deleted.Movies.Should().Be(1);
            responseValue.Deleted.Episodes.Should().Be(2);
            responseValue.Deleted.Shows.Should().Be(1);
            responseValue.Deleted.Seasons.Should().Be(1);

            responseValue.NotFound.Should().NotBeNull();
            responseValue.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktPostResponseNotFoundMovie[] movies = responseValue.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            responseValue.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            responseValue.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            responseValue.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
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
        public async Task Test_TraktSyncModule_RemoveWatchlistItems_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHLIST_ITEMS_URI, statusCode);

            try
            {
                await client.Sync.RemoveWatchlistItemsAsync(RemoveWatchlistPost);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktSyncModule_RemoveWatchlistItems_ArgumentExceptions()
        {
            string postJson = await TestUtility.SerializeObject(RemoveWatchlistPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHLIST_ITEMS_URI, postJson, WATCHLIST_REMOVE_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktSyncWatchlistRemovePostResponse>>> act = () => client.Sync.RemoveWatchlistItemsAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Sync.RemoveWatchlistItemsAsync(new TraktSyncWatchlistPost());
            await act.Should().ThrowAsync<TraktPostValidationException>();
        }
    }
}
