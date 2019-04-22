namespace TraktNet.Objects.Tests.Get.Collections.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Collections.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionShowEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktCollectionShowEpisode.Should().NotBeNull();
            traktCollectionShowEpisode.Number.Should().Be(1);
            traktCollectionShowEpisode.CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            traktCollectionShowEpisode.Metadata.Should().NotBeNull();
            traktCollectionShowEpisode.Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktCollectionShowEpisode.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktCollectionShowEpisode.Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktCollectionShowEpisode.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktCollectionShowEpisode.Metadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktCollectionShowEpisode.Should().NotBeNull();
            traktCollectionShowEpisode.Number.Should().BeNull();
            traktCollectionShowEpisode.CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            traktCollectionShowEpisode.Metadata.Should().NotBeNull();
            traktCollectionShowEpisode.Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktCollectionShowEpisode.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktCollectionShowEpisode.Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktCollectionShowEpisode.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktCollectionShowEpisode.Metadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktCollectionShowEpisode.Should().NotBeNull();
            traktCollectionShowEpisode.Number.Should().Be(1);
            traktCollectionShowEpisode.CollectedAt.Should().BeNull();
            traktCollectionShowEpisode.Metadata.Should().NotBeNull();
            traktCollectionShowEpisode.Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktCollectionShowEpisode.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktCollectionShowEpisode.Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktCollectionShowEpisode.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktCollectionShowEpisode.Metadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktCollectionShowEpisode.Should().NotBeNull();
            traktCollectionShowEpisode.Number.Should().Be(1);
            traktCollectionShowEpisode.CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            traktCollectionShowEpisode.Metadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktCollectionShowEpisode.Should().NotBeNull();
            traktCollectionShowEpisode.Number.Should().Be(1);
            traktCollectionShowEpisode.CollectedAt.Should().BeNull();
            traktCollectionShowEpisode.Metadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktCollectionShowEpisode.Should().NotBeNull();
            traktCollectionShowEpisode.Number.Should().BeNull();
            traktCollectionShowEpisode.CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            traktCollectionShowEpisode.Metadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktCollectionShowEpisode.Should().NotBeNull();
            traktCollectionShowEpisode.Number.Should().BeNull();
            traktCollectionShowEpisode.CollectedAt.Should().BeNull();
            traktCollectionShowEpisode.Metadata.Should().NotBeNull();
            traktCollectionShowEpisode.Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktCollectionShowEpisode.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktCollectionShowEpisode.Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktCollectionShowEpisode.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktCollectionShowEpisode.Metadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktCollectionShowEpisode.Should().NotBeNull();
            traktCollectionShowEpisode.Number.Should().BeNull();
            traktCollectionShowEpisode.CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            traktCollectionShowEpisode.Metadata.Should().NotBeNull();
            traktCollectionShowEpisode.Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktCollectionShowEpisode.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktCollectionShowEpisode.Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktCollectionShowEpisode.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktCollectionShowEpisode.Metadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktCollectionShowEpisode.Should().NotBeNull();
            traktCollectionShowEpisode.Number.Should().Be(1);
            traktCollectionShowEpisode.CollectedAt.Should().BeNull();
            traktCollectionShowEpisode.Metadata.Should().NotBeNull();
            traktCollectionShowEpisode.Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktCollectionShowEpisode.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktCollectionShowEpisode.Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktCollectionShowEpisode.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktCollectionShowEpisode.Metadata.ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktCollectionShowEpisode.Should().NotBeNull();
            traktCollectionShowEpisode.Number.Should().Be(1);
            traktCollectionShowEpisode.CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            traktCollectionShowEpisode.Metadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktCollectionShowEpisode.Should().NotBeNull();
            traktCollectionShowEpisode.Number.Should().BeNull();
            traktCollectionShowEpisode.CollectedAt.Should().BeNull();
            traktCollectionShowEpisode.Metadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(default(string));
            traktCollectionShowEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(string.Empty);
            traktCollectionShowEpisode.Should().BeNull();
        }
    }
}
