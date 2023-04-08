namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Users;
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
            var validPost = new TraktUserPersonalListPost
            {
                Name = "list name"
            };

            // request body is null
            var request = new UserPersonalListAddRequest { Username = "username" };

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty list name
            request = new UserPersonalListAddRequest { Username = "username", RequestBody = new TraktUserPersonalListPost { Name = string.Empty } };

            act = () => request.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // list privacy unspecified
            request = new UserPersonalListAddRequest
            {
                Username = "username",
                RequestBody = new TraktUserPersonalListPost
                {
                    Name = "list name",
                    Privacy = TraktAccessScope.Unspecified
                }
            };

            act = () => request.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // empty username
            request = new UserPersonalListAddRequest { Username = string.Empty, RequestBody = validPost };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserPersonalListAddRequest { Username = "invalid username", RequestBody = validPost };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
