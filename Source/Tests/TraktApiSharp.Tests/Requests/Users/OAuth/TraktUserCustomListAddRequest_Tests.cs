namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Post.Users;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserCustomListAddRequest_Tests
    {
        [Fact]
        public void Test_TraktUserCustomListAddRequest_Is_Not_Abstract()
        {
            typeof(TraktUserCustomListAddRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserCustomListAddRequest_Is_Sealed()
        {
            typeof(TraktUserCustomListAddRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomListAddRequest_Inherits_ATraktPostRequest_2()
        {
            typeof(TraktUserCustomListAddRequest).IsSubclassOf(typeof(ATraktPostRequest<TraktList, TraktUserCustomListPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserCustomListAddRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserCustomListAddRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserCustomListAddRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserCustomListAddRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserCustomListAddRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserCustomListAddRequest();
            request.UriTemplate.Should().Be("users/{username}/lists");
        }

        [Fact]
        public void Test_TraktUserCustomListAddRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktUserCustomListAddRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });
        }

        [Fact]
        public void Test_TraktUserCustomListAddRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserCustomListAddRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserCustomListAddRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserCustomListAddRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
