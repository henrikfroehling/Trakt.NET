namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class ITraktCollectionShowEpisodeArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktCollectionShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShowEpisodes.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktCollectionShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionShowEpisodes = traktCollectionShowEpisodes.ToArray();

                collectionShowEpisodes[0].Should().NotBeNull();
                collectionShowEpisodes[0].Number.Should().Be(1);
                collectionShowEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[0].Metadata.Should().NotBeNull();
                collectionShowEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

                collectionShowEpisodes[1].Should().NotBeNull();
                collectionShowEpisodes[1].Number.Should().Be(2);
                collectionShowEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[1].Metadata.Should().NotBeNull();
                collectionShowEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

                collectionShowEpisodes[2].Should().NotBeNull();
                collectionShowEpisodes[2].Number.Should().Be(3);
                collectionShowEpisodes[2].CollectedAt.Should().Be(DateTime.Parse("2014-07-16T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[2].Metadata.Should().NotBeNull();
                collectionShowEpisodes[2].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[2].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[2].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[2].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[2].Metadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktCollectionShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionShowEpisodes = traktCollectionShowEpisodes.ToArray();

                collectionShowEpisodes[0].Should().NotBeNull();
                collectionShowEpisodes[0].Number.Should().BeNull();
                collectionShowEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[0].Metadata.Should().NotBeNull();
                collectionShowEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

                collectionShowEpisodes[1].Should().NotBeNull();
                collectionShowEpisodes[1].Number.Should().Be(2);
                collectionShowEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[1].Metadata.Should().NotBeNull();
                collectionShowEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

                collectionShowEpisodes[2].Should().NotBeNull();
                collectionShowEpisodes[2].Number.Should().Be(3);
                collectionShowEpisodes[2].CollectedAt.Should().Be(DateTime.Parse("2014-07-16T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[2].Metadata.Should().NotBeNull();
                collectionShowEpisodes[2].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[2].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[2].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[2].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[2].Metadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktCollectionShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionShowEpisodes = traktCollectionShowEpisodes.ToArray();

                collectionShowEpisodes[0].Should().NotBeNull();
                collectionShowEpisodes[0].Number.Should().Be(1);
                collectionShowEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[0].Metadata.Should().NotBeNull();
                collectionShowEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

                collectionShowEpisodes[1].Should().NotBeNull();
                collectionShowEpisodes[1].Number.Should().Be(2);
                collectionShowEpisodes[1].CollectedAt.Should().BeNull();
                collectionShowEpisodes[1].Metadata.Should().NotBeNull();
                collectionShowEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

                collectionShowEpisodes[2].Should().NotBeNull();
                collectionShowEpisodes[2].Number.Should().Be(3);
                collectionShowEpisodes[2].CollectedAt.Should().Be(DateTime.Parse("2014-07-16T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[2].Metadata.Should().NotBeNull();
                collectionShowEpisodes[2].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[2].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[2].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[2].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[2].Metadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Incomplete_3()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktCollectionShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionShowEpisodes = traktCollectionShowEpisodes.ToArray();

                collectionShowEpisodes[0].Should().NotBeNull();
                collectionShowEpisodes[0].Number.Should().Be(1);
                collectionShowEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[0].Metadata.Should().NotBeNull();
                collectionShowEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

                collectionShowEpisodes[1].Should().NotBeNull();
                collectionShowEpisodes[1].Number.Should().Be(2);
                collectionShowEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[1].Metadata.Should().NotBeNull();
                collectionShowEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

                collectionShowEpisodes[2].Should().NotBeNull();
                collectionShowEpisodes[2].Number.Should().Be(3);
                collectionShowEpisodes[2].CollectedAt.Should().Be(DateTime.Parse("2014-07-16T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[2].Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Incomplete_4()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktCollectionShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionShowEpisodes = traktCollectionShowEpisodes.ToArray();

                collectionShowEpisodes[0].Should().NotBeNull();
                collectionShowEpisodes[0].Number.Should().Be(1);
                collectionShowEpisodes[0].CollectedAt.Should().BeNull();
                collectionShowEpisodes[0].Metadata.Should().BeNull();

                collectionShowEpisodes[1].Should().NotBeNull();
                collectionShowEpisodes[1].Number.Should().Be(2);
                collectionShowEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[1].Metadata.Should().NotBeNull();
                collectionShowEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

                collectionShowEpisodes[2].Should().NotBeNull();
                collectionShowEpisodes[2].Number.Should().Be(3);
                collectionShowEpisodes[2].CollectedAt.Should().Be(DateTime.Parse("2014-07-16T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[2].Metadata.Should().NotBeNull();
                collectionShowEpisodes[2].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[2].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[2].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[2].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[2].Metadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Incomplete_5()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktCollectionShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionShowEpisodes = traktCollectionShowEpisodes.ToArray();

                collectionShowEpisodes[0].Should().NotBeNull();
                collectionShowEpisodes[0].Number.Should().Be(1);
                collectionShowEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[0].Metadata.Should().NotBeNull();
                collectionShowEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

                collectionShowEpisodes[1].Should().NotBeNull();
                collectionShowEpisodes[1].Number.Should().BeNull();
                collectionShowEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[1].Metadata.Should().BeNull();

                collectionShowEpisodes[2].Should().NotBeNull();
                collectionShowEpisodes[2].Number.Should().Be(3);
                collectionShowEpisodes[2].CollectedAt.Should().Be(DateTime.Parse("2014-07-16T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[2].Metadata.Should().NotBeNull();
                collectionShowEpisodes[2].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[2].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[2].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[2].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[2].Metadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Incomplete_6()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktCollectionShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionShowEpisodes = traktCollectionShowEpisodes.ToArray();

                collectionShowEpisodes[0].Should().NotBeNull();
                collectionShowEpisodes[0].Number.Should().Be(1);
                collectionShowEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[0].Metadata.Should().NotBeNull();
                collectionShowEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

                collectionShowEpisodes[1].Should().NotBeNull();
                collectionShowEpisodes[1].Number.Should().Be(2);
                collectionShowEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[1].Metadata.Should().NotBeNull();
                collectionShowEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

                collectionShowEpisodes[2].Should().NotBeNull();
                collectionShowEpisodes[2].Number.Should().BeNull();
                collectionShowEpisodes[2].CollectedAt.Should().BeNull();
                collectionShowEpisodes[2].Metadata.Should().NotBeNull();
                collectionShowEpisodes[2].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[2].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[2].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[2].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[2].Metadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktCollectionShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionShowEpisodes = traktCollectionShowEpisodes.ToArray();

                collectionShowEpisodes[0].Should().NotBeNull();
                collectionShowEpisodes[0].Number.Should().BeNull();
                collectionShowEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[0].Metadata.Should().NotBeNull();
                collectionShowEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

                collectionShowEpisodes[1].Should().NotBeNull();
                collectionShowEpisodes[1].Number.Should().Be(2);
                collectionShowEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[1].Metadata.Should().NotBeNull();
                collectionShowEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

                collectionShowEpisodes[2].Should().NotBeNull();
                collectionShowEpisodes[2].Number.Should().Be(3);
                collectionShowEpisodes[2].CollectedAt.Should().Be(DateTime.Parse("2014-07-16T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[2].Metadata.Should().NotBeNull();
                collectionShowEpisodes[2].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[2].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[2].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[2].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[2].Metadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktCollectionShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionShowEpisodes = traktCollectionShowEpisodes.ToArray();

                collectionShowEpisodes[0].Should().NotBeNull();
                collectionShowEpisodes[0].Number.Should().Be(1);
                collectionShowEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[0].Metadata.Should().NotBeNull();
                collectionShowEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

                collectionShowEpisodes[1].Should().NotBeNull();
                collectionShowEpisodes[1].Number.Should().Be(2);
                collectionShowEpisodes[1].CollectedAt.Should().BeNull();
                collectionShowEpisodes[1].Metadata.Should().NotBeNull();
                collectionShowEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

                collectionShowEpisodes[2].Should().NotBeNull();
                collectionShowEpisodes[2].Number.Should().Be(3);
                collectionShowEpisodes[2].CollectedAt.Should().Be(DateTime.Parse("2014-07-16T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[2].Metadata.Should().NotBeNull();
                collectionShowEpisodes[2].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[2].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[2].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[2].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[2].Metadata.ThreeDimensional.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktCollectionShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionShowEpisodes = traktCollectionShowEpisodes.ToArray();

                collectionShowEpisodes[0].Should().NotBeNull();
                collectionShowEpisodes[0].Number.Should().Be(1);
                collectionShowEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[0].Metadata.Should().NotBeNull();
                collectionShowEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

                collectionShowEpisodes[1].Should().NotBeNull();
                collectionShowEpisodes[1].Number.Should().Be(2);
                collectionShowEpisodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-07-15T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[1].Metadata.Should().NotBeNull();
                collectionShowEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

                collectionShowEpisodes[2].Should().NotBeNull();
                collectionShowEpisodes[2].Number.Should().Be(3);
                collectionShowEpisodes[2].CollectedAt.Should().Be(DateTime.Parse("2014-07-16T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[2].Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Not_Valid_4()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktCollectionShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktCollectionShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionShowEpisodes = traktCollectionShowEpisodes.ToArray();

                collectionShowEpisodes[0].Should().NotBeNull();
                collectionShowEpisodes[0].Number.Should().BeNull();
                collectionShowEpisodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[0].Metadata.Should().NotBeNull();
                collectionShowEpisodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[0].Metadata.ThreeDimensional.Should().BeTrue();

                collectionShowEpisodes[1].Should().NotBeNull();
                collectionShowEpisodes[1].Number.Should().Be(2);
                collectionShowEpisodes[1].CollectedAt.Should().BeNull();
                collectionShowEpisodes[1].Metadata.Should().NotBeNull();
                collectionShowEpisodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
                collectionShowEpisodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
                collectionShowEpisodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
                collectionShowEpisodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
                collectionShowEpisodes[1].Metadata.ThreeDimensional.Should().BeFalse();

                collectionShowEpisodes[2].Should().NotBeNull();
                collectionShowEpisodes[2].Number.Should().Be(3);
                collectionShowEpisodes[2].CollectedAt.Should().Be(DateTime.Parse("2014-07-16T01:00:00.000Z").ToUniversalTime());
                collectionShowEpisodes[2].Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            var traktEpisodeCollectionProgress = await jsonReader.ReadArrayAsync(default(Stream));
            traktEpisodeCollectionProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktCollectionShowEpisodeArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ITraktCollectionShowEpisodeArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktEpisodeCollectionProgress = await jsonReader.ReadArrayAsync(stream);
                traktEpisodeCollectionProgress.Should().BeNull();
            }
        }
    }
}
