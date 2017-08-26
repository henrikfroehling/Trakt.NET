namespace TraktApiSharp.Tests.Requests.Comments.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Comments.OAuth;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Comments.OAuth")]
    public class CommentLikeRequest_Tests
    {
        [Fact]
        public void Test_CommentLikeRequest_IsNotAbstract()
        {
            typeof(CommentLikeRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_CommentLikeRequest_IsSealed()
        {
            typeof(CommentLikeRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_CommentLikeRequest_Inherits_ATraktBodylessPostRequest()
        {
            typeof(CommentLikeRequest).IsSubclassOf(typeof(ABodylessPostRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_CommentLikeRequest_Implements_ITraktHasId_Interface()
        {
            typeof(CommentLikeRequest).GetInterfaces().Should().Contain(typeof(IHasId));
        }

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
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new CommentLikeRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new CommentLikeRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
