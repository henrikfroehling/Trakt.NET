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
    public class CommentSummaryRequest_Tests
    {
        [Fact]
        public void Test_CommentSummaryRequest_IsNotAbstract()
        {
            typeof(CommentSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_CommentSummaryRequest_IsSealed()
        {
            typeof(CommentSummaryRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_CommentSummaryRequest_Inherits_AGetRequest_1()
        {
            typeof(CommentSummaryRequest).IsSubclassOf(typeof(AGetRequest<ITraktComment>)).Should().BeTrue();
        }

        [Fact]
        public void Test_CommentSummaryRequest_Implements_IHasId_Interface()
        {
            typeof(CommentSummaryRequest).GetInterfaces().Should().Contain(typeof(IHasId));
        }

        [Fact]
        public void Test_CommentSummaryRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new CommentSummaryRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_CommentSummaryRequest_Returns_Valid_RequestObjectType()
        {
            var request = new CommentSummaryRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Comments);
        }

        [Fact]
        public void Test_CommentSummaryRequest_Has_Valid_UriTemplate()
        {
            var request = new CommentSummaryRequest();
            request.UriTemplate.Should().Be("comments/{id}");
        }

        [Fact]
        public void Test_CommentSummaryRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var requestMock = new CommentSummaryRequest { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });
        }

        [Fact]
        public void Test_CommentSummaryRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new CommentSummaryRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new CommentSummaryRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new CommentSummaryRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
