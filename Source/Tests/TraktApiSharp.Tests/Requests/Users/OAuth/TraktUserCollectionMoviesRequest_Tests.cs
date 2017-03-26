namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections.Implementations;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserCollectionMoviesRequest_Tests
    {
        [Fact]
        public void Test_TraktUserCollectionMoviesRequest_Is_Not_Abstract()
        {
            typeof(TraktUserCollectionMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserCollectionMoviesRequest_Is_Sealed()
        {
            typeof(TraktUserCollectionMoviesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCollectionMoviesRequest_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(TraktUserCollectionMoviesRequest).IsSubclassOf(typeof(ATraktUsersGetRequest<TraktCollectionMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCollectionMoviesRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserCollectionMoviesRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserCollectionMoviesRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserCollectionMoviesRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserCollectionMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserCollectionMoviesRequest();
            request.UriTemplate.Should().Be("users/{username}/collection/movies{?extended}");
        }

        [Fact]
        public void Test_TraktUserCollectionMoviesRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktUserCollectionMoviesRequest { Username = "username" };
            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktUserCollectionMoviesRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktUserCollectionMoviesRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var requestMock = new TraktUserCollectionMoviesRequest();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            requestMock = new TraktUserCollectionMoviesRequest { Username = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            requestMock = new TraktUserCollectionMoviesRequest { Username = "invalid username" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
