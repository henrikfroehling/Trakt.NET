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

    [Category("Objects.Basic.JsonReader")]
    public partial class SharingObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeTrue();
                traktSharing.Google.Should().BeTrue();
                traktSharing.Tumblr.Should().BeTrue();
                traktSharing.Medium.Should().BeTrue();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSharing.Should().NotBeNull();
                traktSharing.Twitter.Should().BeNull();
                traktSharing.Google.Should().BeNull();
                traktSharing.Tumblr.Should().BeNull();
                traktSharing.Medium.Should().BeNull();
                traktSharing.Slack.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SharingObjectJsonReader();
            Func<Task<ITraktSharing>> traktSharing = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktSharing.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SharingObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SharingObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSharing = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktSharing.Should().BeNull();
            }
        }
    }
}
