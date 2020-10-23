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
        public async Task Test_TraktSyncModule_RemoveRatings_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_RATINGS_URI, statusCode);

            try
            {
                await client.Sync.RemoveRatingsAsync(RemoveRatingsPost);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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
