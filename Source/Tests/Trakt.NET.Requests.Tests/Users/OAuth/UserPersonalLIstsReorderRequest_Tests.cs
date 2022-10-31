namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Basic;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserPersonalLIstsReorderRequest_Tests
    {
        [Fact]
        public void Test_UserPersonalListsReorderRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserPersonalListsReorderRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserPersonalListsReorderRequest_Has_Valid_UriTemplate()
        {
            var request = new UserPersonalListsReorderRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/reorder");
        }

        [Fact]
        public void Test_UserPersonalListsReorderRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserPersonalListsReorderRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });
        }

        [Fact]
        public void Test_UserPersonalListsReorderRequest_Validate_Throws_Exceptions()
        {
            var itemsReorderPost = new TraktListItemsReorderPost
            {
                Rank = new List<uint>()
            };

            // username is null
            var request = new UserPersonalListsReorderRequest { RequestBody = itemsReorderPost };

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserPersonalListsReorderRequest { Username = string.Empty, RequestBody = itemsReorderPost };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserPersonalListsReorderRequest { Username = "invalid username", RequestBody = itemsReorderPost };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
