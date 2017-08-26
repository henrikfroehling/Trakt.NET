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
    public class TraktUserCustomListsRequest_Tests
    {
        [Fact]
        public void Test_TraktUserCustomListsRequest_Is_Not_Abstract()
        {
            typeof(TraktUserCustomListsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserCustomListsRequest_Is_Sealed()
        {
            typeof(TraktUserCustomListsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomListsRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktUserCustomListsRequest).IsSubclassOf(typeof(AGetRequest<ITraktList>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomListsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserCustomListsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserCustomListsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserCustomListsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserCustomListsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserCustomListsRequest();
            request.UriTemplate.Should().Be("users/{username}/lists");
        }

        [Fact]
        public void Test_TraktUserCustomListsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktUserCustomListsRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                   });
        }

        [Fact]
        public void Test_TraktUserCustomListsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserCustomListsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserCustomListsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserCustomListsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
