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

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveWatchedHistoryItems_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktSyncHistoryRemovePostResponse>>> act = () => client.Sync.RemoveWatchedHistoryItemsAsync(RemoveHistoryPost);
            act.Should().Throw<TraktServerUnavailableException>();
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
