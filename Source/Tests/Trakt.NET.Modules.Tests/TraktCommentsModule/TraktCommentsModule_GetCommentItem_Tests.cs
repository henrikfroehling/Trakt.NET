namespace TraktNet.Modules.Tests.TraktCommentsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Comments")]
    public partial class TraktCommentsModule_Tests
    {
        private readonly string GET_COMMENT_ITEM_URI = $"comments/{GET_COMMENT_ID}/item";

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentItem()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, COMMENT_ITEM_JSON);
            TraktResponse<ITraktCommentItem> response = await client.Comments.GetCommentItemAsync(GET_COMMENT_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCommentItem responseValue = response.Value;

            responseValue.Type.Should().Be(TraktObjectType.Show);
            responseValue.Movie.Should().BeNull();
            responseValue.Season.Should().BeNull();
            responseValue.Episode.Should().BeNull();
            responseValue.List.Should().BeNull();
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("The Flash");
            responseValue.Show.Year.Should().Be(2014);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(60300U);
            responseValue.Show.Ids.Slug.Should().Be("the-flash-2014");
            responseValue.Show.Ids.Tvdb.Should().Be(279121U);
            responseValue.Show.Ids.Imdb.Should().Be("tt3107288");
            responseValue.Show.Ids.Tmdb.Should().Be(60735U);
            responseValue.Show.Ids.TvRage.Should().Be(36939U);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentItem_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_COMMENT_ITEM_URI}?extended={EXTENDED_INFO}", COMMENT_ITEM_JSON);
            TraktResponse<ITraktCommentItem> response = await client.Comments.GetCommentItemAsync(GET_COMMENT_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCommentItem responseValue = response.Value;

            responseValue.Type.Should().Be(TraktObjectType.Show);
            responseValue.Movie.Should().BeNull();
            responseValue.Season.Should().BeNull();
            responseValue.Episode.Should().BeNull();
            responseValue.List.Should().BeNull();
            responseValue.Show.Should().NotBeNull();
            responseValue.Show.Title.Should().Be("The Flash");
            responseValue.Show.Year.Should().Be(2014);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(60300U);
            responseValue.Show.Ids.Slug.Should().Be("the-flash-2014");
            responseValue.Show.Ids.Tvdb.Should().Be(279121U);
            responseValue.Show.Ids.Imdb.Should().Be("tt3107288");
            responseValue.Show.Ids.Tmdb.Should().Be(60735U);
            responseValue.Show.Ids.TvRage.Should().Be(36939U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktCommentNotFoundException))]
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
        public async Task Test_TraktCommentsModule_GetCommentItem_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, statusCode);

            try
            {
                await client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentItem_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, COMMENT_JSON);

            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
