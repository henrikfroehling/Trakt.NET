namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class ConnectionsObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            ITraktConnections traktConnections = new TraktConnections();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktConnections);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_JsonWriter_Only_Twitter_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Twitter = true
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktConnections);
            stringWriter.ToString().Should().Be(@"{""twitter"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_JsonWriter_Only_Google_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Google = true
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktConnections);
            stringWriter.ToString().Should().Be(@"{""google"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_JsonWriter_Only_Tumblr_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Tumblr = true
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktConnections);
            stringWriter.ToString().Should().Be(@"{""tumblr"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_JsonWriter_Only_Medium_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Medium = true
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktConnections);
            stringWriter.ToString().Should().Be(@"{""medium"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_JsonWriter_Only_Slack_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Slack = true
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktConnections);
            stringWriter.ToString().Should().Be(@"{""slack"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_JsonWriter_Only_Facebook_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Facebook = true
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktConnections);
            stringWriter.ToString().Should().Be(@"{""facebook"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_JsonWriter_Only_Apple_Property()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Apple = true
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktConnections);
            stringWriter.ToString().Should().Be(@"{""apple"":true}");
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktConnections traktConnections = new TraktConnections
            {
                Twitter = true,
                Google = true,
                Tumblr = true,
                Medium = true,
                Slack = true,
                Facebook = true,
                Apple = true
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            var traktJsonWriter = new ConnectionsObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktConnections);
            stringWriter.ToString().Should().Be(@"{""twitter"":true,""google"":true," +
                                                @"""tumblr"":true,""medium"":true,""slack"":true," +
                                                @"""facebook"":true,""apple"":true}");
        }
    }
}
