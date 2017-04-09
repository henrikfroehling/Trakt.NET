namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ITraktMetadataObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
                traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
                traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMetadata.Should().NotBeNull();
                traktMetadata.MediaType.Should().BeNull();
                traktMetadata.MediaResolution.Should().BeNull();
                traktMetadata.Audio.Should().BeNull();
                traktMetadata.AudioChannels.Should().BeNull();
                traktMetadata.ThreeDimensional.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktMetadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktMetadataObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMetadata = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktMetadata.Should().BeNull();
            }
        }
    }
}
