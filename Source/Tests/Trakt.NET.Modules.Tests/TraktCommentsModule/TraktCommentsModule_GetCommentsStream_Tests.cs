﻿namespace TraktNet.Modules.Tests.TraktCommentsModule
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
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Comments")]
    public partial class TraktCommentsModule_Tests
    {
        private readonly string GET_COMMENTS_STREAM_URI = $"comments/{GET_COMMENT_ID}";

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentStream()
        {
            var parameters = new TraktMultipleCommentsQueryParams
            {
                { GET_COMMENT_ID },
                { GET_COMMENT_ID }
            };

            int totalComments = parameters.Count;
            TraktClient client = TestUtility.GetMockClientForMultipleCalls(GET_COMMENTS_STREAM_URI, COMMENT_JSON, totalComments);
            IAsyncEnumerable<TraktResponse<ITraktComment>> responses = client.Comments.GetCommentsStreamAsync(parameters);


            int commentsReturned = 0;

            await foreach(TraktResponse<ITraktComment> response in responses)
            {
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
                responseValue.UserStats.Should().NotBeNull();
                responseValue.UserStats.Rating.Should().Be(8);
                responseValue.UserStats.PlayCount.Should().Be(1);
                responseValue.UserStats.CompletedCount.Should().Be(1);
                responseValue.User.Should().NotBeNull();

                commentsReturned++;
            }

            commentsReturned.Should().Be(totalComments);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentStream_With_Null_Parameters()
        {
            TraktMultipleCommentsQueryParams parameters = null;

            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_STREAM_URI, COMMENT_JSON);
            IAsyncEnumerable<TraktResponse<ITraktComment>> responses = client.Comments.GetCommentsStreamAsync(parameters);

            (await responses.ToListAsync()).Any().Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentStream_With_Empty_Parameters()
        {
            var parameters = new TraktMultipleCommentsQueryParams();

            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_STREAM_URI, COMMENT_JSON);
            IAsyncEnumerable<TraktResponse<ITraktComment>> responses = client.Comments.GetCommentsStreamAsync(parameters);

            (await responses.ToListAsync()).Any().Should().BeFalse();
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
        public async Task Test_TraktCommentsModule_GetCommentStream_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            var parameters = new TraktMultipleCommentsQueryParams
            {
                { GET_COMMENT_ID },
                { GET_COMMENT_ID }
            };

            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_STREAM_URI, statusCode);

            try
            {
                IAsyncEnumerable<TraktResponse<ITraktComment>> responses = client.Comments.GetCommentsStreamAsync(parameters);
                await foreach(TraktResponse<ITraktComment> response in responses) {

                }
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
