namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserCollectionMoviesRequest_Tests
    {
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
            act.Should().Throw<ArgumentNullException>();

            // empty username
            requestMock = new UserCollectionMoviesRequest { Username = string.Empty };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();

            // username with spaces
            requestMock = new UserCollectionMoviesRequest { Username = "invalid username" };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
