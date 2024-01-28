namespace TraktNET.Contexts
{
    public class TraktSandboxContextTests
    {
        private const string ContextID = "contextID";
        private const string ClientID = "clientID";
        private const string ClientSecret = "clientSecret";

        [Fact]
        public void TestTraktSandboxContextWithClientIDAndSecret()
        {
            var context = new TraktSandboxContext(ClientID, ClientSecret);

            context.ID.Should().NotBeNullOrEmpty();
            context.ClientID.Should().Be(ClientID);
            context.ClientSecret.Should().Be(ClientSecret);
        }

        [Fact]
        public void TestTraktSandboxContextWithContextIDAndClientIDAndSecret()
        {
            var context = new TraktSandboxContext(ContextID, ClientID, ClientSecret);

            context.ID.Should().Be(ContextID);
            context.ClientID.Should().Be(ClientID);
            context.ClientSecret.Should().Be(ClientSecret);
        }

        [Fact]
        public void TestTraktSandboxContextHasCorrectBaseUri()
        {
            var context = new TraktSandboxContext(ClientID, ClientSecret);

            context.BaseUri.AbsoluteUri.Should().Be("https://api-staging.trakt.tv/");
        }

        [Fact]
        public void TestTraktSandboxContextHasCorrectBaseAuthorizationUri()
        {
            var context = new TraktSandboxContext(ClientID, ClientSecret);

            context.BaseAuthorizationUri.AbsoluteUri.Should().Be("https://staging.trakt.tv/");
        }

        [Fact]
        public void TestTraktSandboxContextInvalidContextID()
        {
            Action act = () => _ = new TraktSandboxContext(string.Empty, ClientID, ClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => _ = new TraktSandboxContext("    ", ClientID, ClientSecret);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestTraktSandboxContextInvalidClientID()
        {
            Action act = () => _ = new TraktSandboxContext(string.Empty, ClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => _ = new TraktSandboxContext("    ", ClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => _ = new TraktSandboxContext(" id ", ClientSecret);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestTraktSandboxContextInvalidClientSecret()
        {
            Action act = () => _ = new TraktSandboxContext(ClientID, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => _ = new TraktSandboxContext(ClientID, "        ");
            act.Should().Throw<ArgumentException>();

            act = () => _ = new TraktSandboxContext(ClientID, " secret ");
            act.Should().Throw<ArgumentException>();
        }
    }
}
