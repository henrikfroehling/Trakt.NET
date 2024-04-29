﻿namespace TraktNet.Requests.Tests.Users.OAuth
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
    public class UserWatchingRequest_Tests
    {
        [Fact]
        public void Test_UserWatchingRequest_Has_AuthorizationRequirement_OptionalButMightBeRequired()
        {
            var request = new UserWatchingRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void Test_UserWatchingRequest_Has_Valid_UriTemplate()
        {
            var request = new UserWatchingRequest();
            request.UriTemplate.Should().Be("users/{username}/watching{?extended}");
        }

        [Fact]
        public void Test_UserWatchingRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserWatchingRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserWatchingRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_UserWatchingRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserWatchingRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserWatchingRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserWatchingRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
