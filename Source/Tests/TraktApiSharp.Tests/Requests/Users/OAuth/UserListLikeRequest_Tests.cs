namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserListLikeRequest_Tests
    {
        [Fact]
        public void Test_UserListLikeRequest_Is_Not_Abstract()
        {
            typeof(UserListLikeRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserListLikeRequest_Is_Sealed()
        {
            typeof(UserListLikeRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserListLikeRequest_Inherits_ABodylessPostRequest()
        {
            typeof(UserListLikeRequest).IsSubclassOf(typeof(ABodylessPostRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserListLikeRequest_Implements_IHasId_Interface()
        {
            typeof(UserListLikeRequest).GetInterfaces().Should().Contain(typeof(IHasId));
        }

        [Fact]
        public void Test_UserListLikeRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserListLikeRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserListLikeRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserListLikeRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserListLikeRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserListLikeRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_UserListLikeRequest_Has_Valid_UriTemplate()
        {
            var request = new UserListLikeRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/like");
        }

        [Fact]
        public void Test_UserListLikeRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserListLikeRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_UserListLikeRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserListLikeRequest { Id = "123" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserListLikeRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserListLikeRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id is null
            request = new UserListLikeRequest { Username = "username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new UserListLikeRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new UserListLikeRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
