namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class MetadataArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_MetadataArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            ArrayJsonWriter<ITraktMetadata> traktJsonWriter = new ArrayJsonWriter<ITraktMetadata>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MetadataArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktMetadata> traktMetadata = new List<TraktMetadata>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktMetadata>();
            string json = await traktJsonWriter.WriteArrayAsync(traktMetadata);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_MetadataArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktMetadata> traktMetadata = new List<ITraktMetadata>
            {
                new TraktMetadata
                {
                    MediaType = TraktMediaType.Digital,
                    MediaResolution = TraktMediaResolution.UHD_4k,
                    Audio = TraktMediaAudio.DolbyAtmos,
                    AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                    HDR = TraktMediaHDR.DolbyVision,
                    ThreeDimensional = true
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktMetadata>();
            string json = await traktJsonWriter.WriteArrayAsync(traktMetadata);
            json.Should().Be(@"[{""media_type"":""digital"",""resolution"":""uhd_4k"",""audio"":""dolby_atmos""," +
                             @"""audio_channels"":""7.1"",""3d"":true,""hdr"":""dolby_vision""}]");
        }

        [Fact]
        public async Task Test_MetadataArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktMetadata> traktMetadata = new List<ITraktMetadata>
            {
                new TraktMetadata
                {
                    MediaType = TraktMediaType.Digital,
                    MediaResolution = TraktMediaResolution.UHD_4k,
                    Audio = TraktMediaAudio.DolbyAtmos,
                    AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                    HDR = TraktMediaHDR.DolbyVision,
                    ThreeDimensional = true
                },
                new TraktMetadata
                {
                    MediaType = TraktMediaType.Digital,
                    MediaResolution = TraktMediaResolution.UHD_4k,
                    Audio = TraktMediaAudio.DolbyAtmos,
                    AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                    HDR = TraktMediaHDR.DolbyVision,
                    ThreeDimensional = true
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktMetadata>();
            string json = await traktJsonWriter.WriteArrayAsync(traktMetadata);
            json.Should().Be(@"[{""media_type"":""digital"",""resolution"":""uhd_4k"",""audio"":""dolby_atmos""," +
                             @"""audio_channels"":""7.1"",""3d"":true,""hdr"":""dolby_vision""}," +
                             @"{""media_type"":""digital"",""resolution"":""uhd_4k"",""audio"":""dolby_atmos""," +
                             @"""audio_channels"":""7.1"",""3d"":true,""hdr"":""dolby_vision""}]");
        }
    }
}
