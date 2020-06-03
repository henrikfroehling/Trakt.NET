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
        private const string ADD_WATCHED_HISTORY_ITEMS_URI = "sync/history";

        [Fact]
        public async Task Test_TraktSyncModule_AddWatchedHistoryItems()
        {
            string postJson = await TestUtility.SerializeObject(AddHistoryPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, postJson, HISTORY_POST_RESPONSE_JSON);
            TraktResponse<ITraktSyncHistoryPostResponse> response = await client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktSyncHistoryPostResponse responseValue = response.Value;

            responseValue.Added.Should().NotBeNull();
            responseValue.Added.Movies.Should().Be(2);
            responseValue.Added.Episodes.Should().Be(72);
            responseValue.Added.Shows.Should().NotHaveValue();
            responseValue.Added.Seasons.Should().NotHaveValue();

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

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItems_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(AddHistoryPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktSyncModule_AddWatchedHistoryItems_ArgumentExceptions()
        {
            string postJson = await TestUtility.SerializeObject(AddHistoryPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHED_HISTORY_ITEMS_URI, postJson, HISTORY_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act = () => client.Sync.AddWatchedHistoryItemsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Sync.AddWatchedHistoryItemsAsync(new TraktSyncHistoryPost());
            act.Should().Throw<ArgumentException>();

            ITraktSyncHistoryPost collectionPost = new TraktSyncHistoryPost
            {
                Movies = new List<ITraktSyncHistoryPostMovie>(),
                Shows = new List<ITraktSyncHistoryPostShow>(),
                Episodes = new List<ITraktSyncHistoryPostEpisode>()
            };

            act = () => client.Sync.AddWatchedHistoryItemsAsync(collectionPost);
            act.Should().Throw<ArgumentException>();
        }
    }
}
