namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ITraktMetadataObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(default(string));
            traktMetadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMetadataObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktMetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(string.Empty);
            traktMetadata.Should().BeNull();
        }
    }
}
