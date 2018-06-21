namespace TraktNet.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class SharingObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_SharingObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new SharingObjectJsonWriter();
            ITraktSharing traktSharing = new TraktSharing();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktSharing);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_JsonWriter_Only_Facebook_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Facebook = true
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSharing);
                stringWriter.ToString().Should().Be(@"{""facebook"":true}");
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_JsonWriter_Only_Twitter_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Twitter = true
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSharing);
                stringWriter.ToString().Should().Be(@"{""twitter"":true}");
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_JsonWriter_Only_Google_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Google = true
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSharing);
                stringWriter.ToString().Should().Be(@"{""google"":true}");
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_JsonWriter_Only_Tumblr_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Tumblr = true
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSharing);
                stringWriter.ToString().Should().Be(@"{""tumblr"":true}");
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_JsonWriter_Only_Medium_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Medium = true
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSharing);
                stringWriter.ToString().Should().Be(@"{""medium"":true}");
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_JsonWriter_Only_Slack_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Slack = true
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSharing);
                stringWriter.ToString().Should().Be(@"{""slack"":true}");
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Facebook = true,
                Twitter = true,
                Google = true,
                Tumblr = true,
                Medium = true,
                Slack = true
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktSharing);
                stringWriter.ToString().Should().Be(@"{""facebook"":true,""twitter"":true,""google"":true," +
                                                    @"""tumblr"":true,""medium"":true,""slack"":true}");
            }
        }
    }
}
