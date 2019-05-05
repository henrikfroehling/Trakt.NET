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
    public class UserCustomListsReorderRequest_Tests
    {
        [Fact]
        public void Test_UserCustomListsReorderRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserCustomListsReorderRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserCustomListsReorderRequest_Has_Valid_UriTemplate()
        {
            var request = new UserCustomListsReorderRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/reorder");
        }

        [Fact]
        public void Test_UserCustomListsReorderRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserCustomListsReorderRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });
        }

        [Fact]
        public void Test_UserCustomListsReorderRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserCustomListsReorderRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty username
            request = new UserCustomListsReorderRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // username with spaces
            request = new UserCustomListsReorderRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
