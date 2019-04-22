namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserSettingsRequest_Tests
    {
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
