namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserCustomListsRequest_Tests
    {
        [Fact]
        public void Test_UserCustomListsRequest_Is_Not_Abstract()
        {
            typeof(UserCustomListsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserCustomListsRequest_Is_Sealed()
        {
            typeof(UserCustomListsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserCustomListsRequest_Inherits_AGetRequest_1()
        {
            typeof(UserCustomListsRequest).IsSubclassOf(typeof(AGetRequest<ITraktList>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserCustomListsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserCustomListsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserCustomListsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserCustomListsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserCustomListsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserCustomListsRequest();
            request.UriTemplate.Should().Be("users/{username}/lists");
        }

        [Fact]
        public void Test_UserCustomListsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserCustomListsRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                   });
        }

        [Fact]
        public void Test_UserCustomListsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserCustomListsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserCustomListsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserCustomListsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
