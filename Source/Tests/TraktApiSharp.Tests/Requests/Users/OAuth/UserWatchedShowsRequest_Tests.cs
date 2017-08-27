namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserWatchedShowsRequest_Tests
    {
        [Fact]
        public void Test_UserWatchedShowsRequest_Is_Not_Abstract()
        {
            typeof(UserWatchedShowsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserWatchedShowsRequest_Is_Sealed()
        {
            typeof(UserWatchedShowsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserWatchedShowsRequest_Inherits_AUsersGetRequest_1()
        {
            typeof(UserWatchedShowsRequest).IsSubclassOf(typeof(AUsersGetRequest<ITraktWatchedShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserWatchedShowsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserWatchedShowsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserWatchedShowsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserWatchedShowsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserWatchedShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserWatchedShowsRequest();
            request.UriTemplate.Should().Be("users/{username}/watched/shows{?extended}");
        }

        [Fact]
        public void Test_UserWatchedShowsRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserWatchedShowsRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserWatchedShowsRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_UserWatchedShowsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserWatchedShowsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserWatchedShowsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserWatchedShowsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
