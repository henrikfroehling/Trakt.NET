namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserStatisticsRequest_Tests
    {
        [Fact]
        public void Test_UserStatisticsRequest_Is_Not_Abstract()
        {
            typeof(UserStatisticsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserStatisticsRequest_Is_Sealed()
        {
            typeof(UserStatisticsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserStatisticsRequest_Inherits_AGetRequest_1()
        {
            typeof(UserStatisticsRequest).IsSubclassOf(typeof(AGetRequest<ITraktUserStatistics>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserStatisticsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserStatisticsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserStatisticsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserStatisticsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserStatisticsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserStatisticsRequest();
            request.UriTemplate.Should().Be("users/{username}/stats");
        }

        [Fact]
        public void Test_UserStatisticsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserStatisticsRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });
        }

        [Fact]
        public void Test_UserStatisticsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserStatisticsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserStatisticsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserStatisticsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
