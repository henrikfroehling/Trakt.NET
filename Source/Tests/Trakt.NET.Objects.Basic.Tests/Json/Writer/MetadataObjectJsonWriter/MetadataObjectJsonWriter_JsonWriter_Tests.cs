﻿namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class MetadataObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new MetadataObjectJsonWriter();
            ITraktMetadata traktMetadata = new TraktMetadata();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktMetadata);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_JsonWriter_Only_MediaType_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                MediaType = TraktMediaType.Digital
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new MetadataObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktMetadata);
                stringWriter.ToString().Should().Be(@"{""media_type"":""digital""}");
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_JsonWriter_Only_MediaResolution_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                MediaResolution = TraktMediaResolution.UHD_4k
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new MetadataObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktMetadata);
                stringWriter.ToString().Should().Be(@"{""resolution"":""uhd_4k""}");
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_JsonWriter_Only_Audio_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                Audio = TraktMediaAudio.DolbyAtmos
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new MetadataObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktMetadata);
                stringWriter.ToString().Should().Be(@"{""audio"":""dolby_atmos""}");
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_JsonWriter_Only_AudioChannels_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                AudioChannels = TraktMediaAudioChannel.Channels_7_1
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new MetadataObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktMetadata);
                stringWriter.ToString().Should().Be(@"{""audio_channels"":""7.1""}");
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_JsonWriter_Only_HDR_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                HDR = TraktMediaHDR.DolbyVision
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new MetadataObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktMetadata);
                stringWriter.ToString().Should().Be(@"{""hdr"":""dolby_vision""}");
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_JsonWriter_Only_ThreeDimensional_Property()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                ThreeDimensional = true
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new MetadataObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktMetadata);
                stringWriter.ToString().Should().Be(@"{""3d"":true}");
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktMetadata traktMetadata = new TraktMetadata
            {
                MediaType = TraktMediaType.Digital,
                MediaResolution = TraktMediaResolution.UHD_4k,
                Audio = TraktMediaAudio.DolbyAtmos,
                AudioChannels = TraktMediaAudioChannel.Channels_7_1,
                HDR = TraktMediaHDR.DolbyVision,
                ThreeDimensional = true
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new MetadataObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktMetadata);
                stringWriter.ToString().Should().Be(@"{""media_type"":""digital"",""resolution"":""uhd_4k"",""audio"":""dolby_atmos""," +
                                                    @"""audio_channels"":""7.1"",""3d"":true,""hdr"":""dolby_vision""}");
            }
        }
    }
}
