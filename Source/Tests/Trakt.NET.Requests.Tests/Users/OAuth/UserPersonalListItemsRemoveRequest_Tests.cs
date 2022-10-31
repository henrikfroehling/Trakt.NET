namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserPersonalListItemsRemoveRequest_Tests
    {
        [Fact]
        public void Test_UserPersonalListItemsRemoveRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserPersonalListItemsRemoveRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserPersonalListItemsRemoveRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserPersonalListItemsRemoveRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_UserPersonalListItemsRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new UserPersonalListItemsRemoveRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/items/remove");
        }

        [Fact]
        public void Test_UserPersonalListItemsRemoveRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserPersonalListItemsRemoveRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_UserPersonalListItemsRemoveRequest_Validate_Throws_Exceptions()
        {
            var listItemsPost = new TraktUserPersonalListItemsPost
            {
                Movies = new List<ITraktUserPersonalListItemsPostMovie> { new TraktUserPersonalListItemsPostMovie() }
            };

            // username is null
            var request = new UserPersonalListItemsRemoveRequest { Id = "123", RequestBody = listItemsPost };

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserPersonalListItemsRemoveRequest { Username = string.Empty, Id = "123", RequestBody = listItemsPost };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserPersonalListItemsRemoveRequest { Username = "invalid username", Id = "123", RequestBody = listItemsPost };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id is null
            request = new UserPersonalListItemsRemoveRequest { Username = "username", RequestBody = listItemsPost };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new UserPersonalListItemsRemoveRequest { Username = "username", Id = string.Empty, RequestBody = listItemsPost };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new UserPersonalListItemsRemoveRequest { Username = "username", Id = "invalid id", RequestBody = listItemsPost };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
