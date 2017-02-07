namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Post.Users.Responses;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserFollowUserRequest_Tests
    {
        [Fact]
        public void Test_TraktUserFollowUserRequest_Is_Not_Abstract()
        {
            typeof(TraktUserFollowUserRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserFollowUserRequest_Is_Sealed()
        {
            typeof(TraktUserFollowUserRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserFollowUserRequest_Inherits_ATraktBodylessPostRequest_1()
        {
            typeof(TraktUserFollowUserRequest).IsSubclassOf(typeof(ATraktBodylessPostRequest<TraktUserFollowUserPostResponse>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserFollowUserRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserFollowUserRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserFollowUserRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserFollowUserRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserFollowUserRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserFollowUserRequest();
            request.UriTemplate.Should().Be("users/{username}/follow");
        }

        [Fact]
        public void Test_TraktUserFollowUserRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktUserFollowUserRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });
        }

        [Fact]
        public void Test_TraktUserFollowUserRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserFollowUserRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserFollowUserRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserFollowUserRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
