namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserStatisticsRequest_Tests
    {
        [Fact]
        public void Test_TraktUserStatisticsRequest_Is_Not_Abstract()
        {
            typeof(TraktUserStatisticsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserStatisticsRequest_Is_Sealed()
        {
            typeof(TraktUserStatisticsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserStatisticsRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktUserStatisticsRequest).IsSubclassOf(typeof(ATraktGetRequest<TraktUserStatistics>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserStatisticsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(TraktUserStatisticsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktUserStatisticsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserStatisticsRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_TraktUserStatisticsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserStatisticsRequest();
            request.UriTemplate.Should().Be("users/{username}/stats");
        }

        [Fact]
        public void Test_TraktUserStatisticsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktUserStatisticsRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });
        }

        [Fact]
        public void Test_TraktUserStatisticsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new TraktUserStatisticsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new TraktUserStatisticsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new TraktUserStatisticsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
