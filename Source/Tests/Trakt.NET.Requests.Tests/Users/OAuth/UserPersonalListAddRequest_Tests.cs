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
    public class UserPersonalListAddRequest_Tests
    {
        [Fact]
        public void Test_UserPersonalListAddRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserPersonalListAddRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserPersonalListAddRequest_Has_Valid_UriTemplate()
        {
            var request = new UserPersonalListAddRequest();
            request.UriTemplate.Should().Be("users/{username}/lists");
        }

        [Fact]
        public void Test_UserPersonalListAddRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserPersonalListAddRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });
        }

        [Fact]
        public void Test_UserPersonalListAddRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserPersonalListAddRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserPersonalListAddRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserPersonalListAddRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
