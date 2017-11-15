namespace TraktApiSharp.Tests.Objects.Get.Collections.Json
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Collections.Json;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionShowSeasonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CollectionShowSeasonObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new CollectionShowSeasonObjectJsonReader();

            var traktCollectionShowSeason = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktCollectionShowSeason.Should().NotBeNull();
            traktCollectionShowSeason.Number.Should().Be(1);

            traktCollectionShowSeason.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var traktCollectionShowSeasonEpisodes = traktCollectionShowSeason.Episodes.ToArray();

            traktCollectionShowSeasonEpisodes[0].Number.Should().Be(1);
            traktCollectionShowSeasonEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            traktCollectionShowSeasonEpisodes[0].Metadata.Should().NotBeNull();
            traktCollectionShowSeasonEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktCollectionShowSeasonEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktCollectionShowSeasonEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktCollectionShowSeasonEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktCollectionShowSeasonEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

            traktCollectionShowSeasonEpisodes[1].Number.Should().Be(2);
            traktCollectionShowSeasonEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
            traktCollectionShowSeasonEpisodes[1].Metadata.Should().NotBeNull();
            traktCollectionShowSeasonEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktCollectionShowSeasonEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktCollectionShowSeasonEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktCollectionShowSeasonEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktCollectionShowSeasonEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CollectionShowSeasonObjectJsonReader();

            var traktCollectionShowSeason = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktCollectionShowSeason.Should().NotBeNull();
            traktCollectionShowSeason.Number.Should().BeNull();

            traktCollectionShowSeason.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var traktCollectionShowSeasonEpisodes = traktCollectionShowSeason.Episodes.ToArray();

            traktCollectionShowSeasonEpisodes[0].Number.Should().Be(1);
            traktCollectionShowSeasonEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            traktCollectionShowSeasonEpisodes[0].Metadata.Should().NotBeNull();
            traktCollectionShowSeasonEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktCollectionShowSeasonEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktCollectionShowSeasonEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktCollectionShowSeasonEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktCollectionShowSeasonEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

            traktCollectionShowSeasonEpisodes[1].Number.Should().Be(2);
            traktCollectionShowSeasonEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
            traktCollectionShowSeasonEpisodes[1].Metadata.Should().NotBeNull();
            traktCollectionShowSeasonEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktCollectionShowSeasonEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktCollectionShowSeasonEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktCollectionShowSeasonEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktCollectionShowSeasonEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CollectionShowSeasonObjectJsonReader();

            var traktCollectionShowSeason = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktCollectionShowSeason.Should().NotBeNull();
            traktCollectionShowSeason.Number.Should().Be(1);

            traktCollectionShowSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CollectionShowSeasonObjectJsonReader();

            var traktCollectionShowSeason = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktCollectionShowSeason.Should().NotBeNull();
            traktCollectionShowSeason.Number.Should().BeNull();

            traktCollectionShowSeason.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var traktCollectionShowSeasonEpisodes = traktCollectionShowSeason.Episodes.ToArray();

            traktCollectionShowSeasonEpisodes[0].Number.Should().Be(1);
            traktCollectionShowSeasonEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            traktCollectionShowSeasonEpisodes[0].Metadata.Should().NotBeNull();
            traktCollectionShowSeasonEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktCollectionShowSeasonEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktCollectionShowSeasonEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktCollectionShowSeasonEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktCollectionShowSeasonEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

            traktCollectionShowSeasonEpisodes[1].Number.Should().Be(2);
            traktCollectionShowSeasonEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
            traktCollectionShowSeasonEpisodes[1].Metadata.Should().NotBeNull();
            traktCollectionShowSeasonEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            traktCollectionShowSeasonEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            traktCollectionShowSeasonEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            traktCollectionShowSeasonEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            traktCollectionShowSeasonEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CollectionShowSeasonObjectJsonReader();

            var traktCollectionShowSeason = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktCollectionShowSeason.Should().NotBeNull();
            traktCollectionShowSeason.Number.Should().Be(1);

            traktCollectionShowSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CollectionShowSeasonObjectJsonReader();

            var traktCollectionShowSeason = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktCollectionShowSeason.Should().NotBeNull();
            traktCollectionShowSeason.Number.Should().BeNull();
            traktCollectionShowSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new CollectionShowSeasonObjectJsonReader();

            var traktCollectionShowSeason = await jsonReader.ReadObjectAsync(default(string));
            traktCollectionShowSeason.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new CollectionShowSeasonObjectJsonReader();

            var traktCollectionShowSeason = await jsonReader.ReadObjectAsync(string.Empty);
            traktCollectionShowSeason.Should().BeNull();
        }
    }
}
