namespace TraktApiSharp.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class MetadataObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_MetadataObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new MetadataObjectJsonWriter();
            ITraktMetadata traktMetadata = new TraktMetadata();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktMetadata);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_StringWriter_Only_MediaType_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                MediaType = TraktMediaType.Digital
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new MetadataObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktMetadata);
                json.Should().Be(@"{""media_type"":""digital""}");
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_StringWriter_Only_MediaResolution_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                MediaResolution = TraktMediaResolution.UHD_4k
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new MetadataObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktMetadata);
                json.Should().Be(@"{""resolution"":""uhd_4k""}");
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_StringWriter_Only_Audio_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new MetadataObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktMetadata);
                json.Should().Be(@"{""audio"":""dolby_atmos""}");
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_StringWriter_Only_AudioChannels_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                AudioChannels = TraktMediaAudioChannel.Channels_7_1
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new MetadataObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktMetadata);
                json.Should().Be(@"{""audio_channels"":""7.1""}");
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_StringWriter_Only_ThreeDimensional_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                ThreeDimensional = true
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new MetadataObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktMetadata);
                json.Should().Be(@"{""3d"":true}");
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                MediaType = TraktMediaType.Digital,
                MediaResolution = TraktMediaResolution.UHD_4k,
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                ThreeDimensional = true
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new MetadataObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktMetadata);
                json.Should().Be(@"{""media_type"":""digital"",""resolution"":""uhd_4k"",""audio"":""dolby_atmos""," +
                                 @"""audio_channels"":""7.1"",""3d"":true}");
            }
        }
    }
}
