namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_WATCHING_URI = $"users/{USERNAME}/watching";

        [Fact]
        public async Task Test_TraktUsersModule_GetWatching()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, WATCHING_ITEM_MOVIE_JSON);
            TraktResponse<ITraktUserWatchingItem> response = await client.Users.GetWatchingAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserWatchingItem responseValue = response.Value;

            responseValue.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            responseValue.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            responseValue.Action.Should().Be(TraktHistoryActionType.Checkin);
            responseValue.Type.Should().Be(TraktSyncType.Movie);
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Super 8");
            responseValue.Movie.Year.Should().Be(2011);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(2U);
            responseValue.Movie.Ids.Slug.Should().Be("super-8-2011");
            responseValue.Movie.Ids.Imdb.Should().Be("tt1650062");
            responseValue.Movie.Ids.Tmdb.Should().Be(37686U);
            responseValue.Show.Should().BeNull();
            responseValue.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatching_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHING_URI, WATCHING_ITEM_MOVIE_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktResponse<ITraktUserWatchingItem> response = await client.Users.GetWatchingAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserWatchingItem responseValue = response.Value;

            responseValue.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            responseValue.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            responseValue.Action.Should().Be(TraktHistoryActionType.Checkin);
            responseValue.Type.Should().Be(TraktSyncType.Movie);
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Super 8");
            responseValue.Movie.Year.Should().Be(2011);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(2U);
            responseValue.Movie.Ids.Slug.Should().Be("super-8-2011");
            responseValue.Movie.Ids.Imdb.Should().Be("tt1650062");
            responseValue.Movie.Ids.Tmdb.Should().Be(37686U);
            responseValue.Show.Should().BeNull();
            responseValue.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatching_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHING_URI}?extended={EXTENDED_INFO}",
                WATCHING_ITEM_MOVIE_JSON);

            TraktResponse<ITraktUserWatchingItem> response = await client.Users.GetWatchingAsync(USERNAME, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserWatchingItem responseValue = response.Value;

            responseValue.ExpiresAt.Should().Be(DateTime.Parse("2014-10-23T08:36:02.000Z").ToUniversalTime());
            responseValue.StartedAt.Should().Be(DateTime.Parse("2014-10-23T06:44:02.000Z").ToUniversalTime());
            responseValue.Action.Should().Be(TraktHistoryActionType.Checkin);
            responseValue.Type.Should().Be(TraktSyncType.Movie);
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Super 8");
            responseValue.Movie.Year.Should().Be(2011);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(2U);
            responseValue.Movie.Ids.Slug.Should().Be("super-8-2011");
            responseValue.Movie.Ids.Imdb.Should().Be("tt1650062");
            responseValue.Movie.Ids.Tmdb.Should().Be(37686U);
            responseValue.Show.Should().BeNull();
            responseValue.Episode.Should().BeNull();
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
        public async Task Test_TraktUsersModule_GetWatching_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHING_URI, statusCode);

            try
            {
                await client.Users.GetWatchingAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
