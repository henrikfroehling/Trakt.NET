namespace TraktNet.Requests.Tests.Comments.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Comments.OAuth;
    using Xunit;

    [Category("Requests.Comments.OAuth")]
    public class CommentDeleteRequest_Tests
    {
        [Fact]
        public void Test_CommentDeleteRequest_Has_Valid_UriTemplate()
        {
            var request = new CommentDeleteRequest();
            request.UriTemplate.Should().Be("comments/{id}");
        }

        [Fact]
        public void Test_CommentDeleteRequest_Has_AuthorizationRequirement_Required()
        {
            var requestMock = new CommentDeleteRequest();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_CommentDeleteRequest_Returns_Valid_RequestObjectType()
        {
            var request = new CommentDeleteRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Comments);
        }

        [Fact]
        public void Test_CommentDeleteRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new CommentDeleteRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_CommentDeleteRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new CommentDeleteRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new CommentDeleteRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new CommentDeleteRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
