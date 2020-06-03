namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class SharingObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_SharingObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new SharingObjectJsonWriter();
            ITraktSharing traktSharing = new TraktSharing();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktSharing);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_StringWriter_Only_Facebook_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Facebook = true
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSharing);
                json.Should().Be(@"{""facebook"":true}");
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_StringWriter_Only_Twitter_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Twitter = true
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSharing);
                json.Should().Be(@"{""twitter"":true}");
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_StringWriter_Only_Google_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Google = true
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSharing);
                json.Should().Be(@"{""google"":true}");
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_StringWriter_Only_Tumblr_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Tumblr = true
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSharing);
                json.Should().Be(@"{""tumblr"":true}");
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_StringWriter_Only_Medium_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Medium = true
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSharing);
                json.Should().Be(@"{""medium"":true}");
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_StringWriter_Only_Slack_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Slack = true
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSharing);
                json.Should().Be(@"{""slack"":true}");
            }
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_StringWriter_Complete()
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
            {
                var traktJsonWriter = new SharingObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktSharing);
                json.Should().Be(@"{""facebook"":true,""twitter"":true,""google"":true," +
                                 @"""tumblr"":true,""medium"":true,""slack"":true}");
            }
        }
    }
}
