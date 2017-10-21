namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserCustomListItemsAddRequest_Tests
    {
        [Fact]
        public void Test_UserCustomListItemsAddRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserCustomListItemsAddRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserCustomListItemsAddRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserCustomListItemsAddRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_UserCustomListItemsAddRequest_Has_Valid_UriTemplate()
        {
            var request = new UserCustomListItemsAddRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/items{/type}");
        }

        [Fact]
        public void Test_UserCustomListItemsAddRequest_Returns_Valid_UriPathParameters()
        {
            // without type
            var request = new UserCustomListItemsAddRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });

            // with type
            var type = TraktListItemType.Episode;
            request = new UserCustomListItemsAddRequest { Username = "username", Id = "123", Type = type };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123",
                                                       ["type"] = type.UriName
                                                   });
        }

        [Fact]
        public void Test_UserCustomListItemsAddRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserCustomListItemsAddRequest { Id = "123" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserCustomListItemsAddRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserCustomListItemsAddRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id is null
            request = new UserCustomListItemsAddRequest { Username = "username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new UserCustomListItemsAddRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new UserCustomListItemsAddRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
