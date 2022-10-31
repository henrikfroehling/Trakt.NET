namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [TestCategory("Requests.Users.OAuth")]
    public class UserFollowersRequest_Tests
    {
        [Fact]
        public void Test_UserFollowersRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserFollowersRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserFollowersRequest_Has_Valid_UriTemplate()
        {
            var request = new UserFollowersRequest();
            request.UriTemplate.Should().Be("users/{username}/followers{?extended}");
        }

        [Fact]
        public void Test_UserFollowersRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserFollowersRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserFollowersRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_UserFollowersRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserFollowersRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty username
            request = new UserFollowersRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // username with spaces
            request = new UserFollowersRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
