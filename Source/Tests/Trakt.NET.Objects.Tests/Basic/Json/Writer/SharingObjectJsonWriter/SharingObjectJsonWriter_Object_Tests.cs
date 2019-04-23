namespace TraktNet.Objects.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class SharingObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_SharingObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new SharingObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_Object_Only_Twitter_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Twitter = true
            };

            var traktJsonWriter = new SharingObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSharing);
            json.Should().Be(@"{""twitter"":true}");
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_Object_Only_Google_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Google = true
            };

            var traktJsonWriter = new SharingObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSharing);
            json.Should().Be(@"{""google"":true}");
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_Object_Only_Tumblr_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Tumblr = true
            };

            var traktJsonWriter = new SharingObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSharing);
            json.Should().Be(@"{""tumblr"":true}");
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_Object_Only_Medium_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Medium = true
            };

            var traktJsonWriter = new SharingObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSharing);
            json.Should().Be(@"{""medium"":true}");
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_Object_Only_Slack_Property()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Slack = true
            };

            var traktJsonWriter = new SharingObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSharing);
            json.Should().Be(@"{""slack"":true}");
        }

        [Fact]
        public async Task Test_SharingObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktSharing traktSharing = new TraktSharing
            {
                Twitter = true,
                Google = true,
                Tumblr = true,
                Medium = true,
                Slack = true
            };

            var traktJsonWriter = new SharingObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSharing);
            json.Should().Be(@"{""twitter"":true,""google"":true," +
                             @"""tumblr"":true,""medium"":true,""slack"":true}");
        }
    }
}
