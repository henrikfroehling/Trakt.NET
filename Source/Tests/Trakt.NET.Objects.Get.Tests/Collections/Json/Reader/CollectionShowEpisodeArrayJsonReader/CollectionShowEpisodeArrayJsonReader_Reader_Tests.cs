namespace TraktNet.Objects.Get.Tests.Collections.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Collections.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionShowEpisodeArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktCollectionShowEpisodes.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            var traktEpisodeCollectionProgress = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktEpisodeCollectionProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new CollectionShowEpisodeArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeCollectionProgress.Should().BeNull();
            }
        }
    }
}
