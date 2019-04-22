namespace TraktNet.Requests.Tests.Comments
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Comments;
    using Xunit;

    [Category("Requests.Comments")]
    public class CommentSummaryRequest_Tests
    {
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
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new CommentSummaryRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new CommentSummaryRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
