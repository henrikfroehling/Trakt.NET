namespace TraktNet.Modules.Tests.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Post.Syncs.Lists;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private readonly string UPDATE_FAVORITES_URI = $"sync/favorites";
        private const string NewDescription = "new description";
        private readonly TraktSortBy NewSortBy = TraktSortBy.Rank;
        private readonly TraktSortHow NewSortHow = TraktSortHow.Descending;

        [Fact]
        public async Task Test_TraktSyncModule_UpdateFavorites()
        {
            ITraktUpdateListPost updateListPost = new TraktUpdateListPost
            {
                Description = NewDescription,
                SortBy = NewSortBy,
                SortHow = NewSortHow
            };

            string postJson = await TestUtility.SerializeObject(updateListPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_FAVORITES_URI, postJson, UPDATED_LIST_JSON);
            TraktResponse<ITraktList> response = await client.Sync.UpdateFavoritesAsync(NewDescription, NewSortBy, NewSortHow);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
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
        public async Task Test_TraktSyncModule_UpdateFavorites_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UPDATE_FAVORITES_URI, statusCode);

            try {
                await client.Sync.UpdateFavoritesAsync(NewDescription, NewSortBy, NewSortHow);
                Assert.False(true);
            } catch (Exception exception) {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
