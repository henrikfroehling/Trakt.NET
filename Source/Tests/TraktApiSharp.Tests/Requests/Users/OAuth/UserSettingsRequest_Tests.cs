namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserSettingsRequest_Tests
    {
        [Fact]
        public void Test_UserSettingsRequest_Is_Not_Abstract()
        {
            typeof(UserSettingsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserSettingsRequest_Is_Sealed()
        {
            typeof(UserSettingsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserSettingsRequest_Inherits_AGetRequest_1()
        {
            typeof(UserSettingsRequest).IsSubclassOf(typeof(AGetRequest<ITraktUserSettings>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserSettingsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserSettingsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserSettingsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserSettingsRequest();
            request.UriTemplate.Should().Be("users/settings");
        }
    }
}
