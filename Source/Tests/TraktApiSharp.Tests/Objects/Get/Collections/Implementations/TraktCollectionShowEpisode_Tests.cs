namespace TraktNet.Tests.Objects.Get.Collections.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Objects.Get.Collections.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Collections.Implementations")]
    public class TraktCollectionShowEpisode_Tests
    {
        [Fact]
        public void Test_TraktCollectionShowEpisode_Default_Constructor()
        {
            var collectionShowEpisode = new TraktCollectionShowEpisode();

            collectionShowEpisode.Number.Should().BeNull();
            collectionShowEpisode.CollectedAt.Should().BeNull();
            collectionShowEpisode.Metadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCollectionShowEpisode_From_Json()
        {
            var jsonReader = new CollectionShowEpisodeObjectJsonReader();
            var collectionShowEpisode = await jsonReader.ReadObjectAsync(JSON) as TraktCollectionShowEpisode;

            collectionShowEpisode.Should().NotBeNull();
            collectionShowEpisode.Number.Should().Be(1);
            collectionShowEpisode.CollectedAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z").ToUniversalTime());
            collectionShowEpisode.Metadata.Should().NotBeNull();
            collectionShowEpisode.Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            collectionShowEpisode.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            collectionShowEpisode.Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            collectionShowEpisode.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            collectionShowEpisode.Metadata.ThreeDimensional.Should().BeTrue();
        }

        private const string JSON =
            @"{
                ""number"": 1,
                ""collected_at"": ""2014-07-14T01:00:00.000Z"",
                ""metadata"": {
                  ""media_type"": ""digital"",
                  ""resolution"": ""hd_720p"",
                  ""audio"": ""aac"",
                  ""audio_channels"": ""5.1"",
                  ""3d"": true
                }
              }";
    }
}
