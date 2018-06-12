namespace TraktApiSharp.Tests.Requests.Comments
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Comments;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Comments")]
    public class CommentItemRequest_Tests
    {
        [Fact]
        public void Test_CommentItemRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new CommentItemRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_CommentItemRequest_Returns_Valid_RequestObjectType()
        {
            var request = new CommentItemRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Comments);
        }

        [Fact]
        public void Test_CommentItemRequest_Has_Valid_UriTemplate()
        {
            var request = new CommentItemRequest();
            request.UriTemplate.Should().Be("comments/{id}/item{?extended}");
        }

        [Fact]
        public void Test_CommentItemRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new CommentItemRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };

            request = new CommentItemRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
            };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_CommentItemRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new CommentItemRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new CommentItemRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new CommentItemRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
