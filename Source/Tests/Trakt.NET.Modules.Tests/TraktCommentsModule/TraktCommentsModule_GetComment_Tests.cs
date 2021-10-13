namespace TraktNet.Modules.Tests.TraktCommentsModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Responses;
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
        public async Task Test_TraktCommentsModule_GetComment_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, statusCode);

            try
            {
                await client.Comments.GetCommentAsync(GET_COMMENT_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetComment_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, COMMENT_JSON);

            Func<Task<TraktResponse<ITraktComment>>> act = () => client.Comments.GetCommentAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetMutlipleComments_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_URI, COMMENT_JSON);

            Func<Task<IEnumerable<TraktResponse<ITraktComment>>>> act = () => client.Comments.GetMutlipleCommentsAsync(new uint[] { 0 });
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Comments.GetMutlipleCommentsAsync(new uint[] { });
            await act.Should().NotThrowAsync();

            act = () => client.Comments.GetMutlipleCommentsAsync(null);
            await act.Should().NotThrowAsync();
        }
    }
}
