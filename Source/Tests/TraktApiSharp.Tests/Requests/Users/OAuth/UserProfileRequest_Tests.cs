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
    public class UserProfileRequest_Tests
    {
        [Fact]
        public void Test_UserProfileRequest_Is_Not_Abstract()
        {
            typeof(UserProfileRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserProfileRequest_Is_Sealed()
        {
            typeof(UserProfileRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserProfileRequest_Inherits_AUsersGetRequest_1()
        {
            typeof(UserProfileRequest).IsSubclassOf(typeof(AUsersGetRequest<ITraktUser>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserProfileRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserProfileRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserProfileRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserProfileRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserProfileRequest_Has_Valid_UriTemplate()
        {
            var request = new UserProfileRequest();
            request.UriTemplate.Should().Be("users/{username}{?extended}");
        }

        [Fact]
        public void Test_UserProfileRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserProfileRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserProfileRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_UserProfileRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserProfileRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserProfileRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserProfileRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
