namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Parameters;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [TestCategory("Requests.Users.OAuth")]
    public class UserCollectionShowsRequest_Tests
    {
        [Fact]
        public void Test_UserCollectionShowsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserCollectionShowsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserCollectionShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserCollectionShowsRequest();
            request.UriTemplate.Should().Be("users/{username}/collection/shows{?extended}");
        }

        [Fact]
        public void Test_UserCollectionShowsRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserCollectionShowsRequest { Username = "username" };
            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserCollectionShowsRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_UserCollectionShowsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var requestMock = new UserCollectionShowsRequest();

            Action act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            requestMock = new UserCollectionShowsRequest { Username = string.Empty };

            act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            requestMock = new UserCollectionShowsRequest { Username = "invalid username" };

            act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
