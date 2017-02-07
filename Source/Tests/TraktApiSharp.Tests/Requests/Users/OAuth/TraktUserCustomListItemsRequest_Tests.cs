namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserCustomListItemsRequest_Tests
    {
        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Is_Not_Abstract()
        {
            typeof(TraktUserCustomListItemsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Is_Sealed()
        {
            typeof(TraktUserCustomListItemsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(TraktUserCustomListItemsRequest).IsSubclassOf(typeof(ATraktUsersGetRequest<TraktListItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktUserCustomListItemsRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserCustomListItemsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktUserCustomListItemsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktListItemType));
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserCustomListItemsRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktUserCustomListItemsRequest();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserCustomListItemsRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/items{/type}{?extended}");
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Returns_Valid_UriPathParameters()
        {
            // without type / without extended info
            var request = new TraktUserCustomListItemsRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });

            // without type / with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktUserCustomListItemsRequest { Username = "username", Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });

            // with type / without extended info
            var type = TraktListItemType.Episode;
            request = new TraktUserCustomListItemsRequest { Username = "username", Id = "123", Type = type };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123",
                                                       ["type"] = type.UriName
                                                   });

            // with type / with extended info
            request = new TraktUserCustomListItemsRequest { Username = "username", Id = "123", Type = type, ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(4)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123",
                                                       ["type"] = type.UriName,
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktUserCustomListItemsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserCustomListItemsRequest { Id = "123" };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserCustomListItemsRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserCustomListItemsRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id is null
            request = new TraktUserCustomListItemsRequest { Username = "username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktUserCustomListItemsRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktUserCustomListItemsRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
