namespace TraktApiSharp.Tests.Modules.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string GET_COLLECTION_MOVIES_URI = "sync/collection/movies";

        [Fact]
        public async Task Test_TraktSyncModule_GetCollectionMovies()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, COLLECTION_MOVIES_JSON);
            TraktListResponse<ITraktCollectionMovie> response = await client.Sync.GetCollectionMoviesAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetCollectionMovies_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_COLLECTION_MOVIES_URI}?extended={EXTENDED_INFO}",
                COLLECTION_MOVIES_JSON);

            TraktListResponse<ITraktCollectionMovie> response = await client.Sync.GetCollectionMoviesAsync(EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetCollectionMovies_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_COLLECTION_MOVIES_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktCollectionMovie>>> act = () => client.Sync.GetCollectionMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
