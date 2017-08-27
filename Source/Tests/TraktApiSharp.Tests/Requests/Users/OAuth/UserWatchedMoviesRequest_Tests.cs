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
    public class UserWatchedMoviesRequest_Tests
    {
        [Fact]
        public void Test_UserWatchedMoviesRequest_Is_Not_Abstract()
        {
            typeof(UserWatchedMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserWatchedMoviesRequest_Is_Sealed()
        {
            typeof(UserWatchedMoviesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserWatchedMoviesRequest_Inherits_AUsersGetRequest_1()
        {
            typeof(UserWatchedMoviesRequest).IsSubclassOf(typeof(AUsersGetRequest<ITraktWatchedMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserWatchedMoviesRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserWatchedMoviesRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserWatchedMoviesRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserWatchedMoviesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserWatchedMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new UserWatchedMoviesRequest();
            request.UriTemplate.Should().Be("users/{username}/watched/movies{?extended}");
        }

        [Fact]
        public void Test_UserWatchedMoviesRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserWatchedMoviesRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserWatchedMoviesRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_UserWatchedMoviesRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserWatchedMoviesRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserWatchedMoviesRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserWatchedMoviesRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
