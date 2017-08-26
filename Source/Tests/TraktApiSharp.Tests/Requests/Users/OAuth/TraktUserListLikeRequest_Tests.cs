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
    public class TraktUserListLikeRequest_Tests
    {
        [Fact]
        public void Test_TraktUserListLikeRequest_Is_Not_Abstract()
        {
            typeof(TraktUserListLikeRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserListLikeRequest_Is_Sealed()
        {
            typeof(TraktUserListLikeRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserListLikeRequest_Inherits_ATraktBodylessPostRequest()
        {
            typeof(TraktUserListLikeRequest).IsSubclassOf(typeof(ABodylessPostRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserListLikeRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktUserListLikeRequest).GetInterfaces().Should().Contain(typeof(IHasId));
        }

        [Fact]
        public void Test_TraktUserListLikeRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserListLikeRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserListLikeRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserListLikeRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserListLikeRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktUserListLikeRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_TraktUserListLikeRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserListLikeRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/like");
        }

        [Fact]
        public void Test_TraktUserListLikeRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktUserListLikeRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktUserListLikeRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserListLikeRequest { Id = "123" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserListLikeRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserListLikeRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id is null
            request = new TraktUserListLikeRequest { Username = "username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktUserListLikeRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktUserListLikeRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
