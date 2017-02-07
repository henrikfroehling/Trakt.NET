namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Post.Users.CustomListItems;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserCustomListItemsAddRequest_Tests
    {
        [Fact]
        public void Test_TraktUserCustomListItemsAddRequest_Is_Not_Abstract()
        {
            typeof(TraktUserCustomListItemsAddRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserCustomListItemsAddRequest_Is_Sealed()
        {
            typeof(TraktUserCustomListItemsAddRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomListItemsAddRequest_Inherits_ATraktUsersPostByIdRequest_2()
        {
            typeof(TraktUserCustomListItemsAddRequest).IsSubclassOf(typeof(ATraktUsersPostByIdRequest<TraktUserCustomListItemsPostResponse, TraktUserCustomListItemsPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomListItemsAddRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserCustomListItemsAddRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserCustomListItemsAddRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktUserCustomListItemsAddRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktListItemType));
        }

        [Fact]
        public void Test_TraktUserCustomListItemsAddRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserCustomListItemsAddRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserCustomListItemsAddRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktUserCustomListItemsAddRequest();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }

        [Fact]
        public void Test_TraktUserCustomListItemsAddRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserCustomListItemsAddRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/items{/type}");
        }

        [Fact]
        public void Test_TraktUserCustomListItemsAddRequest_Returns_Valid_UriPathParameters()
        {
            // without type
            var request = new TraktUserCustomListItemsAddRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });

            // with type
            var type = TraktListItemType.Episode;
            request = new TraktUserCustomListItemsAddRequest { Username = "username", Id = "123", Type = type };

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
        public void Test_TraktUserCustomListItemsAddRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserCustomListItemsAddRequest { Id = "123" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserCustomListItemsAddRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserCustomListItemsAddRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id is null
            request = new TraktUserCustomListItemsAddRequest { Username = "username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktUserCustomListItemsAddRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktUserCustomListItemsAddRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
