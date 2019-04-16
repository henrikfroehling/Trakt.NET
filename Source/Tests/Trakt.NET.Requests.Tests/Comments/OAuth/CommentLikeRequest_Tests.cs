namespace TraktNet.Requests.Tests.Comments.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Comments.OAuth;
    using Xunit;

    [Category("Requests.Comments.OAuth")]
    public class CommentLikeRequest_Tests
    {
        [Fact]
        public void Test_CommentLikeRequest_Has_Valid_UriTemplate()
        {
            var request = new CommentLikeRequest();
            request.UriTemplate.Should().Be("comments/{id}/like");
        }

        [Fact]
        public void Test_CommentLikeRequest_Has_AuthorizationRequirement_Required()
        {
            var requestMock = new CommentLikeRequest();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_CommentLikeRequest_Returns_Valid_RequestObjectType()
        {
            var request = new CommentLikeRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Comments);
        }

        [Fact]
        public void Test_CommentLikeRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new CommentLikeRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_CommentLikeRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new CommentLikeRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new CommentLikeRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new CommentLikeRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
