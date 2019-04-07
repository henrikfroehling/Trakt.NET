namespace TraktNet.Objects.Tests.Basic.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktMetadata_Tests
    {
        [Fact]
        public void Test_TraktMetadata_Default_Constructor()
        {
            var traktMetadata = new TraktMetadata();

            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.HDR.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktMetadata_From_Json()
        {
            var jsonReader = new MetadataObjectJsonReader();
            var traktMetadata = await jsonReader.ReadObjectAsync(JSON) as TraktMetadata;

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        private const string JSON =
            @"{
                ""media_type"": ""digital"",
                ""resolution"": ""hd_720p"",
                ""audio"": ""aac"",
                ""audio_channels"": ""5.1"",
                ""hdr"": ""dolby_vision"",
                ""3d"": true
              }";
    }
}
