﻿namespace TraktNet.Objects.Get.Tests.Collections.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Objects.Get.Collections.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShow.LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                traktCollectionShow.Show.Should().NotBeNull();
                traktCollectionShow.Show.Title.Should().Be("Game of Thrones");
                traktCollectionShow.Show.Year.Should().Be(2011);
                traktCollectionShow.Show.Ids.Should().NotBeNull();
                traktCollectionShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCollectionShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCollectionShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCollectionShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCollectionShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCollectionShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCollectionShow.CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktCollectionShow.CollectionSeasons.ToArray();

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
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().BeNull();
                traktCollectionShow.LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                traktCollectionShow.Show.Should().NotBeNull();
                traktCollectionShow.Show.Title.Should().Be("Game of Thrones");
                traktCollectionShow.Show.Year.Should().Be(2011);
                traktCollectionShow.Show.Ids.Should().NotBeNull();
                traktCollectionShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCollectionShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCollectionShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCollectionShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCollectionShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCollectionShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCollectionShow.CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktCollectionShow.CollectionSeasons.ToArray();

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
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShow.LastUpdatedAt.Should().BeNull();

                traktCollectionShow.Show.Should().NotBeNull();
                traktCollectionShow.Show.Title.Should().Be("Game of Thrones");
                traktCollectionShow.Show.Year.Should().Be(2011);
                traktCollectionShow.Show.Ids.Should().NotBeNull();
                traktCollectionShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCollectionShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCollectionShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCollectionShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCollectionShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCollectionShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCollectionShow.CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktCollectionShow.CollectionSeasons.ToArray();

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
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShow.LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                traktCollectionShow.Show.Should().BeNull();

                traktCollectionShow.CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktCollectionShow.CollectionSeasons.ToArray();

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
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShow.LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                traktCollectionShow.Show.Should().NotBeNull();
                traktCollectionShow.Show.Title.Should().Be("Game of Thrones");
                traktCollectionShow.Show.Year.Should().Be(2011);
                traktCollectionShow.Show.Ids.Should().NotBeNull();
                traktCollectionShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCollectionShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCollectionShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCollectionShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCollectionShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCollectionShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCollectionShow.CollectionSeasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShow.LastUpdatedAt.Should().BeNull();
                traktCollectionShow.Show.Should().BeNull();
                traktCollectionShow.CollectionSeasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().BeNull();
                traktCollectionShow.LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShow.Show.Should().BeNull();
                traktCollectionShow.CollectionSeasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().BeNull();
                traktCollectionShow.LastUpdatedAt.Should().BeNull();

                traktCollectionShow.Show.Should().NotBeNull();
                traktCollectionShow.Show.Title.Should().Be("Game of Thrones");
                traktCollectionShow.Show.Year.Should().Be(2011);
                traktCollectionShow.Show.Ids.Should().NotBeNull();
                traktCollectionShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCollectionShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCollectionShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCollectionShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCollectionShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCollectionShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCollectionShow.CollectionSeasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().BeNull();
                traktCollectionShow.LastUpdatedAt.Should().BeNull();
                traktCollectionShow.Show.Should().BeNull();

                traktCollectionShow.CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktCollectionShow.CollectionSeasons.ToArray();

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
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().BeNull();
                traktCollectionShow.LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                traktCollectionShow.Show.Should().NotBeNull();
                traktCollectionShow.Show.Title.Should().Be("Game of Thrones");
                traktCollectionShow.Show.Year.Should().Be(2011);
                traktCollectionShow.Show.Ids.Should().NotBeNull();
                traktCollectionShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCollectionShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCollectionShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCollectionShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCollectionShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCollectionShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCollectionShow.CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktCollectionShow.CollectionSeasons.ToArray();

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
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShow.LastUpdatedAt.Should().BeNull();

                traktCollectionShow.Show.Should().NotBeNull();
                traktCollectionShow.Show.Title.Should().Be("Game of Thrones");
                traktCollectionShow.Show.Year.Should().Be(2011);
                traktCollectionShow.Show.Ids.Should().NotBeNull();
                traktCollectionShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCollectionShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCollectionShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCollectionShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCollectionShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCollectionShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCollectionShow.CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktCollectionShow.CollectionSeasons.ToArray();

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
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShow.LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                traktCollectionShow.Show.Should().BeNull();

                traktCollectionShow.CollectionSeasons.Should().NotBeNull().And.HaveCount(2);
                var seasons = traktCollectionShow.CollectionSeasons.ToArray();

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
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShow.LastUpdatedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());

                traktCollectionShow.Show.Should().NotBeNull();
                traktCollectionShow.Show.Title.Should().Be("Game of Thrones");
                traktCollectionShow.Show.Year.Should().Be(2011);
                traktCollectionShow.Show.Ids.Should().NotBeNull();
                traktCollectionShow.Show.Ids.Trakt.Should().Be(1390U);
                traktCollectionShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktCollectionShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktCollectionShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktCollectionShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktCollectionShow.Show.Ids.TvRage.Should().Be(24493U);

                traktCollectionShow.CollectionSeasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShow.Should().NotBeNull();
                traktCollectionShow.LastCollectedAt.Should().BeNull();
                traktCollectionShow.LastUpdatedAt.Should().BeNull();
                traktCollectionShow.Show.Should().BeNull();
                traktCollectionShow.CollectionSeasons.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();
            Func<Task<ITraktCollectionShow>> traktCollectionShow = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktCollectionShow.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CollectionShowObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShow = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktCollectionShow.Should().BeNull();
            }
        }
    }
}
