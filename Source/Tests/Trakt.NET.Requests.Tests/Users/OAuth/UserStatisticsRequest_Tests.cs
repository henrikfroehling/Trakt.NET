namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [TestCategory("Requests.Users.OAuth")]
    public class UserStatisticsRequest_Tests
    {
        [Fact]
        public void Test_UserStatisticsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserStatisticsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserStatisticsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserStatisticsRequest();
            request.UriTemplate.Should().Be("users/{username}/stats");
        }

        [Fact]
        public void Test_UserStatisticsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserStatisticsRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });
        }

        [Fact]
        public void Test_UserStatisticsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserStatisticsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserStatisticsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserStatisticsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
