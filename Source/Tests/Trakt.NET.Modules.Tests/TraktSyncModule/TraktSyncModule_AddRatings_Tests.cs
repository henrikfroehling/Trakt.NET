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
    using TraktNet.Objects.Post.Syncs.Ratings;
    using TraktNet.Objects.Post.Syncs.Ratings.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string ADD_RATINGS_URI = "sync/ratings";

        [Fact]
        public async Task Test_TraktSyncModule_AddRatings()
        {
            string postJson = await TestUtility.SerializeObject(AddRatingsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, postJson, RATINGS_POST_RESPONSE_JSON);
            TraktResponse<ITraktSyncRatingsPostResponse> response = await client.Sync.AddRatingsAsync(AddRatingsPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktSyncRatingsPostResponse responseValue = response.Value;

            responseValue.Added.Should().NotBeNull();
            responseValue.Added.Movies.Should().Be(1);
            responseValue.Added.Episodes.Should().Be(4);
            responseValue.Added.Shows.Should().Be(2);
            responseValue.Added.Seasons.Should().Be(3);

            responseValue.NotFound.Should().NotBeNull();
            responseValue.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostResponseNotFoundMovie[] movies = responseValue.NotFound.Movies.ToArray();

            movies[0].Rating.Should().Be(10);
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
        public void Test_TraktSyncModule_AddRatings_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddRatings_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act = () => client.Sync.AddRatingsAsync(AddRatingsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktSyncModule_AddRatings_ArgumentExceptions()
        {
            string postJson = await TestUtility.SerializeObject(AddRatingsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(ADD_RATINGS_URI, postJson, RATINGS_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktSyncRatingsPostResponse>>> act =() => client.Sync.AddRatingsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Sync.AddRatingsAsync(new TraktSyncRatingsPost());
            act.Should().Throw<ArgumentException>();

            ITraktSyncRatingsPost ratingsPost = new TraktSyncRatingsPost
            {
                Movies = new List<ITraktSyncRatingsPostMovie>(),
                Shows = new List<ITraktSyncRatingsPostShow>(),
                Episodes = new List<ITraktSyncRatingsPostEpisode>()
            };

            act = () => client.Sync.AddRatingsAsync(ratingsPost);
            act.Should().Throw<ArgumentException>();
        }
    }
}
