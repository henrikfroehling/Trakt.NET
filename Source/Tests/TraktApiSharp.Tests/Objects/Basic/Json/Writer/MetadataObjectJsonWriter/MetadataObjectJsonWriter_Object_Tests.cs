namespace TraktNet.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class MetadataObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_MetadataObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new MetadataObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktMetadata));
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_Object_Only_MediaType_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                MediaType = TraktMediaType.Digital
            };

            var traktJsonWriter = new MetadataObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMetadata);
            json.Should().Be(@"{""media_type"":""digital""}");
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_Object_Only_MediaResolution_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                MediaResolution = TraktMediaResolution.UHD_4k
            };

            var traktJsonWriter = new MetadataObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMetadata);
            json.Should().Be(@"{""resolution"":""uhd_4k""}");
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_Object_Only_Audio_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos
            };

            var traktJsonWriter = new MetadataObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMetadata);
            json.Should().Be(@"{""audio"":""dolby_atmos""}");
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_Object_Only_AudioChannels_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                AudioChannels = TraktMediaAudioChannel.Channels_7_1
            };

            var traktJsonWriter = new MetadataObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMetadata);
            json.Should().Be(@"{""audio_channels"":""7.1""}");
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_Object_Only_ThreeDimensional_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                ThreeDimensional = true
            };

            var traktJsonWriter = new MetadataObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMetadata);
            json.Should().Be(@"{""3d"":true}");
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                MediaType = TraktMediaType.Digital,
                MediaResolution = TraktMediaResolution.UHD_4k,
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                ThreeDimensional = true
            };

            var traktJsonWriter = new MetadataObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMetadata);
            json.Should().Be(@"{""media_type"":""digital"",""resolution"":""uhd_4k"",""audio"":""dolby_atmos""," +
                             @"""audio_channels"":""7.1"",""3d"":true}");
        }
    }
}
