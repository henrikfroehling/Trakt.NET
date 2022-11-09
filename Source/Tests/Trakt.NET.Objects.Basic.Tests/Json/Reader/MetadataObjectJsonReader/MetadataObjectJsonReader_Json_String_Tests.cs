﻿namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class MetadataObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.HDR.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.HDR.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.HDR.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.HDR.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.HDR.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.HDR.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.HDR.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktMetadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktMetadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktMetadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktMetadata.HDR.Should().Be(TraktMediaHDR.DolbyVision);
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            traktMetadata.Should().NotBeNull();
            traktMetadata.MediaType.Should().BeNull();
            traktMetadata.MediaResolution.Should().BeNull();
            traktMetadata.Audio.Should().BeNull();
            traktMetadata.AudioChannels.Should().BeNull();
            traktMetadata.HDR.Should().BeNull();
            traktMetadata.ThreeDimensional.Should().BeNull();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new MetadataObjectJsonReader();
            Func<Task<ITraktMetadata>> traktMetadata = () => jsonReader.ReadObjectAsync(default(string));
            await traktMetadata.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MetadataObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new MetadataObjectJsonReader();

            var traktMetadata = await jsonReader.ReadObjectAsync(string.Empty);
            traktMetadata.Should().BeNull();
        }
    }
}
