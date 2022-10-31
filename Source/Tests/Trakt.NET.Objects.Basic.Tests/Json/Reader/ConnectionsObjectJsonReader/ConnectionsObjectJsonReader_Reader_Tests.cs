namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class ConnectionsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeNull();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeNull();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeNull();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeNull();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeNull();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeNull();
            traktConnections.Apple.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_7);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeNull();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeNull();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeNull();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeNull();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeNull();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeNull();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeNull();
            traktConnections.Apple.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_7);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeTrue();
            traktConnections.Google.Should().BeTrue();
            traktConnections.Tumblr.Should().BeTrue();
            traktConnections.Medium.Should().BeTrue();
            traktConnections.Slack.Should().BeTrue();
            traktConnections.Facebook.Should().BeTrue();
            traktConnections.Apple.Should().BeNull();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_8()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_8);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktConnections.Should().NotBeNull();

            traktConnections.Twitter.Should().BeNull();
            traktConnections.Google.Should().BeNull();
            traktConnections.Tumblr.Should().BeNull();
            traktConnections.Medium.Should().BeNull();
            traktConnections.Slack.Should().BeNull();
            traktConnections.Facebook.Should().BeNull();
            traktConnections.Apple.Should().BeNull();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();
            Func<Task<ITraktConnections>> traktConnections = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktConnections.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ConnectionsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ConnectionsObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktConnections = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktConnections.Should().BeNull();
        }
    }
}
