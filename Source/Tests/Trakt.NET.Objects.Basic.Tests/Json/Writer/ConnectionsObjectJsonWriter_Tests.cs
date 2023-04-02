namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class ConnectionsObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_Only_Twitter_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Twitter = true
            };

            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktConnections);
            json.Should().Be(@"{""twitter"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_Only_Google_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Google = true
            };

            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktConnections);
            json.Should().Be(@"{""google"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_Only_Tumblr_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Tumblr = true
            };

            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktConnections);
            json.Should().Be(@"{""tumblr"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_Only_Medium_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Medium = true
            };

            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktConnections);
            json.Should().Be(@"{""medium"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_Only_Slack_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Slack = true
            };

            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktConnections);
            json.Should().Be(@"{""slack"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_Only_Facebook_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Facebook = true
            };

            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktConnections);
            json.Should().Be(@"{""facebook"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_Only_Apple_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Apple = true
            };

            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktConnections);
            json.Should().Be(@"{""apple"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_Only_Mastodon_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Mastodon = true
            };

            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktConnections);
            json.Should().Be(@"{""mastodon"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_Only_Microsoft_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Microsoft = true
            };

            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktConnections);
            json.Should().Be(@"{""microsoft"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_Only_Dropbox_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Dropbox = true
            };

            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktConnections);
            json.Should().Be(@"{""dropbox"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_Complete()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Twitter = true,
                Google = true,
                Tumblr = true,
                Medium = true,
                Slack = true,
                Facebook = true,
                Apple = true,
                Mastodon = true,
                Microsoft = true,
                Dropbox = true
            };

            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktConnections);
            json.Should().Be(@"{""twitter"":true,""google"":true," +
                             @"""tumblr"":true,""medium"":true,""slack"":true," +
                             @"""facebook"":true,""apple"":true,""mastodon"":true," +
                             @"""microsoft"":true,""dropbox"":true}");
        }
    }
}
