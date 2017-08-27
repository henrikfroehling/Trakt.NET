namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionShowEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShowEpisode.Should().NotBeNull();
                traktCollectionShowEpisode.Number.Should().Be(1);
                traktCollectionShowEpisode.CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShowEpisode.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShowEpisode.Should().NotBeNull();
                traktCollectionShowEpisode.Number.Should().Be(1);
                traktCollectionShowEpisode.CollectedAt.Should().BeNull();
                traktCollectionShowEpisode.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShowEpisode.Should().NotBeNull();
                traktCollectionShowEpisode.Number.Should().BeNull();
                traktCollectionShowEpisode.CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShowEpisode.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShowEpisode.Should().NotBeNull();
                traktCollectionShowEpisode.Number.Should().Be(1);
                traktCollectionShowEpisode.CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShowEpisode.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionShowEpisode.Should().NotBeNull();
                traktCollectionShowEpisode.Number.Should().BeNull();
                traktCollectionShowEpisode.CollectedAt.Should().BeNull();
                traktCollectionShowEpisode.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktCollectionShowEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktCollectionShowEpisode.Should().BeNull();
            }
        }
    }
}
