namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Post.Users.CustomListItems;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserCustomListItemsRemoveRequest_Tests
    {
        [Fact]
        public void Test_TraktUserCustomListItemsRemoveRequest_Is_Not_Abstract()
        {
            typeof(TraktUserCustomListItemsRemoveRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRemoveRequest_Is_Sealed()
        {
            typeof(TraktUserCustomListItemsRemoveRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRemoveRequest_Inherits_ATraktUsersPostByIdRequest_2()
        {
            typeof(TraktUserCustomListItemsRemoveRequest).IsSubclassOf(typeof(ATraktUsersPostByIdRequest<ITraktUserCustomListItemsRemovePostResponse, TraktUserCustomListItemsPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRemoveRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserCustomListItemsRemoveRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRemoveRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserCustomListItemsRemoveRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRemoveRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktUserCustomListItemsRemoveRequest();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserCustomListItemsRemoveRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/items/remove");
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRemoveRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktUserCustomListItemsRemoveRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRemoveRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserCustomListItemsRemoveRequest { Id = "123" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserCustomListItemsRemoveRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserCustomListItemsRemoveRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id is null
            request = new TraktUserCustomListItemsRemoveRequest { Username = "username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktUserCustomListItemsRemoveRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktUserCustomListItemsRemoveRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
