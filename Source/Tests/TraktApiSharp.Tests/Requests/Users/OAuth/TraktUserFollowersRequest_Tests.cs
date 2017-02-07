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
    public class TraktUserFollowersRequest_Tests
    {
        [Fact]
        public void Test_TraktUserFollowersRequest_Is_Not_Abstract()
        {
            typeof(TraktUserFollowersRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserFollowersRequest_Is_Sealed()
        {
            typeof(TraktUserFollowersRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserFollowersRequest_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(TraktUserFollowersRequest).IsSubclassOf(typeof(ATraktUsersGetRequest<TraktUserFollower>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserFollowersRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserFollowersRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserFollowersRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserFollowersRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserFollowersRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserFollowersRequest();
            request.UriTemplate.Should().Be("users/{username}/followers{?extended}");
        }

        [Fact]
        public void Test_TraktUserFollowersRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktUserFollowersRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktUserFollowersRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktUserFollowersRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserFollowersRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserFollowersRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserFollowersRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
