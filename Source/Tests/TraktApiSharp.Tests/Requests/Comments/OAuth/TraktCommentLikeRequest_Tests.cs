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
    public class TraktCommentLikeRequest_Tests
    {
        [Fact]
        public void Test_TraktCommentLikeRequest_IsNotAbstract()
        {
            typeof(TraktCommentLikeRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktCommentLikeRequest_IsSealed()
        {
            typeof(TraktCommentLikeRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentLikeRequest_Inherits_ATraktBodylessPostRequest()
        {
            typeof(TraktCommentLikeRequest).IsSubclassOf(typeof(ABodylessPostRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentLikeRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktCommentLikeRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktCommentLikeRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktCommentLikeRequest();
            request.UriTemplate.Should().Be("comments/{id}/like");
        }

        [Fact]
        public void Test_TraktCommentLikeRequest_Has_AuthorizationRequirement_Required()
        {
            var requestMock = new TraktCommentLikeRequest();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktCommentLikeRequest_Returns_Valid_RequestObjectType()
        {
            var request = new TraktCommentLikeRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Comments);
        }

        [Fact]
        public void Test_TraktCommentLikeRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new TraktCommentLikeRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktCommentLikeRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktCommentLikeRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktCommentLikeRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktCommentLikeRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
