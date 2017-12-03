namespace TraktApiSharp.Tests.Objects.Get.Collections.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Collections.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionShowEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktCollectionShowEpisode.Should().NotBeNull();
                traktCollectionShowEpisode.Number.Should().Be(1);
                traktCollectionShowEpisode.CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShowEpisode.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktCollectionShowEpisode.Should().NotBeNull();
                traktCollectionShowEpisode.Number.Should().Be(1);
                traktCollectionShowEpisode.CollectedAt.Should().BeNull();
                traktCollectionShowEpisode.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktCollectionShowEpisode.Should().NotBeNull();
                traktCollectionShowEpisode.Number.Should().BeNull();
                traktCollectionShowEpisode.CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShowEpisode.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktCollectionShowEpisode.Should().NotBeNull();
                traktCollectionShowEpisode.Number.Should().Be(1);
                traktCollectionShowEpisode.CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
                traktCollectionShowEpisode.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktCollectionShowEpisode.Should().NotBeNull();
                traktCollectionShowEpisode.Number.Should().BeNull();
                traktCollectionShowEpisode.CollectedAt.Should().BeNull();
                traktCollectionShowEpisode.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(default(Stream));
            traktCollectionShowEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktCollectionShowEpisode = await jsonReader.ReadObjectAsync(stream);
                traktCollectionShowEpisode.Should().BeNull();
            }
        }
    }
}
