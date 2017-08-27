namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserCollectionShowsRequest_Tests
    {
        [Fact]
        public void Test_UserCollectionShowsRequest_Is_Not_Abstract()
        {
            typeof(UserCollectionShowsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserCollectionShowsRequest_Is_Sealed()
        {
            typeof(UserCollectionShowsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserCollectionShowsRequest_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(UserCollectionShowsRequest).IsSubclassOf(typeof(AUsersGetRequest<ITraktCollectionShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserCollectionShowsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserCollectionShowsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserCollectionShowsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserCollectionShowsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserCollectionShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserCollectionShowsRequest();
            request.UriTemplate.Should().Be("users/{username}/collection/shows{?extended}");
        }

        [Fact]
        public void Test_UserCollectionShowsRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserCollectionShowsRequest { Username = "username" };
            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserCollectionShowsRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_UserCollectionShowsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var requestMock = new UserCollectionShowsRequest();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            requestMock = new UserCollectionShowsRequest { Username = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            requestMock = new UserCollectionShowsRequest { Username = "invalid username" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
