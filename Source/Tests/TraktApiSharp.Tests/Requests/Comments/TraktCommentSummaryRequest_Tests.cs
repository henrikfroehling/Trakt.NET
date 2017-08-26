namespace TraktApiSharp.Tests.Requests.Comments
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Comments;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Comments")]
    public class TraktCommentSummaryRequest_Tests
    {
        [Fact]
        public void Test_TraktCommentSummaryRequest_IsNotAbstract()
        {
            typeof(TraktCommentSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktCommentSummaryRequest_IsSealed()
        {
            typeof(TraktCommentSummaryRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentSummaryRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktCommentSummaryRequest).IsSubclassOf(typeof(AGetRequest<ITraktComment>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentSummaryRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktCommentSummaryRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktCommentSummaryRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new TraktCommentSummaryRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_TraktCommentSummaryRequest_Returns_Valid_RequestObjectType()
        {
            var request = new TraktCommentSummaryRequest();
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Comments);
        }

        [Fact]
        public void Test_TraktCommentSummaryRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktCommentSummaryRequest();
            request.UriTemplate.Should().Be("comments/{id}");
        }

        [Fact]
        public void Test_TraktCommentSummaryRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var requestMock = new TraktCommentSummaryRequest { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });
        }

        [Fact]
        public void Test_TraktCommentSummaryRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktCommentSummaryRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktCommentSummaryRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktCommentSummaryRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
