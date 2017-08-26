namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserSettingsRequest_Tests
    {
        [Fact]
        public void Test_TraktUserSettingsRequest_Is_Not_Abstract()
        {
            typeof(TraktUserSettingsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserSettingsRequest_Is_Sealed()
        {
            typeof(TraktUserSettingsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserSettingsRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktUserSettingsRequest).IsSubclassOf(typeof(AGetRequest<ITraktUserSettings>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserSettingsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserSettingsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserSettingsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserSettingsRequest();
            request.UriTemplate.Should().Be("users/settings");
        }
    }
}
