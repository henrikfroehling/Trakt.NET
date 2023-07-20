namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Basic;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [TestCategory("Requests.Users.OAuth")]
    public class UserPersonalListItemUpdateRequest_Tests
    {
        [Fact]
        public void Test_UserListItemUpdateRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserPersonalListItemUpdateRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserListItemUpdateRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserPersonalListItemUpdateRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_UserListItemUpdateRequest_Has_Valid_UriTemplate()
        {
            var request = new UserPersonalListItemUpdateRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{list_id}/items/{list_item_id}");
        }

        [Fact]
        public void Test_UserListItemUpdateRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserPersonalListItemUpdateRequest { Username = "username", Id = "star-wars-in-machete-order", ListItemId = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["list_id"] = "star-wars-in-machete-order",
                                                       ["list_item_id"] = "1"
                                                   });
        }

        [Fact]
        public void Test_UserListItemUpdateRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserPersonalListItemUpdateRequest
            {
                Id = "star-wars-in-machete-order",
                ListItemId = 1,
                RequestBody = new TraktListItemUpdatePost { Notes = string.Empty }
            };

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserPersonalListItemUpdateRequest
            {
                Username = string.Empty,
                Id = "star-wars-in-machete-order",
                ListItemId = 1,
                RequestBody = new TraktListItemUpdatePost { Notes = string.Empty }
            };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserPersonalListItemUpdateRequest
            {
                Username = "invalid username",
                Id = "star-wars-in-machete-order",
                ListItemId = 1,
                RequestBody = new TraktListItemUpdatePost { Notes = string.Empty }
            };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // list id is null
            request = new UserPersonalListItemUpdateRequest
            {
                Username = "username",
                ListItemId = 1,
                RequestBody = new TraktListItemUpdatePost { Notes = string.Empty }
            };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty list id
            request = new UserPersonalListItemUpdateRequest
            {
                Username = "username",
                Id = string.Empty,
                ListItemId = 1,
                RequestBody = new TraktListItemUpdatePost { Notes = string.Empty }
            };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // list id with spaces
            request = new UserPersonalListItemUpdateRequest
            {
                Username = "username",
                Id = "invalid id",
                ListItemId = 1,
                RequestBody = new TraktListItemUpdatePost { Notes = string.Empty }
            };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // invalid list item id
            request = new UserPersonalListItemUpdateRequest
            {
                Username = "username",
                Id = "star-wars-in-machete-order",
                ListItemId = 0,
                RequestBody = new TraktListItemUpdatePost { Notes = string.Empty }
            };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // request body is null
            request = new UserPersonalListItemUpdateRequest
            {
                Username = "username",
                Id = "star-wars-in-machete-order",
                ListItemId = 1
            };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
