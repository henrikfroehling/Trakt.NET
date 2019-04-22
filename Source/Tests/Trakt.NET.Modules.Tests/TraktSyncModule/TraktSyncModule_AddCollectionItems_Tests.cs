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
    using TraktNet.Objects.Post.Syncs.Collection;
    using TraktNet.Objects.Post.Syncs.Collection.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string ADD_COLLECTION_ITEMS_URI = "sync/collection";

        [Fact]
        public async Task Test_TraktSyncModule_AddCollectionItems()
        {
            string postJson = await TestUtility.SerializeObject(AddCollectionItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, postJson, COLLECTION_POST_RESPONSE_JSON);
            TraktResponse<ITraktSyncCollectionPostResponse> response = await client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktSyncCollectionPostResponse responseValue = response.Value;

            responseValue.Added.Should().NotBeNull();
            responseValue.Added.Movies.Should().Be(1);
            responseValue.Added.Episodes.Should().Be(12);
            responseValue.Added.Shows.Should().NotHaveValue();
            responseValue.Added.Seasons.Should().NotHaveValue();

            responseValue.Updated.Should().NotBeNull();
            responseValue.Updated.Movies.Should().Be(3);
            responseValue.Updated.Episodes.Should().Be(1);
            responseValue.Updated.Shows.Should().NotHaveValue();
            responseValue.Updated.Seasons.Should().NotHaveValue();

            responseValue.Existing.Should().NotBeNull();
            responseValue.Existing.Movies.Should().Be(2);
            responseValue.Existing.Episodes.Should().Be(0);
            responseValue.Existing.Shows.Should().NotHaveValue();
            responseValue.Existing.Seasons.Should().NotHaveValue();

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
        public void Test_TraktSyncModule_AddCollectionItems_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddCollectionItems_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(AddCollectionItemsPost);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktSyncModule_AddCollectionItems_ArgumentExceptions()
        {
            string postJson = await TestUtility.SerializeObject(AddCollectionItemsPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(ADD_COLLECTION_ITEMS_URI, postJson, COLLECTION_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktSyncCollectionPostResponse>>> act = () => client.Sync.AddCollectionItemsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Sync.AddCollectionItemsAsync(new TraktSyncCollectionPost());
            act.Should().Throw<ArgumentException>();

            ITraktSyncCollectionPost collectionPost = new TraktSyncCollectionPost
            {
                Movies = new List<ITraktSyncCollectionPostMovie>(),
                Shows = new List<ITraktSyncCollectionPostShow>(),
                Episodes = new List<ITraktSyncCollectionPostEpisode>()
            };

            act = () => client.Sync.AddCollectionItemsAsync(collectionPost);
            act.Should().Throw<ArgumentException>();
        }
    }
}
