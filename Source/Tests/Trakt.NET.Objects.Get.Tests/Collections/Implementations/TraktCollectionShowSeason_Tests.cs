namespace TraktNet.Objects.Get.Tests.Collections.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Objects.Get.Collections.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Collections.Implementations")]
    public class TraktCollectionShowSeason_Tests
    {
        [Fact]
        public void Test_TraktCollectionShowSeason_Default_Constructor()
        {
            var collectionShowEpisode = new TraktCollectionShowSeason();

            collectionShowEpisode.Number.Should().BeNull();
            collectionShowEpisode.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCollectionShowSeason_From_Json()
        {
            var jsonReader = new CollectionShowSeasonObjectJsonReader();
            var collectionShowSeason = await jsonReader.ReadObjectAsync(JSON) as TraktCollectionShowSeason;

            collectionShowSeason.Should().NotBeNull();
            collectionShowSeason.Number.Should().Be(1);

            collectionShowSeason.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var collectionShowSeasonEpisodes = collectionShowSeason.Episodes.ToArray();

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

        private const string JSON =
            @"{
                ""number"": 1,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""collected_at"": ""2014-07-14T01:00:00.000Z"",
                    ""metadata"": {
                      ""media_type"": ""digital"",
                      ""resolution"": ""hd_720p"",
                      ""audio"": ""aac"",
                      ""audio_channels"": ""5.1"",
                      ""3d"": true
                    }
                  },
                  {
                    ""number"": 2,
                    ""collected_at"": ""2014-07-15T01:00:00.000Z"",
                    ""metadata"": {
                      ""media_type"": ""digital"",
                      ""resolution"": ""hd_720p"",
                      ""audio"": ""aac"",
                      ""audio_channels"": ""5.1"",
                      ""3d"": false
                    }
                  }
                ]
              }";
    }
}
