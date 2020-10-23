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
    public class UserCustomListItemsReorderRequest_Tests
    {
        [Fact]
        public void Test_UserCustomListItemsReorderRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserCustomListItemsReorderRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserCustomListItemsReorderRequest_Has_Valid_UriTemplate()
        {
            var request = new UserCustomListItemsReorderRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/items/reorder");
        }

        [Fact]
        public void Test_UserCustomListItemsReorderRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserCustomListItemsReorderRequest { Username = "username", Id = "list-id" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "list-id"
                                                   });
        }

        [Fact]
        public void Test_UserCustomListItemsReorderRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserCustomListItemsReorderRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty username
            request = new UserCustomListItemsReorderRequest { Username = string.Empty, Id = "list-id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // username with spaces
            request = new UserCustomListItemsReorderRequest { Username = "invalid username", Id = "list-id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // empty list id
            request = new UserCustomListItemsReorderRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // list id with spaces
            request = new UserCustomListItemsReorderRequest { Username = "username", Id = "list id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
