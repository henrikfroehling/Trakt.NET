namespace TraktNet.Objects.Get.Tests.Collections.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.Collections.JsonWriter")]
    public partial class CollectionShowSeasonArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShowSeason>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktCollectionShowSeason> traktCollectionShowSeasons = new List<TraktCollectionShowSeason>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShowSeason>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCollectionShowSeasons);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktCollectionShowSeason> traktCollectionShowSeasons = new List<ITraktCollectionShowSeason>
            {
                new TraktCollectionShowSeason
                {
                    Number = 1,
                    Episodes = new List<ITraktCollectionShowEpisode>
                    {
                        new TraktCollectionShowEpisode
                        {
                            Number = 1,
                            CollectedAt = COLLECTED_AT,
                            Metadata = new TraktMetadata
                            {
                                MediaType = TraktMediaType.Digital,
                                MediaResolution = TraktMediaResolution.HD_720p,
                                Audio = TraktMediaAudio.AAC,
                                AudioChannels = TraktMediaAudioChannel.Channels_5_1,
                                ThreeDimensional = true
                            }
                        },
                        new TraktCollectionShowEpisode
                        {
                            Number = 1,
                            CollectedAt = COLLECTED_AT,
                            Metadata = new TraktMetadata
                            {
                                MediaType = TraktMediaType.Digital,
                                MediaResolution = TraktMediaResolution.HD_720p,
                                Audio = TraktMediaAudio.AAC,
                                AudioChannels = TraktMediaAudioChannel.Channels_5_1,
                                ThreeDimensional = true
                            }
                        }
                    }
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShowSeason>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCollectionShowSeasons);
            json.Should().Be(@"[{""number"":1,""episodes"":[{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital""," +
                             @"""resolution"":""hd_720p"",""audio"":""aac""," +
                             @"""audio_channels"":""5.1"",""3d"":true}}," +
                             @"{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital""," +
                             @"""resolution"":""hd_720p"",""audio"":""aac""," +
                             @"""audio_channels"":""5.1"",""3d"":true}}]}]");
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktCollectionShowSeason> traktCollectionShowSeasons = new List<ITraktCollectionShowSeason>
            {
                new TraktCollectionShowSeason
                {
                    Number = 1,
                    Episodes = new List<ITraktCollectionShowEpisode>
                    {
                        new TraktCollectionShowEpisode
                        {
                            Number = 1,
                            CollectedAt = COLLECTED_AT,
                            Metadata = new TraktMetadata
                            {
                                MediaType = TraktMediaType.Digital,
                                MediaResolution = TraktMediaResolution.HD_720p,
                                Audio = TraktMediaAudio.AAC,
                                AudioChannels = TraktMediaAudioChannel.Channels_5_1,
                                ThreeDimensional = true
                            }
                        },
                        new TraktCollectionShowEpisode
                        {
                            Number = 1,
                            CollectedAt = COLLECTED_AT,
                            Metadata = new TraktMetadata
                            {
                                MediaType = TraktMediaType.Digital,
                                MediaResolution = TraktMediaResolution.HD_720p,
                                Audio = TraktMediaAudio.AAC,
                                AudioChannels = TraktMediaAudioChannel.Channels_5_1,
                                ThreeDimensional = true
                            }
                        }
                    }
                },
                new TraktCollectionShowSeason
                {
                    Number = 1,
                    Episodes = new List<ITraktCollectionShowEpisode>
                    {
                        new TraktCollectionShowEpisode
                        {
                            Number = 1,
                            CollectedAt = COLLECTED_AT,
                            Metadata = new TraktMetadata
                            {
                                MediaType = TraktMediaType.Digital,
                                MediaResolution = TraktMediaResolution.HD_720p,
                                Audio = TraktMediaAudio.AAC,
                                AudioChannels = TraktMediaAudioChannel.Channels_5_1,
                                ThreeDimensional = true
                            }
                        },
                        new TraktCollectionShowEpisode
                        {
                            Number = 1,
                            CollectedAt = COLLECTED_AT,
                            Metadata = new TraktMetadata
                            {
                                MediaType = TraktMediaType.Digital,
                                MediaResolution = TraktMediaResolution.HD_720p,
                                Audio = TraktMediaAudio.AAC,
                                AudioChannels = TraktMediaAudioChannel.Channels_5_1,
                                ThreeDimensional = true
                            }
                        }
                    }
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShowSeason>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCollectionShowSeasons);
            json.Should().Be(@"[{""number"":1,""episodes"":[{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital""," +
                             @"""resolution"":""hd_720p"",""audio"":""aac""," +
                             @"""audio_channels"":""5.1"",""3d"":true}}," +
                             @"{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital""," +
                             @"""resolution"":""hd_720p"",""audio"":""aac""," +
                             @"""audio_channels"":""5.1"",""3d"":true}}]}," +
                             @"{""number"":1,""episodes"":[{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital""," +
                             @"""resolution"":""hd_720p"",""audio"":""aac""," +
                             @"""audio_channels"":""5.1"",""3d"":true}}," +
                             @"{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital""," +
                             @"""resolution"":""hd_720p"",""audio"":""aac""," +
                             @"""audio_channels"":""5.1"",""3d"":true}}]}]");
        }
    }
}
