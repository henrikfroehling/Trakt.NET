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
    public class TraktCommentReplyRequest_Tests
    {
        [Fact]
        public void Test_TraktCommentReplyRequest_IsNotAbstract()
        {
            typeof(TraktCommentReplyRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktCommentReplyRequest_IsSealed()
        {
            typeof(TraktCommentReplyRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentReplyRequest_Inherits_ATraktPostRequest_2()
        {
            typeof(TraktCommentReplyRequest).IsSubclassOf(typeof(ATraktPostRequest<TraktCommentPostResponse, TraktCommentReplyPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentReplyRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktCommentReplyRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktCommentReplyRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktCommentReplyRequest();
            request.UriTemplate.Should().Be("comments/{id}/replies");
        }

        [Fact]
        public void Test_TraktCommentReplyRequest_Has_AuthorizationRequirement_Required()
        {
            var requestMock = new TraktCommentReplyRequest();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktCommentReplyRequest_Returns_Valid_RequestObjectType()
        {
            var request = new TraktCommentReplyRequest();
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Comments);
        }

        [Fact]
        public void Test_TraktCommentReplyRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new TraktCommentReplyRequest { Id = "123", RequestBody = new TraktCommentReplyPost() };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktCommentReplyRequest_Validate_Throws_Exceptions()
        {
            // request body is null
            var request = new TraktCommentReplyRequest { Id = "123" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // id is null
            request = new TraktCommentReplyRequest { RequestBody = null };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktCommentReplyRequest { Id = string.Empty, RequestBody = new TraktCommentReplyPost() };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktCommentReplyRequest { Id = "invalid id", RequestBody = new TraktCommentReplyPost() };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
