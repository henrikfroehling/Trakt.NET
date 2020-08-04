namespace TraktNet.Objects.Get.Tests.Collections.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionShowArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CollectionShowArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShow>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktCollectionShows = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShows.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CollectionShowArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShow>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktCollectionShows = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var collectionShows = traktCollectionShows.ToArray();

                collectionShows[0].Should().NotBeNull();
                collectionShows[0].LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShows[0].LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                collectionShows[0].Show.Should().NotBeNull();
                collectionShows[0].Show.Title.Should().Be("Game of Thrones");
                collectionShows[0].Show.Year.Should().Be(2011);
                collectionShows[0].Show.Ids.Should().NotBeNull();
                collectionShows[0].Show.Ids.Trakt.Should().Be(1390U);
                collectionShows[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                collectionShows[0].Show.Ids.Tvdb.Should().Be(121361U);
                collectionShows[0].Show.Ids.Imdb.Should().Be("tt0944947");
                collectionShows[0].Show.Ids.Tmdb.Should().Be(1399U);
                collectionShows[0].Show.Ids.TvRage.Should().Be(24493U);

                collectionShows[0].CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = collectionShows[0].CollectionSeasons.ToArray();

                // Season 1
                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull();
                seasons[0].Episodes.Should().HaveCount(2);

                // Episodes of Season 1
                var episodesSeason1 = seasons[0].Episodes.ToArray();

                episodesSeason1[0].Should().NotBeNull();
                episodesSeason1[0].Number.Should().Be(1);
                episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason1[1].Should().NotBeNull();
                episodesSeason1[1].Number.Should().Be(2);
                episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // Season 2
                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull();
                seasons[1].Episodes.Should().HaveCount(2);

                // Episodes of Season 2
                var episodesSeason2 = seasons[1].Episodes.ToArray();

                episodesSeason2[0].Should().NotBeNull();
                episodesSeason2[0].Number.Should().Be(1);
                episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason2[1].Should().NotBeNull();
                episodesSeason2[1].Number.Should().Be(2);
                episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // ---------------------------------------------------------------

                collectionShows[1].Should().NotBeNull();
                collectionShows[1].LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShows[1].LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                collectionShows[1].Show.Should().NotBeNull();
                collectionShows[1].Show.Title.Should().Be("Game of Thrones");
                collectionShows[1].Show.Year.Should().Be(2011);
                collectionShows[1].Show.Ids.Should().NotBeNull();
                collectionShows[1].Show.Ids.Trakt.Should().Be(1390U);
                collectionShows[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                collectionShows[1].Show.Ids.Tvdb.Should().Be(121361U);
                collectionShows[1].Show.Ids.Imdb.Should().Be("tt0944947");
                collectionShows[1].Show.Ids.Tmdb.Should().Be(1399U);
                collectionShows[1].Show.Ids.TvRage.Should().Be(24493U);

                collectionShows[1].CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                seasons = collectionShows[1].CollectionSeasons.ToArray();

                // Season 1
                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull();
                seasons[0].Episodes.Should().HaveCount(2);

                // Episodes of Season 1
                episodesSeason1 = seasons[0].Episodes.ToArray();

                episodesSeason1[0].Should().NotBeNull();
                episodesSeason1[0].Number.Should().Be(1);
                episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason1[1].Should().NotBeNull();
                episodesSeason1[1].Number.Should().Be(2);
                episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // Season 2
                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull();
                seasons[1].Episodes.Should().HaveCount(2);

                // Episodes of Season 2
                episodesSeason2 = seasons[1].Episodes.ToArray();

                episodesSeason2[0].Should().NotBeNull();
                episodesSeason2[0].Number.Should().Be(1);
                episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason2[1].Should().NotBeNull();
                episodesSeason2[1].Number.Should().Be(2);
                episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionShowArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShow>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktCollectionShows = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var collectionShows = traktCollectionShows.ToArray();

                collectionShows[0].Should().NotBeNull();
                collectionShows[0].LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShows[0].LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                collectionShows[0].Show.Should().NotBeNull();
                collectionShows[0].Show.Title.Should().Be("Game of Thrones");
                collectionShows[0].Show.Year.Should().Be(2011);
                collectionShows[0].Show.Ids.Should().NotBeNull();
                collectionShows[0].Show.Ids.Trakt.Should().Be(1390U);
                collectionShows[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                collectionShows[0].Show.Ids.Tvdb.Should().Be(121361U);
                collectionShows[0].Show.Ids.Imdb.Should().Be("tt0944947");
                collectionShows[0].Show.Ids.Tmdb.Should().Be(1399U);
                collectionShows[0].Show.Ids.TvRage.Should().Be(24493U);

                collectionShows[0].CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = collectionShows[0].CollectionSeasons.ToArray();

                // Season 1
                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull();
                seasons[0].Episodes.Should().HaveCount(2);

                // Episodes of Season 1
                var episodesSeason1 = seasons[0].Episodes.ToArray();

                episodesSeason1[0].Should().NotBeNull();
                episodesSeason1[0].Number.Should().Be(1);
                episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason1[1].Should().NotBeNull();
                episodesSeason1[1].Number.Should().Be(2);
                episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // Season 2
                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull();
                seasons[1].Episodes.Should().HaveCount(2);

                // Episodes of Season 2
                var episodesSeason2 = seasons[1].Episodes.ToArray();

                episodesSeason2[0].Should().NotBeNull();
                episodesSeason2[0].Number.Should().Be(1);
                episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason2[1].Should().NotBeNull();
                episodesSeason2[1].Number.Should().Be(2);
                episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // ---------------------------------------------------------------

                collectionShows[1].Should().NotBeNull();
                collectionShows[1].LastCollectedAt.Should().BeNull();
                collectionShows[1].LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                collectionShows[1].Show.Should().NotBeNull();
                collectionShows[1].Show.Title.Should().Be("Game of Thrones");
                collectionShows[1].Show.Year.Should().Be(2011);
                collectionShows[1].Show.Ids.Should().NotBeNull();
                collectionShows[1].Show.Ids.Trakt.Should().Be(1390U);
                collectionShows[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                collectionShows[1].Show.Ids.Tvdb.Should().Be(121361U);
                collectionShows[1].Show.Ids.Imdb.Should().Be("tt0944947");
                collectionShows[1].Show.Ids.Tmdb.Should().Be(1399U);
                collectionShows[1].Show.Ids.TvRage.Should().Be(24493U);

                collectionShows[1].CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                seasons = collectionShows[1].CollectionSeasons.ToArray();

                // Season 1
                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull();
                seasons[0].Episodes.Should().HaveCount(2);

                // Episodes of Season 1
                episodesSeason1 = seasons[0].Episodes.ToArray();

                episodesSeason1[0].Should().NotBeNull();
                episodesSeason1[0].Number.Should().Be(1);
                episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason1[1].Should().NotBeNull();
                episodesSeason1[1].Number.Should().Be(2);
                episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // Season 2
                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull();
                seasons[1].Episodes.Should().HaveCount(2);

                // Episodes of Season 2
                episodesSeason2 = seasons[1].Episodes.ToArray();

                episodesSeason2[0].Should().NotBeNull();
                episodesSeason2[0].Number.Should().Be(1);
                episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason2[1].Should().NotBeNull();
                episodesSeason2[1].Number.Should().Be(2);
                episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionShowArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShow>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktCollectionShows = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var collectionShows = traktCollectionShows.ToArray();

                collectionShows[0].Should().NotBeNull();
                collectionShows[0].LastCollectedAt.Should().BeNull();
                collectionShows[0].LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                collectionShows[0].Show.Should().NotBeNull();
                collectionShows[0].Show.Title.Should().Be("Game of Thrones");
                collectionShows[0].Show.Year.Should().Be(2011);
                collectionShows[0].Show.Ids.Should().NotBeNull();
                collectionShows[0].Show.Ids.Trakt.Should().Be(1390U);
                collectionShows[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                collectionShows[0].Show.Ids.Tvdb.Should().Be(121361U);
                collectionShows[0].Show.Ids.Imdb.Should().Be("tt0944947");
                collectionShows[0].Show.Ids.Tmdb.Should().Be(1399U);
                collectionShows[0].Show.Ids.TvRage.Should().Be(24493U);

                collectionShows[0].CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = collectionShows[0].CollectionSeasons.ToArray();

                // Season 1
                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull();
                seasons[0].Episodes.Should().HaveCount(2);

                // Episodes of Season 1
                var episodesSeason1 = seasons[0].Episodes.ToArray();

                episodesSeason1[0].Should().NotBeNull();
                episodesSeason1[0].Number.Should().Be(1);
                episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason1[1].Should().NotBeNull();
                episodesSeason1[1].Number.Should().Be(2);
                episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // Season 2
                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull();
                seasons[1].Episodes.Should().HaveCount(2);

                // Episodes of Season 2
                var episodesSeason2 = seasons[1].Episodes.ToArray();

                episodesSeason2[0].Should().NotBeNull();
                episodesSeason2[0].Number.Should().Be(1);
                episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason2[1].Should().NotBeNull();
                episodesSeason2[1].Number.Should().Be(2);
                episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // ---------------------------------------------------------------

                collectionShows[1].Should().NotBeNull();
                collectionShows[1].LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShows[1].LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                collectionShows[1].Show.Should().NotBeNull();
                collectionShows[1].Show.Title.Should().Be("Game of Thrones");
                collectionShows[1].Show.Year.Should().Be(2011);
                collectionShows[1].Show.Ids.Should().NotBeNull();
                collectionShows[1].Show.Ids.Trakt.Should().Be(1390U);
                collectionShows[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                collectionShows[1].Show.Ids.Tvdb.Should().Be(121361U);
                collectionShows[1].Show.Ids.Imdb.Should().Be("tt0944947");
                collectionShows[1].Show.Ids.Tmdb.Should().Be(1399U);
                collectionShows[1].Show.Ids.TvRage.Should().Be(24493U);

                collectionShows[1].CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                seasons = collectionShows[1].CollectionSeasons.ToArray();

                // Season 1
                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull();
                seasons[0].Episodes.Should().HaveCount(2);

                // Episodes of Season 1
                episodesSeason1 = seasons[0].Episodes.ToArray();

                episodesSeason1[0].Should().NotBeNull();
                episodesSeason1[0].Number.Should().Be(1);
                episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason1[1].Should().NotBeNull();
                episodesSeason1[1].Number.Should().Be(2);
                episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // Season 2
                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull();
                seasons[1].Episodes.Should().HaveCount(2);

                // Episodes of Season 2
                episodesSeason2 = seasons[1].Episodes.ToArray();

                episodesSeason2[0].Should().NotBeNull();
                episodesSeason2[0].Number.Should().Be(1);
                episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason2[1].Should().NotBeNull();
                episodesSeason2[1].Number.Should().Be(2);
                episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionShowArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShow>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktCollectionShows = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var collectionShows = traktCollectionShows.ToArray();

                collectionShows[0].Should().NotBeNull();
                collectionShows[0].LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShows[0].LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                collectionShows[0].Show.Should().NotBeNull();
                collectionShows[0].Show.Title.Should().Be("Game of Thrones");
                collectionShows[0].Show.Year.Should().Be(2011);
                collectionShows[0].Show.Ids.Should().NotBeNull();
                collectionShows[0].Show.Ids.Trakt.Should().Be(1390U);
                collectionShows[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                collectionShows[0].Show.Ids.Tvdb.Should().Be(121361U);
                collectionShows[0].Show.Ids.Imdb.Should().Be("tt0944947");
                collectionShows[0].Show.Ids.Tmdb.Should().Be(1399U);
                collectionShows[0].Show.Ids.TvRage.Should().Be(24493U);

                collectionShows[0].CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = collectionShows[0].CollectionSeasons.ToArray();

                // Season 1
                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull();
                seasons[0].Episodes.Should().HaveCount(2);

                // Episodes of Season 1
                var episodesSeason1 = seasons[0].Episodes.ToArray();

                episodesSeason1[0].Should().NotBeNull();
                episodesSeason1[0].Number.Should().Be(1);
                episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason1[1].Should().NotBeNull();
                episodesSeason1[1].Number.Should().Be(2);
                episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // Season 2
                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull();
                seasons[1].Episodes.Should().HaveCount(2);

                // Episodes of Season 2
                var episodesSeason2 = seasons[1].Episodes.ToArray();

                episodesSeason2[0].Should().NotBeNull();
                episodesSeason2[0].Number.Should().Be(1);
                episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason2[1].Should().NotBeNull();
                episodesSeason2[1].Number.Should().Be(2);
                episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // ---------------------------------------------------------------

                collectionShows[1].Should().NotBeNull();
                collectionShows[1].LastCollectedAt.Should().BeNull();
                collectionShows[1].LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                collectionShows[1].Show.Should().NotBeNull();
                collectionShows[1].Show.Title.Should().Be("Game of Thrones");
                collectionShows[1].Show.Year.Should().Be(2011);
                collectionShows[1].Show.Ids.Should().NotBeNull();
                collectionShows[1].Show.Ids.Trakt.Should().Be(1390U);
                collectionShows[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                collectionShows[1].Show.Ids.Tvdb.Should().Be(121361U);
                collectionShows[1].Show.Ids.Imdb.Should().Be("tt0944947");
                collectionShows[1].Show.Ids.Tmdb.Should().Be(1399U);
                collectionShows[1].Show.Ids.TvRage.Should().Be(24493U);

                collectionShows[1].CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                seasons = collectionShows[1].CollectionSeasons.ToArray();

                // Season 1
                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull();
                seasons[0].Episodes.Should().HaveCount(2);

                // Episodes of Season 1
                episodesSeason1 = seasons[0].Episodes.ToArray();

                episodesSeason1[0].Should().NotBeNull();
                episodesSeason1[0].Number.Should().Be(1);
                episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason1[1].Should().NotBeNull();
                episodesSeason1[1].Number.Should().Be(2);
                episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // Season 2
                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull();
                seasons[1].Episodes.Should().HaveCount(2);

                // Episodes of Season 2
                episodesSeason2 = seasons[1].Episodes.ToArray();

                episodesSeason2[0].Should().NotBeNull();
                episodesSeason2[0].Number.Should().Be(1);
                episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason2[1].Should().NotBeNull();
                episodesSeason2[1].Number.Should().Be(2);
                episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionShowArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShow>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktCollectionShows = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var collectionShows = traktCollectionShows.ToArray();

                collectionShows[0].Should().NotBeNull();
                collectionShows[0].LastCollectedAt.Should().BeNull();
                collectionShows[0].LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                collectionShows[0].Show.Should().NotBeNull();
                collectionShows[0].Show.Title.Should().Be("Game of Thrones");
                collectionShows[0].Show.Year.Should().Be(2011);
                collectionShows[0].Show.Ids.Should().NotBeNull();
                collectionShows[0].Show.Ids.Trakt.Should().Be(1390U);
                collectionShows[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                collectionShows[0].Show.Ids.Tvdb.Should().Be(121361U);
                collectionShows[0].Show.Ids.Imdb.Should().Be("tt0944947");
                collectionShows[0].Show.Ids.Tmdb.Should().Be(1399U);
                collectionShows[0].Show.Ids.TvRage.Should().Be(24493U);

                collectionShows[0].CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = collectionShows[0].CollectionSeasons.ToArray();

                // Season 1
                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull();
                seasons[0].Episodes.Should().HaveCount(2);

                // Episodes of Season 1
                var episodesSeason1 = seasons[0].Episodes.ToArray();

                episodesSeason1[0].Should().NotBeNull();
                episodesSeason1[0].Number.Should().Be(1);
                episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason1[1].Should().NotBeNull();
                episodesSeason1[1].Number.Should().Be(2);
                episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // Season 2
                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull();
                seasons[1].Episodes.Should().HaveCount(2);

                // Episodes of Season 2
                var episodesSeason2 = seasons[1].Episodes.ToArray();

                episodesSeason2[0].Should().NotBeNull();
                episodesSeason2[0].Number.Should().Be(1);
                episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason2[1].Should().NotBeNull();
                episodesSeason2[1].Number.Should().Be(2);
                episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // ---------------------------------------------------------------

                collectionShows[1].Should().NotBeNull();
                collectionShows[1].LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShows[1].LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                collectionShows[1].Show.Should().NotBeNull();
                collectionShows[1].Show.Title.Should().Be("Game of Thrones");
                collectionShows[1].Show.Year.Should().Be(2011);
                collectionShows[1].Show.Ids.Should().NotBeNull();
                collectionShows[1].Show.Ids.Trakt.Should().Be(1390U);
                collectionShows[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                collectionShows[1].Show.Ids.Tvdb.Should().Be(121361U);
                collectionShows[1].Show.Ids.Imdb.Should().Be("tt0944947");
                collectionShows[1].Show.Ids.Tmdb.Should().Be(1399U);
                collectionShows[1].Show.Ids.TvRage.Should().Be(24493U);

                collectionShows[1].CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                seasons = collectionShows[1].CollectionSeasons.ToArray();

                // Season 1
                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull();
                seasons[0].Episodes.Should().HaveCount(2);

                // Episodes of Season 1
                episodesSeason1 = seasons[0].Episodes.ToArray();

                episodesSeason1[0].Should().NotBeNull();
                episodesSeason1[0].Number.Should().Be(1);
                episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason1[1].Should().NotBeNull();
                episodesSeason1[1].Number.Should().Be(2);
                episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // Season 2
                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull();
                seasons[1].Episodes.Should().HaveCount(2);

                // Episodes of Season 2
                episodesSeason2 = seasons[1].Episodes.ToArray();

                episodesSeason2[0].Should().NotBeNull();
                episodesSeason2[0].Number.Should().Be(1);
                episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason2[1].Should().NotBeNull();
                episodesSeason2[1].Number.Should().Be(2);
                episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionShowArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShow>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktCollectionShows = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var collectionShows = traktCollectionShows.ToArray();

                collectionShows[0].Should().NotBeNull();
                collectionShows[0].LastCollectedAt.Should().BeNull();
                collectionShows[0].LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                collectionShows[0].Show.Should().NotBeNull();
                collectionShows[0].Show.Title.Should().Be("Game of Thrones");
                collectionShows[0].Show.Year.Should().Be(2011);
                collectionShows[0].Show.Ids.Should().NotBeNull();
                collectionShows[0].Show.Ids.Trakt.Should().Be(1390U);
                collectionShows[0].Show.Ids.Slug.Should().Be("game-of-thrones");
                collectionShows[0].Show.Ids.Tvdb.Should().Be(121361U);
                collectionShows[0].Show.Ids.Imdb.Should().Be("tt0944947");
                collectionShows[0].Show.Ids.Tmdb.Should().Be(1399U);
                collectionShows[0].Show.Ids.TvRage.Should().Be(24493U);

                collectionShows[0].CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = collectionShows[0].CollectionSeasons.ToArray();

                // Season 1
                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull();
                seasons[0].Episodes.Should().HaveCount(2);

                // Episodes of Season 1
                var episodesSeason1 = seasons[0].Episodes.ToArray();

                episodesSeason1[0].Should().NotBeNull();
                episodesSeason1[0].Number.Should().Be(1);
                episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason1[1].Should().NotBeNull();
                episodesSeason1[1].Number.Should().Be(2);
                episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // Season 2
                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull();
                seasons[1].Episodes.Should().HaveCount(2);

                // Episodes of Season 2
                var episodesSeason2 = seasons[1].Episodes.ToArray();

                episodesSeason2[0].Should().NotBeNull();
                episodesSeason2[0].Number.Should().Be(1);
                episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason2[1].Should().NotBeNull();
                episodesSeason2[1].Number.Should().Be(2);
                episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // ---------------------------------------------------------------

                collectionShows[1].Should().NotBeNull();
                collectionShows[1].LastCollectedAt.Should().BeNull();
                collectionShows[1].LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                collectionShows[1].Show.Should().NotBeNull();
                collectionShows[1].Show.Title.Should().Be("Game of Thrones");
                collectionShows[1].Show.Year.Should().Be(2011);
                collectionShows[1].Show.Ids.Should().NotBeNull();
                collectionShows[1].Show.Ids.Trakt.Should().Be(1390U);
                collectionShows[1].Show.Ids.Slug.Should().Be("game-of-thrones");
                collectionShows[1].Show.Ids.Tvdb.Should().Be(121361U);
                collectionShows[1].Show.Ids.Imdb.Should().Be("tt0944947");
                collectionShows[1].Show.Ids.Tmdb.Should().Be(1399U);
                collectionShows[1].Show.Ids.TvRage.Should().Be(24493U);

                collectionShows[1].CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                seasons = collectionShows[1].CollectionSeasons.ToArray();

                // Season 1
                seasons[0].Should().NotBeNull();
                seasons[0].Number.Should().Be(1);
                seasons[0].Episodes.Should().NotBeNull();
                seasons[0].Episodes.Should().HaveCount(2);

                // Episodes of Season 1
                episodesSeason1 = seasons[0].Episodes.ToArray();

                episodesSeason1[0].Should().NotBeNull();
                episodesSeason1[0].Number.Should().Be(1);
                episodesSeason1[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason1[1].Should().NotBeNull();
                episodesSeason1[1].Number.Should().Be(2);
                episodesSeason1[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();

                // Season 2
                seasons[1].Should().NotBeNull();
                seasons[1].Number.Should().Be(2);
                seasons[1].Episodes.Should().NotBeNull();
                seasons[1].Episodes.Should().HaveCount(2);

                // Episodes of Season 2
                episodesSeason2 = seasons[1].Episodes.ToArray();

                episodesSeason2[0].Should().NotBeNull();
                episodesSeason2[0].Number.Should().Be(1);
                episodesSeason2[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[0].Metadata.Should().NotBeNull();
                episodesSeason1[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[0].Metadata.ThreeDimensional.Should().BeFalse();

                episodesSeason2[1].Should().NotBeNull();
                episodesSeason2[1].Number.Should().Be(2);
                episodesSeason2[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                episodesSeason1[1].Metadata.Should().NotBeNull();
                episodesSeason1[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                episodesSeason1[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                episodesSeason1[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                episodesSeason1[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                episodesSeason1[1].Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionShowArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShow>();
            var traktCollectionShows = await jsonReader.ReadArrayAsync(default(Stream));
            traktCollectionShows.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShow>();

            using (var stream = string.Empty.ToStream())
            {
                var traktCollectionShows = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShows.Should().BeNull();
            }
        }
    }
}
