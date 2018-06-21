namespace TraktNet.Tests.Modules.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using TraktNet.Objects.Post.Syncs.Ratings.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string REMOVE_RATINGS_URI = "sync/ratings/remove";

        [Fact]
        public async Task Test_TraktSyncModule_RemoveRatings()
        {
            string postJson = await TestUtility.SerializeObject(RemoveRatingsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, postJson, RATINGS_REMOVE_POST_RESPONSE_JSON);
            TraktResponse<ITraktSyncRatingsRemovePostResponse> response = await client.Sync.RemoveRatingsAsync(RemoveRatingsPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktSyncRatingsRemovePostResponse responseValue = response.Value;

            responseValue.Deleted.Should().NotBeNull();
            responseValue.Deleted.Movies.Should().Be(1);
            responseValue.Deleted.Episodes.Should().Be(4);
            responseValue.Deleted.Shows.Should().Be(2);
            responseValue.Deleted.Seasons.Should().Be(3);

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
        public void Test_TraktSyncModule_RemoveRatings_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveRatings_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktSyncModule_RemoveRatings_ArgumentExceptions()
        {
            string postJson = await TestUtility.SerializeObject(RemoveRatingsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, postJson, RATINGS_REMOVE_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktSyncRatingsRemovePostResponse>>> act = () => client.Sync.RemoveRatingsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Sync.RemoveRatingsAsync(new TraktSyncRatingsPost());
            act.Should().Throw<ArgumentException>();

            ITraktSyncRatingsPost ratingsRemovePost = new TraktSyncRatingsPost
            {
                Movies = new List<ITraktSyncRatingsPostMovie>(),
                Shows = new List<ITraktSyncRatingsPostShow>(),
                Episodes = new List<ITraktSyncRatingsPostEpisode>()
            };

            act = () => client.Sync.RemoveRatingsAsync(ratingsRemovePost);
            act.Should().Throw<ArgumentException>();
        }
    }
}
