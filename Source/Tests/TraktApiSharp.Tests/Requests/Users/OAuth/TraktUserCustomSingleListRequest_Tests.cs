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
    public class TraktUserCustomSingleListRequest_Tests
    {
        [Fact]
        public void Test_TraktUserCustomSingleListRequest_Is_Not_Abstract()
        {
            typeof(TraktUserCustomSingleListRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserCustomSingleListRequest_Is_Sealed()
        {
            typeof(TraktUserCustomSingleListRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomSingleListRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktUserCustomSingleListRequest).IsSubclassOf(typeof(ATraktGetRequest<ITraktList>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomSingleListRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktUserCustomSingleListRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktUserCustomSingleListRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserCustomSingleListRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserCustomSingleListRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserCustomSingleListRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserCustomSingleListRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktUserCustomSingleListRequest();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }

        [Fact]
        public void Test_TraktUserCustomSingleListRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserCustomSingleListRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}");
        }

        [Fact]
        public void Test_TraktUserCustomSingleListRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktUserCustomSingleListRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktUserCustomSingleListRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserCustomSingleListRequest { Id = "123" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserCustomSingleListRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserCustomSingleListRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id is null
            request = new TraktUserCustomSingleListRequest { Username = "username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktUserCustomSingleListRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktUserCustomSingleListRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
