namespace TraktNet.Objects.Tests.Get.Collections.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Collections.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionShowSeasonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new CollectionShowSeasonArrayJsonReader();

            var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktCollectionShowSeasons.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new CollectionShowSeasonArrayJsonReader();

            var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
            traktCollectionShowSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var collectionShowSeasons = traktCollectionShowSeasons.ToArray();

            collectionShowSeasons[0].Should().NotBeNull();
            collectionShowSeasons[0].Number.Should().Be(1);

            collectionShowSeasons[0].Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var collectionShowSeasonEpisodes = collectionShowSeasons[0].Episodes.ToArray();

            collectionShowSeasonEpisodes[0].Number.Should().Be(1);
            collectionShowSeasonEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[0].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

            collectionShowSeasonEpisodes[1].Number.Should().Be(2);
            collectionShowSeasonEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[1].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

            // -------------------------------------

            collectionShowSeasons[1].Should().NotBeNull();
            collectionShowSeasons[1].Number.Should().Be(2);

            collectionShowSeasons[1].Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            collectionShowSeasonEpisodes = collectionShowSeasons[1].Episodes.ToArray();

            collectionShowSeasonEpisodes[0].Number.Should().Be(1);
            collectionShowSeasonEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[0].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

            collectionShowSeasonEpisodes[1].Number.Should().Be(2);
            collectionShowSeasonEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[1].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CollectionShowSeasonArrayJsonReader();

            var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);
            traktCollectionShowSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var collectionShowSeasons = traktCollectionShowSeasons.ToArray();

            collectionShowSeasons[0].Should().NotBeNull();
            collectionShowSeasons[0].Number.Should().BeNull();

            collectionShowSeasons[0].Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var collectionShowSeasonEpisodes = collectionShowSeasons[0].Episodes.ToArray();

            collectionShowSeasonEpisodes[0].Number.Should().Be(1);
            collectionShowSeasonEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[0].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

            collectionShowSeasonEpisodes[1].Number.Should().Be(2);
            collectionShowSeasonEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[1].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

            // -------------------------------------

            collectionShowSeasons[1].Should().NotBeNull();
            collectionShowSeasons[1].Number.Should().Be(2);

            collectionShowSeasons[1].Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            collectionShowSeasonEpisodes = collectionShowSeasons[1].Episodes.ToArray();

            collectionShowSeasonEpisodes[0].Number.Should().Be(1);
            collectionShowSeasonEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[0].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

            collectionShowSeasonEpisodes[1].Number.Should().Be(2);
            collectionShowSeasonEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[1].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CollectionShowSeasonArrayJsonReader();

            var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);
            traktCollectionShowSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var collectionShowSeasons = traktCollectionShowSeasons.ToArray();

            collectionShowSeasons[0].Should().NotBeNull();
            collectionShowSeasons[0].Number.Should().Be(1);

            collectionShowSeasons[0].Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var collectionShowSeasonEpisodes = collectionShowSeasons[0].Episodes.ToArray();

            collectionShowSeasonEpisodes[0].Number.Should().Be(1);
            collectionShowSeasonEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[0].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

            collectionShowSeasonEpisodes[1].Number.Should().Be(2);
            collectionShowSeasonEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[1].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

            // -------------------------------------

            collectionShowSeasons[1].Should().NotBeNull();
            collectionShowSeasons[1].Number.Should().Be(2);
            collectionShowSeasons[1].Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CollectionShowSeasonArrayJsonReader();

            var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);
            traktCollectionShowSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var collectionShowSeasons = traktCollectionShowSeasons.ToArray();

            collectionShowSeasons[0].Should().NotBeNull();
            collectionShowSeasons[0].Number.Should().BeNull();

            collectionShowSeasons[0].Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var collectionShowSeasonEpisodes = collectionShowSeasons[0].Episodes.ToArray();

            collectionShowSeasonEpisodes[0].Number.Should().Be(1);
            collectionShowSeasonEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[0].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

            collectionShowSeasonEpisodes[1].Number.Should().Be(2);
            collectionShowSeasonEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[1].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

            // -------------------------------------

            collectionShowSeasons[1].Should().NotBeNull();
            collectionShowSeasons[1].Number.Should().Be(2);

            collectionShowSeasons[1].Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            collectionShowSeasonEpisodes = collectionShowSeasons[1].Episodes.ToArray();

            collectionShowSeasonEpisodes[0].Number.Should().Be(1);
            collectionShowSeasonEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[0].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

            collectionShowSeasonEpisodes[1].Number.Should().Be(2);
            collectionShowSeasonEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[1].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CollectionShowSeasonArrayJsonReader();

            var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);
            traktCollectionShowSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var collectionShowSeasons = traktCollectionShowSeasons.ToArray();

            collectionShowSeasons[0].Should().NotBeNull();
            collectionShowSeasons[0].Number.Should().Be(1);

            collectionShowSeasons[0].Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var collectionShowSeasonEpisodes = collectionShowSeasons[0].Episodes.ToArray();

            collectionShowSeasonEpisodes[0].Number.Should().Be(1);
            collectionShowSeasonEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[0].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

            collectionShowSeasonEpisodes[1].Number.Should().Be(2);
            collectionShowSeasonEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[1].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

            // -------------------------------------

            collectionShowSeasons[1].Should().NotBeNull();
            collectionShowSeasons[1].Number.Should().Be(2);
            collectionShowSeasons[1].Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CollectionShowSeasonArrayJsonReader();

            var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);
            traktCollectionShowSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var collectionShowSeasons = traktCollectionShowSeasons.ToArray();

            collectionShowSeasons[0].Should().NotBeNull();
            collectionShowSeasons[0].Number.Should().BeNull();

            collectionShowSeasons[0].Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var collectionShowSeasonEpisodes = collectionShowSeasons[0].Episodes.ToArray();

            collectionShowSeasonEpisodes[0].Number.Should().Be(1);
            collectionShowSeasonEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[0].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

            collectionShowSeasonEpisodes[1].Number.Should().Be(2);
            collectionShowSeasonEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
            collectionShowSeasonEpisodes[1].Metadata.Should().NotBeNull();
            collectionShowSeasonEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowSeasonEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowSeasonEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowSeasonEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowSeasonEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

            // -------------------------------------

            collectionShowSeasons[1].Should().NotBeNull();
            collectionShowSeasons[1].Number.Should().Be(2);
            collectionShowSeasons[1].Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new CollectionShowSeasonArrayJsonReader();

            var traktEpisodeCollectionProgress = await jsonReader.ReadArrayAsync(default(string));
            traktEpisodeCollectionProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new CollectionShowSeasonArrayJsonReader();

            var traktEpisodeCollectionProgress = await jsonReader.ReadArrayAsync(string.Empty);
            traktEpisodeCollectionProgress.Should().BeNull();
        }
    }
}
