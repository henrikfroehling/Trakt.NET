namespace TraktApiSharp.Tests.Modules.TraktCommentsModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Comments")]
    public partial class TraktCommentsModule_Tests
    {
        private readonly string GET_COMMENT_URI = $"comments/{GET_COMMENT_ID}";

        [Fact]
        public async Task Test_TraktCommentsModule_GetComment()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, COMMENT_JSON);
            TraktResponse<ITraktComment> response = await client.Comments.GetCommentAsync(GET_COMMENT_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktComment responseValue = response.Value;

            responseValue.Id.Should().Be(GET_COMMENT_ID);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            responseValue.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(1);
            responseValue.Likes.Should().Be(2);
            responseValue.UserRating.Should().Be(7.3f);
            responseValue.User.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktCommentNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetComment_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, COMMENT_JSON);

            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(0);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetMutlipleComments_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, COMMENT_JSON);

            Func<Task<IEnumerable<TraktResponse<ITraktComment>>>> act = () => client.Comments.GetMutlipleCommentsAsync(new uint[] { 0 });
            act.Should().Throw<ArgumentException>();

            act = () => client.Comments.GetMutlipleCommentsAsync(new uint[] { });
            act.Should().NotThrow();

            act = () => client.Comments.GetMutlipleCommentsAsync(null);
            act.Should().NotThrow();
        }
    }
}
