﻿namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class MetadataArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new MetadataArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktMetadatas.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new MetadataArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktMetadatas.Should().NotBeNull();
                ITraktMetadata[] metadatas = traktMetadatas.ToArray();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().Be(TraktMediaType.Digital);
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].ThreeDimensional.Should().BeTrue();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().Be(TraktMediaType.Digital);
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MetadataArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktMetadatas.Should().NotBeNull();
                ITraktMetadata[] metadatas = traktMetadatas.ToArray();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().Be(TraktMediaType.Digital);
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].ThreeDimensional.Should().BeTrue();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().BeNull();
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MetadataArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktMetadatas.Should().NotBeNull();
                ITraktMetadata[] metadatas = traktMetadatas.ToArray();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().BeNull();
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].ThreeDimensional.Should().BeTrue();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().Be(TraktMediaType.Digital);
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MetadataArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktMetadatas.Should().NotBeNull();
                ITraktMetadata[] metadatas = traktMetadatas.ToArray();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().BeNull();
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].ThreeDimensional.Should().BeTrue();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().Be(TraktMediaType.Digital);
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MetadataArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktMetadatas.Should().NotBeNull();
                ITraktMetadata[] metadatas = traktMetadatas.ToArray();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().Be(TraktMediaType.Digital);
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].ThreeDimensional.Should().BeTrue();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().BeNull();
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MetadataArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktMetadatas.Should().NotBeNull();
                ITraktMetadata[] metadatas = traktMetadatas.ToArray();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().BeNull();
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].ThreeDimensional.Should().BeTrue();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().BeNull();
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new MetadataArrayJsonReader();
            IEnumerable<ITraktMetadata> traktMetadatas = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktMetadatas.Should().BeNull();
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new MetadataArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktMetadatas.Should().BeNull();
            }
        }
    }
}
