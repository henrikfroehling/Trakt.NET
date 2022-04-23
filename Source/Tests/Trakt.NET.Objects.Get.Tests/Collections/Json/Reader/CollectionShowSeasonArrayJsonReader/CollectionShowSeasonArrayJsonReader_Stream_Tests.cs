﻿namespace TraktNet.Objects.Get.Tests.Collections.Json.Reader
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
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionShowSeasonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShowSeason>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShowSeasons.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShowSeason>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(stream);
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
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShowSeason>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(stream);
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
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShowSeason>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(stream);
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
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShowSeason>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(stream);
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
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShowSeason>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(stream);
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
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShowSeason>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktCollectionShowSeasons = await jsonReader.ReadArrayAsync(stream);
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
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShowSeason>();
            Func<Task<IEnumerable<ITraktCollectionShowSeason>>> traktEpisodeCollectionProgress = () => jsonReader.ReadArrayAsync(default(Stream));
            await traktEpisodeCollectionProgress.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionShowSeason>();

            using (var stream = string.Empty.ToStream())
            {
                var traktEpisodeCollectionProgress = await jsonReader.ReadArrayAsync(stream);
                traktEpisodeCollectionProgress.Should().BeNull();
            }
        }
    }
}
