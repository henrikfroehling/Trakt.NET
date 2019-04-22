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
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using TraktNet.Objects.Post.Syncs.Watchlist.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string ADD_WATCHLIST_ITEMS_URI = "sync/watchlist";

        [Fact]
        public async Task Test_TraktSyncModule_AddWatchlistItems()
        {
            string postJson = await TestUtility.SerializeObject(AddWatchlistPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, postJson, WATCHLIST_POST_RESPONSE_JSON);
            TraktResponse<ITraktSyncWatchlistPostResponse> response = await client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktSyncWatchlistPostResponse responseValue = response.Value;

            responseValue.Added.Should().NotBeNull();
            responseValue.Added.Movies.Should().Be(1);
            responseValue.Added.Episodes.Should().Be(2);
            responseValue.Added.Shows.Should().Be(1);
            responseValue.Added.Seasons.Should().Be(1);

            responseValue.Existing.Should().NotBeNull();
            responseValue.Existing.Movies.Should().Be(0);
            responseValue.Existing.Episodes.Should().Be(0);
            responseValue.Existing.Shows.Should().Be(1);
            responseValue.Existing.Seasons.Should().Be(0);

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
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchlistItems_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktSyncModule_AddWatchlistItems_ArgumentExceptions()
        {
            string postJson = await TestUtility.SerializeObject(AddWatchlistPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, postJson, WATCHLIST_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktSyncWatchlistPostResponse>>> act = () => client.Sync.AddWatchlistItemsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Sync.AddWatchlistItemsAsync(new TraktSyncWatchlistPost());
            act.Should().Throw<ArgumentException>();

            ITraktSyncWatchlistPost watchlistPost = new TraktSyncWatchlistPost
            {
                Movies = new List<ITraktSyncWatchlistPostMovie>(),
                Shows = new List<ITraktSyncWatchlistPostShow>(),
                Episodes = new List<ITraktSyncWatchlistPostEpisode>()
            };

            act = () => client.Sync.AddWatchlistItemsAsync(watchlistPost);
            act.Should().Throw<ArgumentException>();
        }
    }
}
