namespace TraktNet.Tests.Modules.TraktCommentsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Comments")]
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

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktCommentNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentItem_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_ITEM_URI, COMMENT_JSON);

            Func<Task<TraktResponse<ITraktCommentItem>>> act = () => client.Comments.GetCommentItemAsync(0);
            act.Should().Throw<ArgumentException>();
        }
    }
}
