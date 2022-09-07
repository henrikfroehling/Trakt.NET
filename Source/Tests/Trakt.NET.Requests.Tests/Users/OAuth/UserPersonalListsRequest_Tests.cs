namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserPersonalListsRequest_Tests
    {
        [Fact]
        public void Test_UserPersonalListsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserPersonalListsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserPersonalListsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserPersonalListsRequest();
            request.UriTemplate.Should().Be("users/{username}/lists");
        }

        [Fact]
        public void Test_UserPersonalListsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserPersonalListsRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                   });
        }

        [Fact]
        public void Test_UserPersonalListsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserPersonalListsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty username
            request = new UserPersonalListsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // username with spaces
            request = new UserPersonalListsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
