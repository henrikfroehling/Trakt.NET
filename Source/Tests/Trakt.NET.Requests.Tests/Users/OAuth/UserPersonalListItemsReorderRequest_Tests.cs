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
    public class UserPersonalListItemsReorderRequest_Tests
    {
        [Fact]
        public void Test_UserPersonalListItemsReorderRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserPersonalListItemsReorderRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserPersonalListItemsReorderRequest_Has_Valid_UriTemplate()
        {
            var request = new UserPersonalListItemsReorderRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/items/reorder");
        }

        [Fact]
        public void Test_UserPersonalListItemsReorderRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserPersonalListItemsReorderRequest { Username = "username", Id = "list-id" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "list-id"
                                                   });
        }

        [Fact]
        public void Test_UserPersonalListItemsReorderRequest_Validate_Throws_Exceptions()
        {
            var itemsReorderPost = new TraktListItemsReorderPost
            {
                Rank = new List<uint>()
            };

            // username is null
            var request = new UserPersonalListItemsReorderRequest { RequestBody = itemsReorderPost };

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserPersonalListItemsReorderRequest { Username = string.Empty, Id = "list-id", RequestBody = itemsReorderPost };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserPersonalListItemsReorderRequest { Username = "invalid username", Id = "list-id", RequestBody = itemsReorderPost };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty list id
            request = new UserPersonalListItemsReorderRequest { Username = "username", Id = string.Empty, RequestBody = itemsReorderPost };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // list id with spaces
            request = new UserPersonalListItemsReorderRequest { Username = "username", Id = "list id", RequestBody = itemsReorderPost };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
