namespace TraktApiSharp.Tests.Modules.TraktAuthenticationModule
{
    using FluentAssertions;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Authentication;
    using Xunit;

    [Category("Modules.Authentication")]
    public partial class TraktAuthenticationModule_Tests
    {
        [Fact]
        public void Test_TraktAuthenticationModule_Construction()
        {
            var client = new TraktClient();

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be(TestConstants.DEFAULT_REDIRECT_URI);
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValidForUseWithoutAuthorization.Should().BeFalse();
            client.IsValidForUseWithAuthorization.Should().BeFalse();
            client.IsValidForAuthenticationProcess.Should().BeFalse();

            client.Authentication.ClientId.Should().BeNull();
            client.Authentication.ClientSecret.Should().BeNull();
            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.IsExpired.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_Construction_With_Valid_AccessToken()
        {
            var client = new TraktClient()
            {
                Authorization = TraktAuthorization.CreateWith(TestConstants.MOCK_ACCESS_TOKEN)
            };

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be(TestConstants.DEFAULT_REDIRECT_URI);
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValidForUseWithoutAuthorization.Should().BeFalse();
            client.IsValidForUseWithAuthorization.Should().BeFalse();
            client.IsValidForAuthenticationProcess.Should().BeFalse();

            client.Authentication.ClientId.Should().BeNull();
            client.Authentication.ClientSecret.Should().BeNull();
            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.AccessToken.Should().Be(TestConstants.MOCK_ACCESS_TOKEN);
            client.Authentication.Authorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_Construction_With_Valid_ClientId()
        {
            var client = new TraktClient(TestConstants.TRAKT_CLIENT_ID);

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be(TestConstants.DEFAULT_REDIRECT_URI);
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValidForUseWithoutAuthorization.Should().BeTrue();
            client.IsValidForUseWithAuthorization.Should().BeFalse();
            client.IsValidForAuthenticationProcess.Should().BeFalse();

            client.Authentication.ClientId.Should().Be(TestConstants.TRAKT_CLIENT_ID);
            client.Authentication.ClientSecret.Should().BeNull();
            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.IsExpired.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_Construction_With_Valid_ClientId_And_AccessToken()
        {
            var client = new TraktClient(TestConstants.TRAKT_CLIENT_ID)
            {
                Authorization = TraktAuthorization.CreateWith(TestConstants.MOCK_ACCESS_TOKEN)
            };

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be(TestConstants.DEFAULT_REDIRECT_URI);
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValidForUseWithoutAuthorization.Should().BeTrue();
            client.IsValidForUseWithAuthorization.Should().BeTrue();
            client.IsValidForAuthenticationProcess.Should().BeFalse();

            client.Authentication.ClientId.Should().Be(TestConstants.TRAKT_CLIENT_ID);
            client.Authentication.ClientSecret.Should().BeNull();
            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.AccessToken.Should().Be(TestConstants.MOCK_ACCESS_TOKEN);
            client.Authentication.Authorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_Construction_With_Valid_ClientId_And_ClientSecret()
        {
            var client = new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET);

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be(TestConstants.DEFAULT_REDIRECT_URI);
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValidForUseWithoutAuthorization.Should().BeTrue();
            client.IsValidForUseWithAuthorization.Should().BeFalse();
            client.IsValidForAuthenticationProcess.Should().BeTrue();

            client.Authentication.ClientId.Should().Be(TestConstants.TRAKT_CLIENT_ID);
            client.Authentication.ClientSecret.Should().Be(TestConstants.TRAKT_CLIENT_SECRET);
            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.IsExpired.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_Construction_With_Valid_ClientId_And_ClientSecret_And_AccessToken()
        {
            var client = new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET)
            {
                Authorization = TraktAuthorization.CreateWith(TestConstants.MOCK_ACCESS_TOKEN)
            };

            client.Authentication.Client.Should().Be(client);
            client.Authentication.AntiForgeryToken.Should().NotBeNullOrEmpty();
            client.Authentication.RedirectUri.Should().Be(TestConstants.DEFAULT_REDIRECT_URI);
            client.Authentication.OAuthAuthorizationCode.Should().BeNull();

            client.IsValidForUseWithoutAuthorization.Should().BeTrue();
            client.IsValidForUseWithAuthorization.Should().BeTrue();
            client.IsValidForAuthenticationProcess.Should().BeTrue();

            client.Authentication.ClientId.Should().Be(TestConstants.TRAKT_CLIENT_ID);
            client.Authentication.ClientSecret.Should().Be(TestConstants.TRAKT_CLIENT_SECRET);
            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.AccessToken.Should().Be(TestConstants.MOCK_ACCESS_TOKEN);
            client.Authentication.Authorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_Construction_GetAuthorization_Default()
        {
            var client = new TraktClient();

            client.Authentication.Authorization.Should().NotBeNull();
            client.Authentication.Authorization.IsExpired.Should().BeTrue();
            client.Authentication.IsAuthorized.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_Construction_GetDevice_Default()
        {
            var client = new TraktClient();

            client.Authentication.Device.Should().NotBeNull();
            client.Authentication.Device.IsValid.Should().BeFalse();
        }
    }
}
