namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserFollowingRequest_Tests
    {
        [Fact]
        public void Test_TraktUserFollowingRequest_Is_Not_Abstract()
        {
            typeof(TraktUserFollowingRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserFollowingRequest_Is_Sealed()
        {
            typeof(TraktUserFollowingRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserFollowingRequest_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(TraktUserFollowingRequest).IsSubclassOf(typeof(ATraktUsersGetRequest<TraktUserFollower>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserFollowingRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserFollowingRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserFollowingRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserFollowingRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserFollowingRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserFollowingRequest();
            request.UriTemplate.Should().Be("users/{username}/following{?extended}");
        }

        [Fact]
        public void Test_TraktUserFollowingRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktUserFollowingRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktUserFollowingRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktUserFollowingRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserFollowingRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserFollowingRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserFollowingRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
