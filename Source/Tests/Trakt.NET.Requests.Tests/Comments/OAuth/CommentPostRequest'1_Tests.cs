namespace TraktNet.Requests.Tests.Comments.OAuth
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Comments;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Comments.OAuth;
    using Xunit;

    [TestCategory("Requests.Comments.OAuth")]
    public class CommentPostRequest_1_Tests
    {
        [Fact]
        public void Test_CommentPostRequest_1_Has_AuthorizationRequirement_Required()
        {
            var request = new CommentPostRequest<TraktCommentPost>();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_CommentPostRequest_1_Has_Valid_UriTemplate()
        {
            var request = new CommentPostRequest<TraktCommentPost>();
            request.UriTemplate.Should().Be("comments");
        }

        [Fact]
        public void Test_CommentPostRequest_1_Validate_Throws_TraktRequestValidationException()
        {
            var request = new CommentPostRequest<TraktCommentPost>();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Fact]
        public void Test_CommentPostRequest_1_Returns_Valid_UriPathParameters()
        {
            var request = new CommentPostRequest<TraktCommentPost>();
            var uriParams = request.GetUriPathParameters();
            uriParams.Should().NotBeNull().And.BeEmpty().And.HaveCount(0);
        }
    }
}
