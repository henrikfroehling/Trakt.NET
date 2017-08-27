namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Post.Users;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserCustomListUpdateRequest_Tests
    {
        [Fact]
        public void Test_UserCustomListUpdateRequest_Is_Not_Abstract()
        {
            typeof(UserCustomListUpdateRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserCustomListUpdateRequest_Is_Sealed()
        {
            typeof(UserCustomListUpdateRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserCustomListUpdateRequest_Inherits_APutRequest_2()
        {
            typeof(UserCustomListUpdateRequest).IsSubclassOf(typeof(APutRequest<ITraktList, TraktUserCustomListPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserCustomListUpdateRequest_Implements_IHasId_Interface()
        {
            typeof(UserCustomListUpdateRequest).GetInterfaces().Should().Contain(typeof(IHasId));
        }

        [Fact]
        public void Test_UserCustomListUpdateRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserCustomListUpdateRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserCustomListUpdateRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserCustomListUpdateRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserCustomListUpdateRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserCustomListUpdateRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_UserCustomListUpdateRequest_Has_Valid_UriTemplate()
        {
            var request = new UserCustomListUpdateRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}");
        }

        [Fact]
        public void Test_UserCustomListUpdateRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserCustomListUpdateRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_UserCustomListUpdateRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserCustomListUpdateRequest { Id = "123" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserCustomListUpdateRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserCustomListUpdateRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id is null
            request = new UserCustomListUpdateRequest { Username = "username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new UserCustomListUpdateRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new UserCustomListUpdateRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
