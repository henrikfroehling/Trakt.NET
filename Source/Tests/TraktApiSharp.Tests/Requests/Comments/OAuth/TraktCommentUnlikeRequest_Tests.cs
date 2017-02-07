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
    public class TraktCommentUnlikeRequest_Tests
    {
        [Fact]
        public void Test_TraktCommentUnlikeRequest_IsNotAbstract()
        {
            typeof(TraktCommentUnlikeRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktCommentUnlikeRequest_IsSealed()
        {
            typeof(TraktCommentUnlikeRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentUnlikeRequest_Inherits_ATraktDeleteRequest()
        {
            typeof(TraktCommentUnlikeRequest).IsSubclassOf(typeof(ATraktDeleteRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentUnlikeRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktCommentUnlikeRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktCommentUnlikeRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktCommentUnlikeRequest();
            request.UriTemplate.Should().Be("comments/{id}/like");
        }

        [Fact]
        public void Test_TraktCommentUnlikeRequest_Has_AuthorizationRequirement_Required()
        {
            var requestMock = new TraktCommentUnlikeRequest();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktCommentUnlikeRequest_Returns_Valid_RequestObjectType()
        {
            var request = new TraktCommentUnlikeRequest();
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Comments);
        }

        [Fact]
        public void Test_TraktCommentUnlikeRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new TraktCommentUnlikeRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktCommentUnlikeRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktCommentUnlikeRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktCommentUnlikeRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktCommentUnlikeRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
