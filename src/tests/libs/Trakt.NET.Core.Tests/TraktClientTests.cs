namespace TraktNET
{
    public class TraktClientTests
    {
        private const string ClientID = "clientID";
        private const string ClientSecret = "clientSecret";

        [Fact]
        public void TestTraktClientFromContext()
        {
            var context = new TraktContext(ClientID, ClientSecret);
            var client = new TraktClient(context);

            client.Context.Should().NotBeNull();
            client.ClientID.Should().Be(ClientID);
            client.ClientSecret.Should().Be(ClientSecret);
        }

        [Fact]
        public void TestTraktClientWithClientIDAndSecret()
        {
            var client = new TraktClient(ClientID, ClientSecret);

            client.Context.Should().NotBeNull();
            client.Context.ClientID.Should().Be(ClientID);
            client.Context.ClientSecret.Should().Be(ClientSecret);
            client.ClientID.Should().Be(ClientID);
            client.ClientSecret.Should().Be(ClientSecret);
        }
    }
}
