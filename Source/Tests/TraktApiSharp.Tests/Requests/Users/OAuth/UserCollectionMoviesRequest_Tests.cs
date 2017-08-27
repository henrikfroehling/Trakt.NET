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
    public class UserCollectionMoviesRequest_Tests
    {
        [Fact]
        public void Test_UserCollectionMoviesRequest_Is_Not_Abstract()
        {
            typeof(UserCollectionMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserCollectionMoviesRequest_Is_Sealed()
        {
            typeof(UserCollectionMoviesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserCollectionMoviesRequest_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(UserCollectionMoviesRequest).IsSubclassOf(typeof(AUsersGetRequest<ITraktCollectionMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserCollectionMoviesRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserCollectionMoviesRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserCollectionMoviesRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserCollectionMoviesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserCollectionMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new UserCollectionMoviesRequest();
            request.UriTemplate.Should().Be("users/{username}/collection/movies{?extended}");
        }

        [Fact]
        public void Test_UserCollectionMoviesRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserCollectionMoviesRequest { Username = "username" };
            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserCollectionMoviesRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_UserCollectionMoviesRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var requestMock = new UserCollectionMoviesRequest();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            requestMock = new UserCollectionMoviesRequest { Username = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            requestMock = new UserCollectionMoviesRequest { Username = "invalid username" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
