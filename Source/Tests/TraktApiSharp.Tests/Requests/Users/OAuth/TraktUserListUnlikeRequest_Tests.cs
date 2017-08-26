namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserListUnlikeRequest_Tests
    {
        [Fact]
        public void Test_TraktUserListUnlikeRequest_Is_Not_Abstract()
        {
            typeof(TraktUserListUnlikeRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserListUnlikeRequest_Is_Sealed()
        {
            typeof(TraktUserListUnlikeRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserListUnlikeRequest_Inherits_ATraktUsersDeleteByIdRequest()
        {
            typeof(TraktUserListUnlikeRequest).IsSubclassOf(typeof(ATraktUsersDeleteByIdRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserListUnlikeRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserListUnlikeRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserListUnlikeRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserListUnlikeRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserListUnlikeRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktUserListUnlikeRequest();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }

        [Fact]
        public void Test_TraktUserListUnlikeRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserListUnlikeRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/like");
        }

        [Fact]
        public void Test_TraktUserListUnlikeRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktUserListUnlikeRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktUserListUnlikeRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserListUnlikeRequest { Id = "123" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserListUnlikeRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserListUnlikeRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id is null
            request = new TraktUserListUnlikeRequest { Username = "username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktUserListUnlikeRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktUserListUnlikeRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
