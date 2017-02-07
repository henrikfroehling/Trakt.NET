namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserWatchingRequest_Tests
    {
        [Fact]
        public void Test_TraktUserWatchingRequest_Is_Not_Abstract()
        {
            typeof(TraktUserWatchingRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserWatchingRequest_Is_Sealed()
        {
            typeof(TraktUserWatchingRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserWatchingRequest_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(TraktUserWatchingRequest).IsSubclassOf(typeof(ATraktUsersGetRequest<TraktUserWatchingItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserWatchingRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserWatchingRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserWatchingRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserWatchingRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserWatchingRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserWatchingRequest();
            request.UriTemplate.Should().Be("users/{username}/watching{?extended}");
        }

        [Fact]
        public void Test_TraktUserWatchingRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktUserWatchingRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktUserWatchingRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktUserWatchingRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserWatchingRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserWatchingRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserWatchingRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
