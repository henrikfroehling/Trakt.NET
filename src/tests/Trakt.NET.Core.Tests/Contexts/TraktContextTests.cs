namespace TraktNET.Contexts
{
    public class TraktContextTests
    {
        private const string ContextID = "contextID";
        private const string ClientID = "clientID";
        private const string ClientSecret = "clientSecret";

        [Fact]
        public void TestTraktContextWithClientIDAndSecret()
        {
            var context = new TraktContext(ClientID, ClientSecret);

            context.ID.Should().NotBeNullOrEmpty();
            context.ClientID.Should().Be(ClientID);
            context.ClientSecret.Should().Be(ClientSecret);
        }

        [Fact]
        public void TestTraktContextWithContextIDAndClientIDAndSecret()
        {
            var context = new TraktContext(ContextID, ClientID, ClientSecret);

            context.ID.Should().Be(ContextID);
            context.ClientID.Should().Be(ClientID);
            context.ClientSecret.Should().Be(ClientSecret);
        }

        [Fact]
        public void TestTraktContextHasCorrectBaseUri()
        {
            var context = new TraktContext(ClientID, ClientSecret);

            context.BaseUri.AbsoluteUri.Should().Be("https://api.trakt.tv/");
        }

        [Fact]
        public void TestTraktContextHasCorrectBaseAuthorizationUri()
        {
            var context = new TraktContext(ClientID, ClientSecret);

            context.BaseAuthorizationUri.AbsoluteUri.Should().Be("https://trakt.tv/");
        }

        [Fact]
        public void TestTraktContextInvalidContextID()
        {
            Action act = () => _ = new TraktContext(string.Empty, ClientID, ClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => _ = new TraktContext("    ", ClientID, ClientSecret);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestTraktContextInvalidClientID()
        {
            Action act = () => _ = new TraktContext(string.Empty, ClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => _ = new TraktContext("    ", ClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => _ = new TraktContext(" id ", ClientSecret);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestTraktContextInvalidClientSecret()
        {
            Action act = () => _ = new TraktContext(ClientID, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => _ = new TraktContext(ClientID, "        ");
            act.Should().Throw<ArgumentException>();

            act = () => _ = new TraktContext(ClientID, " secret ");
            act.Should().Throw<ArgumentException>();
        }
    }
}
