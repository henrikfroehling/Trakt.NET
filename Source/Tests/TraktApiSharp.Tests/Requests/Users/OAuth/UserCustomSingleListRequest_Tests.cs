namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserCustomSingleListRequest_Tests
    {
        [Fact]
        public void Test_UserCustomSingleListRequest_Is_Not_Abstract()
        {
            typeof(UserCustomSingleListRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserCustomSingleListRequest_Is_Sealed()
        {
            typeof(UserCustomSingleListRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserCustomSingleListRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(UserCustomSingleListRequest).IsSubclassOf(typeof(AGetRequest<ITraktList>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserCustomSingleListRequest_Implements_ITraktHasId_Interface()
        {
            typeof(UserCustomSingleListRequest).GetInterfaces().Should().Contain(typeof(IHasId));
        }

        [Fact]
        public void Test_UserCustomSingleListRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserCustomSingleListRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserCustomSingleListRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserCustomSingleListRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserCustomSingleListRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserCustomSingleListRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_UserCustomSingleListRequest_Has_Valid_UriTemplate()
        {
            var request = new UserCustomSingleListRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}");
        }

        [Fact]
        public void Test_UserCustomSingleListRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserCustomSingleListRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_UserCustomSingleListRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserCustomSingleListRequest { Id = "123" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserCustomSingleListRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserCustomSingleListRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id is null
            request = new UserCustomSingleListRequest { Username = "username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new UserCustomSingleListRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new UserCustomSingleListRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
