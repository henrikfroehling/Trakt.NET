namespace TraktNet.Tests.Modules.TraktAuthenticationModule
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Tests.TestUtils;
    using Xunit;

    [Category("Modules.Authentication")]
    public partial class TraktAuthenticationModule_Tests
    {
        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrl()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, client.ClientId, client.Authentication.RedirectUri);

            string createdUrl = client.Authentication.CreateAuthorizationUrl();
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrl_Staging_Default()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedStagingUrl = await BuildEncodedAuthorizeUrl(true, client.ClientId, client.Authentication.RedirectUri);

            string createdUrl = client.Authentication.CreateAuthorizationUrl();
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedStagingUrl);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CreateAuthorizationUrl_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            client.ClientId = null;

            Action act = () => client.Authentication.CreateAuthorizationUrl();
            act.Should().Throw<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.CreateAuthorizationUrl();
            act.Should().Throw<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.CreateAuthorizationUrl();
            act.Should().Throw<ArgumentException>();

            client.ClientId = TestConstants.TRAKT_CLIENT_ID;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.CreateAuthorizationUrl();
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.CreateAuthorizationUrl();
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.CreateAuthorizationUrl();
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrl_With_ClientId()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri);

            string createdUrl = client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrl_Staging_With_ClientId()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedStagingUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri);

            string createdUrl = client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedStagingUrl);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CreateAuthorizationUrl_With_ClientId_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Action act = () => client.Authentication.CreateAuthorizationUrl(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl("client id");
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.CreateAuthorizationUrl(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.CreateAuthorizationUrl(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.CreateAuthorizationUrl(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrl_With_ClientId_And_RedirectUri()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI);

            string createdUrl = client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrl_Staging_With_ClientId_And_RedirectUri()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI);

            string createdUrl = client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CreateAuthorizationUrl_With_ClientId_And_RedirectUri_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Action act = () => client.Authentication.CreateAuthorizationUrl(null, CUSTOM_REDIRECT_URI);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl(string.Empty, CUSTOM_REDIRECT_URI);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl("client id", CUSTOM_REDIRECT_URI);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, "redirect uri");
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrl_With_ClientId_And_RedirectUri_And_State()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, CUSTOM_STATE);

            string createdUrl = client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, CUSTOM_STATE);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrl_Staging_With_ClientId_And_RedirectUri_And_State()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, CUSTOM_STATE);

            string createdUrl = client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, CUSTOM_STATE);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CreateAuthorizationUrl_With_ClientId_And_RedirectUri_And_State_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Action act = () => client.Authentication.CreateAuthorizationUrl(null, CUSTOM_REDIRECT_URI, CUSTOM_STATE);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl(string.Empty, CUSTOM_REDIRECT_URI, CUSTOM_STATE);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl("client id", CUSTOM_REDIRECT_URI, CUSTOM_STATE);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, null, CUSTOM_STATE);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, string.Empty, CUSTOM_STATE);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, "redirect uri", CUSTOM_STATE);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, "custom state");
            act.Should().Throw<ArgumentException>();
        }
    }
}
