namespace TraktApiSharp.Tests.Modules.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Syncs.Collection;
    using TraktApiSharp.Objects.Post.Syncs.Collection.Responses;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string REMOVE_COLLECTION_ITEMS_URI = "sync/collection/remove";

        [Fact]
        public async Task Test_TraktSyncModule_RemoveCollectionItems()
        {
            string postJson = await TestUtility.SerializeObject(RemoveCollectionItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, postJson, COLLECTION_REMOVE_POST_RESPONSE_JSON);
            TraktResponse<ITraktSyncCollectionRemovePostResponse> response = await client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktSyncCollectionRemovePostResponse responseValue = response.Value;

            responseValue.Deleted.Should().NotBeNull();
            responseValue.Deleted.Movies.Should().Be(1);
            responseValue.Deleted.Episodes.Should().Be(12);
            responseValue.Deleted.Shows.Should().NotHaveValue();
            responseValue.Deleted.Seasons.Should().NotHaveValue();

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
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_RemoveCollectionItems_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(RemoveCollectionItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktSyncModule_RemoveCollectionItems_ArgumentExceptions()
        {
            string postJson = await TestUtility.SerializeObject(RemoveCollectionItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(REMOVE_COLLECTION_ITEMS_URI, postJson, COLLECTION_REMOVE_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktSyncCollectionRemovePostResponse>>> act = () => client.Sync.RemoveCollectionItemsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Sync.RemoveCollectionItemsAsync(new TraktSyncCollectionPost());
            act.Should().Throw<ArgumentException>();

            ITraktSyncCollectionPost collectionRemovePost = new TraktSyncCollectionPost
            {
                Movies = new List<ITraktSyncCollectionPostMovie>(),
                Shows = new List<ITraktSyncCollectionPostShow>(),
                Episodes = new List<ITraktSyncCollectionPostEpisode>()
            };

            act = () => client.Sync.RemoveCollectionItemsAsync(collectionRemovePost);
            act.Should().Throw<ArgumentException>();
        }
    }
}
