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
    public class TraktUserWatchedShowsRequest_Tests
    {
        [Fact]
        public void Test_TraktUserWatchedShowsRequest_Is_Not_Abstract()
        {
            typeof(TraktUserWatchedShowsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserWatchedShowsRequest_Is_Sealed()
        {
            typeof(TraktUserWatchedShowsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserWatchedShowsRequest_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(TraktUserWatchedShowsRequest).IsSubclassOf(typeof(AUsersGetRequest<ITraktWatchedShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserWatchedShowsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserWatchedShowsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserWatchedShowsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserWatchedShowsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserWatchedShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserWatchedShowsRequest();
            request.UriTemplate.Should().Be("users/{username}/watched/shows{?extended}");
        }

        [Fact]
        public void Test_TraktUserWatchedShowsRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktUserWatchedShowsRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktUserWatchedShowsRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktUserWatchedShowsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserWatchedShowsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserWatchedShowsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserWatchedShowsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
