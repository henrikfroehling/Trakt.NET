namespace TraktNet.Modules.Tests.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Syncs.History;
    using TraktNet.Objects.Post.Syncs.History.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string REMOVE_WATCHED_HISTORY_ITEMS_URI = "sync/history/remove";

        [Fact]
        public async Task Test_TraktSyncModule_RemoveWatchedHistoryItems()
        {
            string postJson = await TestUtility.SerializeObject(RemoveHistoryPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, postJson, HISTORY_REMOVE_POST_RESPONSE_JSON);
            TraktResponse<ITraktSyncHistoryRemovePostResponse> response = await client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktSyncHistoryRemovePostResponse responseValue = response.Value;

            responseValue.Deleted.Should().NotBeNull();
            responseValue.Deleted.Movies.Should().Be(2);
            responseValue.Deleted.Episodes.Should().Be(72);
            responseValue.Deleted.Shows.Should().NotHaveValue();
            responseValue.Deleted.Seasons.Should().NotHaveValue();

            responseValue.NotFound.Should().NotBeNull();
            responseValue.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktPostResponseNotFoundMovie[] movies = responseValue.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0U);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            responseValue.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            responseValue.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            responseValue.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();

            responseValue.NotFound.HistoryIds.Should().NotBeNull().And.HaveCount(2);
            responseValue.NotFound.HistoryIds.Should().Contain(new List<ulong>() { 23, 42 });
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
        public async Task Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, statusCode);

            try
            {
                await client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktSyncModule_RemoveWatchedHistoryItems_ArgumentExceptions()
        {
            string postJson = await TestUtility.SerializeObject(RemoveHistoryPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, postJson, HISTORY_REMOVE_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Sync.RemoveWatchedHistoryItemsAsync(new TraktSyncHistoryRemovePost());
            act.Should().Throw<ArgumentException>();

            ITraktSyncHistoryRemovePost collectionPost = new TraktSyncHistoryRemovePost
            {
                Movies = new List<ITraktSyncHistoryPostMovie>(),
                Shows = new List<ITraktSyncHistoryPostShow>(),
                Episodes = new List<ITraktSyncHistoryPostEpisode>()
            };

            act = () => client.Sync.RemoveWatchedHistoryItemsAsync(collectionPost);
            act.Should().Throw<ArgumentException>();
        }
    }
}
