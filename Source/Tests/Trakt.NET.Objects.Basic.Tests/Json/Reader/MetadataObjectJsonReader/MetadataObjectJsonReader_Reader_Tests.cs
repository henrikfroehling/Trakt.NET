namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class MetadataObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.HDR.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktMetadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MetadataObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktMetadata.Should().BeNull();
            }
        }
    }
}
