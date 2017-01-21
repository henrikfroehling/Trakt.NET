namespace TraktApiSharp.Tests.Requests.Comments.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Comments.OAuth;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Objects.Post.Comments;
    using TraktApiSharp.Objects.Post.Comments.Responses;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Comments.OAuth")]
    public class TraktCommentUpdateRequest_Tests
    {
        [Fact]
        public void Test_TraktCommentUpdateRequest_IsNotAbstract()
        {
            typeof(TraktCommentUpdateRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktCommentUpdateRequest_IsSealed()
        {
            typeof(TraktCommentUpdateRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentUpdateRequest_Inherits_ATraktPutRequest_2()
        {
            typeof(TraktCommentUpdateRequest).IsSubclassOf(typeof(ATraktPutRequest<TraktCommentPostResponse, TraktCommentUpdatePost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentUpdateRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktCommentUpdateRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktCommentUpdateRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktCommentUpdateRequest();
            request.UriTemplate.Should().Be("comments/{id}");
        }

        [Fact]
        public void Test_TraktCommentUpdateRequest_Has_AuthorizationRequirement_Required()
        {
            var requestMock = new TraktCommentUpdateRequest();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktCommentUpdateRequest_Returns_Valid_RequestObjectType()
        {
            var request = new TraktCommentUpdateRequest();
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Comments);
        }

        [Fact]
        public void Test_TraktCommentUpdateRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new TraktCommentUpdateRequest { Id = "123", RequestBody = new TraktCommentUpdatePost() };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktCommentUpdateRequest_Validate_Throws_Exceptions()
        {
            // request body is null
            var request = new TraktCommentUpdateRequest { Id = "123" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // id is null
            request = new TraktCommentUpdateRequest { RequestBody = null };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktCommentUpdateRequest { Id = string.Empty, RequestBody = new TraktCommentUpdatePost() };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktCommentUpdateRequest { Id = "invalid id", RequestBody = new TraktCommentUpdatePost() };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
