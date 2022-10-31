namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
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
        public async Task Test_MetadataArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktMetadata>();
            IEnumerable<ITraktMetadata> traktMetadata = new List<TraktMetadata>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktMetadata);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MetadataArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktMetadata> traktMetadata = new List<TraktMetadata>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktMetadata>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktMetadata);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktMetadata>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktMetadata);
                stringWriter.ToString().Should().Be(@"[{""media_type"":""digital"",""resolution"":""uhd_4k"",""audio"":""dolby_atmos""," +
                                                    @"""audio_channels"":""7.1"",""3d"":true,""hdr"":""dolby_vision""}]");
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonWriter_WriteArray_JsonWriter_Complete()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktMetadata>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktMetadata);
                stringWriter.ToString().Should().Be(@"[{""media_type"":""digital"",""resolution"":""uhd_4k"",""audio"":""dolby_atmos""," +
                                                    @"""audio_channels"":""7.1"",""3d"":true,""hdr"":""dolby_vision""}," +
                                                    @"{""media_type"":""digital"",""resolution"":""uhd_4k"",""audio"":""dolby_atmos""," +
                                                    @"""audio_channels"":""7.1"",""3d"":true,""hdr"":""dolby_vision""}]");
            }
        }
    }
}
