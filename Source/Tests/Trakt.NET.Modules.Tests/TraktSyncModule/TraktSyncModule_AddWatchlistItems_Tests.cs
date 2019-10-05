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
        public async Task Test_TraktSyncModule_AddWatchlistItems_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_WATCHLIST_ITEMS_URI, statusCode);

            try
            {
                await client.Sync.AddWatchlistItemsAsync(AddWatchlistPost);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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
