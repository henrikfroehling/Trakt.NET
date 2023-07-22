namespace TraktNet.Modules.Tests.TraktAuthenticationModule
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using Xunit;

    [TestCategory("Modules.Authentication")]
    public partial class TraktAuthenticationModule_Tests
    {
        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState();
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_Signup_False()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, false);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(false);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_Signup_True()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ForceLoginPrompt_False()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(null, false);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ForceLoginPrompt_True()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, null, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(null, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_Signup_False_And_ForceLoginPrompt()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, false, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(false, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_Signup_True_And_ForceLoginPrompt()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, true, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(true, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState();
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_Signup_False()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, false);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(false);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_Signup_True()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ForceLoginPrompt_False()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(null, false);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ForceLoginPrompt_True()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, null, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(null, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_Signup_False_And_ForceLoginPrompt()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, false, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(false, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_Signup_True_And_ForceLoginPrompt()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, client.ClientId, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, true, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(true, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            client.ClientId = null;

            Action act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState();
            act.Should().Throw<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState();
            act.Should().Throw<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState();
            act.Should().Throw<ArgumentException>();

            client.ClientId = TestConstants.TRAKT_CLIENT_ID;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState();
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState();
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState();
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_Signup_False()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, false);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, false);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_Signup_True()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_ForceLoginPrompt_False()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, null, false);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_ForceLoginPrompt_True()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, null, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, null, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_Signup_False_And_ForceLoginPrompt()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, false, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, false, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_Signup_True_And_ForceLoginPrompt()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, true, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, true, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId_And_Signup_False()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, false);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, false);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId_And_Signup_True()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId_And_ForceLoginPrompt_False()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, null, false);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId_And_ForceLoginPrompt_True()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, null, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, null, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId_And_Signup_False_And_ForceLoginPrompt()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, false, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, false, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId_And_Signup_True_And_ForceLoginPrompt()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, client.Authentication.RedirectUri, client.Authentication.AntiForgeryToken, true, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, true, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Action act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState(default(string));
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState("client id");
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_RedirectUri()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_RedirectUri_And_Signup_False()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken, false);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, false);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_RedirectUri_And_Signup_True()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_RedirectUri_And_ForceLoginPrompt_False()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, null, false);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_RedirectUri_And_ForceLoginPrompt_True()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken, null, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, null, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_RedirectUri_And_Signup_False_And_ForceLoginPrompt()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken, false, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, false, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_RedirectUri_And_Signup_True_And_ForceLoginPrompt()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            string encodedUrl = await BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken, true, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, true, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId_And_RedirectUri()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId_And_RedirectUri_And_Signup_False()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken, false);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, false);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId_And_RedirectUri_And_Signup_True()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId_And_RedirectUri_And_ForceLoginPrompt_False()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, null, false);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId_And_RedirectUri_And_ForceLoginPrompt_True()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken, null, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, null, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId_And_RedirectUri_And_Signup_False_And_ForceLoginPrompt()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken, false, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, false, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_Staging_And_ClientId_And_RedirectUri_And_Signup_True_And_ForceLoginPrompt()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Configuration.UseSandboxEnvironment = true;
            string encodedUrl = await BuildEncodedAuthorizeUrl(true, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.Authentication.AntiForgeryToken, true, true);

            string createdUrl = client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, true, true);
            createdUrl.Should().NotBeNullOrEmpty().And.Be(encodedUrl);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CreateAuthorizationUrlWithDefaultState_And_ClientId_And_RedirectUri_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Action act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState(null, CUSTOM_REDIRECT_URI);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState(string.Empty, CUSTOM_REDIRECT_URI);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState("client id", CUSTOM_REDIRECT_URI);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, default(string));
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, "redirect uri");
            act.Should().Throw<ArgumentException>();
        }
    }
}
