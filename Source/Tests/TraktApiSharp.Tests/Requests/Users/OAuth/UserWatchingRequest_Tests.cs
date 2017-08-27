namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserWatchingRequest_Tests
    {
        [Fact]
        public void Test_UserWatchingRequest_Is_Not_Abstract()
        {
            typeof(UserWatchingRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserWatchingRequest_Is_Sealed()
        {
            typeof(UserWatchingRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserWatchingRequest_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(UserWatchingRequest).IsSubclassOf(typeof(AUsersGetRequest<ITraktUserWatchingItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserWatchingRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserWatchingRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserWatchingRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserWatchingRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserWatchingRequest_Has_Valid_UriTemplate()
        {
            var request = new UserWatchingRequest();
            request.UriTemplate.Should().Be("users/{username}/watching{?extended}");
        }

        [Fact]
        public void Test_UserWatchingRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserWatchingRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserWatchingRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_UserWatchingRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserWatchingRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserWatchingRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserWatchingRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
