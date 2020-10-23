namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class MetadataArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(stream);
                traktMetadatas.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(stream);

                traktMetadatas.Should().NotBeNull();
                ITraktMetadata[] metadatas = traktMetadatas.ToArray();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().Be(TraktMediaType.Digital);
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
                metadatas[0].ThreeDimensional.Should().BeTrue();

                metadatas[1].Should().NotBeNull();
                metadatas[1].MediaType.Should().Be(TraktMediaType.Digital);
                metadatas[1].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[1].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
                metadatas[1].ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(stream);

                traktMetadatas.Should().NotBeNull();
                ITraktMetadata[] metadatas = traktMetadatas.ToArray();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().Be(TraktMediaType.Digital);
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
                metadatas[0].ThreeDimensional.Should().BeTrue();

                metadatas[1].Should().NotBeNull();
                metadatas[1].MediaType.Should().BeNull();
                metadatas[1].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[1].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
                metadatas[1].ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(stream);

                traktMetadatas.Should().NotBeNull();
                ITraktMetadata[] metadatas = traktMetadatas.ToArray();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().BeNull();
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
                metadatas[0].ThreeDimensional.Should().BeTrue();

                metadatas[1].Should().NotBeNull();
                metadatas[1].MediaType.Should().Be(TraktMediaType.Digital);
                metadatas[1].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[1].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
                metadatas[1].ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(stream);

                traktMetadatas.Should().NotBeNull();
                ITraktMetadata[] metadatas = traktMetadatas.ToArray();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().BeNull();
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
                metadatas[0].ThreeDimensional.Should().BeTrue();

                metadatas[1].Should().NotBeNull();
                metadatas[1].MediaType.Should().Be(TraktMediaType.Digital);
                metadatas[1].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[1].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
                metadatas[1].ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(stream);

                traktMetadatas.Should().NotBeNull();
                ITraktMetadata[] metadatas = traktMetadatas.ToArray();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().Be(TraktMediaType.Digital);
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
                metadatas[0].ThreeDimensional.Should().BeTrue();

                metadatas[1].Should().NotBeNull();
                metadatas[1].MediaType.Should().BeNull();
                metadatas[1].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[1].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
                metadatas[1].ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(stream);

                traktMetadatas.Should().NotBeNull();
                ITraktMetadata[] metadatas = traktMetadatas.ToArray();

                metadatas[0].Should().NotBeNull();
                metadatas[0].MediaType.Should().BeNull();
                metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
                metadatas[0].ThreeDimensional.Should().BeTrue();

                metadatas[1].Should().NotBeNull();
                metadatas[1].MediaType.Should().BeNull();
                metadatas[1].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                metadatas[1].Audio.Should().Be(TraktMediaAudio.AAC);
                metadatas[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                metadatas[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
                metadatas[1].ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public void Test_MetadataArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();
            Func<Task<IEnumerable<ITraktMetadata>>> traktMetadatas = () => jsonReader.ReadArrayAsync(default(Stream));
            traktMetadatas.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(stream);
                traktMetadatas.Should().BeNull();
            }
        }
    }
}
