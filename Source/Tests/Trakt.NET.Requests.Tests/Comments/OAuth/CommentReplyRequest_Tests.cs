namespace TraktNet.Requests.Tests.Comments.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Comments;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Comments.OAuth;
    using Xunit;

    [Category("Requests.Comments.OAuth")]
    public class CommentReplyRequest_Tests
    {
        [Fact]
        public void Test_CommentReplyRequest_Has_Valid_UriTemplate()
        {
            var request = new CommentReplyRequest();
            request.UriTemplate.Should().Be("comments/{id}/replies");
        }

        [Fact]
        public void Test_CommentReplyRequest_Has_AuthorizationRequirement_Required()
        {
            var requestMock = new CommentReplyRequest();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_CommentReplyRequest_Returns_Valid_RequestObjectType()
        {
            var request = new CommentReplyRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Comments);
        }

        [Fact]
        public void Test_CommentReplyRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new CommentReplyRequest { Id = "123", RequestBody = new TraktCommentReplyPost() };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_CommentReplyRequest_Validate_Throws_Exceptions()
        {
            // request body is null
            var request = new CommentReplyRequest { Id = "123" };

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id is null
            request = new CommentReplyRequest { RequestBody = new TraktCommentReplyPost { Comment = "one two three four five" } };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new CommentReplyRequest { Id = string.Empty, RequestBody = new TraktCommentReplyPost { Comment = "one two three four five" } };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new CommentReplyRequest { Id = "invalid id", RequestBody = new TraktCommentReplyPost { Comment = "one two three four five" } };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
