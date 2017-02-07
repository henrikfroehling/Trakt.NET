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
    public class TraktCommentDeleteRequest_Tests
    {
        [Fact]
        public void Test_TraktCommentDeleteRequest_IsNotAbstract()
        {
            typeof(TraktCommentDeleteRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktCommentDeleteRequest_IsSealed()
        {
            typeof(TraktCommentDeleteRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentDeleteRequest_Inherits_ATraktDeleteRequest()
        {
            typeof(TraktCommentDeleteRequest).IsSubclassOf(typeof(ATraktDeleteRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentDeleteRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktCommentDeleteRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktCommentDeleteRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktCommentDeleteRequest();
            request.UriTemplate.Should().Be("comments/{id}");
        }

        [Fact]
        public void Test_TraktCommentDeleteRequest_Has_AuthorizationRequirement_Required()
        {
            var requestMock = new TraktCommentDeleteRequest();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktCommentDeleteRequest_Returns_Valid_RequestObjectType()
        {
            var request = new TraktCommentDeleteRequest();
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Comments);
        }

        [Fact]
        public void Test_TraktCommentDeleteRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new TraktCommentDeleteRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktCommentDeleteRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktCommentDeleteRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktCommentDeleteRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktCommentDeleteRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
