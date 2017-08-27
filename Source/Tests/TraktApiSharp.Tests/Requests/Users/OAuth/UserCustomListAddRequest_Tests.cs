namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Post.Users;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserCustomListAddRequest_Tests
    {
        [Fact]
        public void Test_UserCustomListAddRequest_Is_Not_Abstract()
        {
            typeof(UserCustomListAddRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserCustomListAddRequest_Is_Sealed()
        {
            typeof(UserCustomListAddRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserCustomListAddRequest_Inherits_ATraktPostRequest_2()
        {
            typeof(UserCustomListAddRequest).IsSubclassOf(typeof(APostRequest<ITraktList, TraktUserCustomListPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserCustomListAddRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserCustomListAddRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserCustomListAddRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserCustomListAddRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserCustomListAddRequest_Has_Valid_UriTemplate()
        {
            var request = new UserCustomListAddRequest();
            request.UriTemplate.Should().Be("users/{username}/lists");
        }

        [Fact]
        public void Test_UserCustomListAddRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserCustomListAddRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });
        }

        [Fact]
        public void Test_UserCustomListAddRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserCustomListAddRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserCustomListAddRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserCustomListAddRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
