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
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Collections.JsonWriter")]
    public partial class CollectionShowArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CollectionShowArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShow>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CollectionShowArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktCollectionShow> traktCollectionShows = new List<TraktCollectionShow>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShow>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCollectionShows);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_CollectionShowArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktCollectionShow> traktCollectionShows = new List<ITraktCollectionShow>
            {
                new TraktCollectionShow
                {
                    LastCollectedAt = LAST_COLLECTED_AT,
                    LastUpdatedAt = LAST_UPDATED_AT,
                    Show = new TraktShow
                    {
                        Title = "Game of Thrones",
                        Year = 2011,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1390U,
                            Slug = "game-of-thrones",
                            Tvdb = 121361U,
                            Imdb = "tt0944947",
                            Tmdb = 1399U,
                            TvRage = 24493U
                        }
                    },
                    CollectionSeasons = new List<ITraktCollectionShowSeason>
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
                                    Number = 2,
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
                            Number = 2,
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
                                    Number = 2,
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
                    }
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShow>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCollectionShows);
            json.Should().Be($"[{{\"last_collected_at\":\"{LAST_COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"last_updated_at\":\"{LAST_UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                             @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones""," +
                             @"""tvdb"":121361,""imdb"":""tt0944947""," +
                             @"""tmdb"":1399,""tvrage"":24493}}," +
                             @"""seasons"":[{""number"":1,""episodes"":[{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital"",""resolution"":""hd_720p""," +
                             @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}," +
                             @"{""number"":2," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital"",""resolution"":""hd_720p""," +
                             @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}]}," +
                             @"{""number"":2,""episodes"":[{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital"",""resolution"":""hd_720p""," +
                             @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}," +
                             @"{""number"":2," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital"",""resolution"":""hd_720p""," +
                             @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}]}]}]");
        }

        [Fact]
        public async Task Test_CollectionShowArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktCollectionShow> traktCollectionShows = new List<ITraktCollectionShow>
            {
                new TraktCollectionShow
                {
                    LastCollectedAt = LAST_COLLECTED_AT,
                    LastUpdatedAt = LAST_UPDATED_AT,
                    Show = new TraktShow
                    {
                        Title = "Game of Thrones",
                        Year = 2011,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1390U,
                            Slug = "game-of-thrones",
                            Tvdb = 121361U,
                            Imdb = "tt0944947",
                            Tmdb = 1399U,
                            TvRage = 24493U
                        }
                    },
                    CollectionSeasons = new List<ITraktCollectionShowSeason>
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
                                    Number = 2,
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
                            Number = 2,
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
                                    Number = 2,
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
                    }
                },
                new TraktCollectionShow
                {
                    LastCollectedAt = LAST_COLLECTED_AT,
                    LastUpdatedAt = LAST_UPDATED_AT,
                    Show = new TraktShow
                    {
                        Title = "Game of Thrones",
                        Year = 2011,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1390U,
                            Slug = "game-of-thrones",
                            Tvdb = 121361U,
                            Imdb = "tt0944947",
                            Tmdb = 1399U,
                            TvRage = 24493U
                        }
                    },
                    CollectionSeasons = new List<ITraktCollectionShowSeason>
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
                                    Number = 2,
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
                            Number = 2,
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
                                    Number = 2,
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
                    }
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShow>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCollectionShows);
            json.Should().Be($"[{{\"last_collected_at\":\"{LAST_COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"last_updated_at\":\"{LAST_UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                             @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones""," +
                             @"""tvdb"":121361,""imdb"":""tt0944947""," +
                             @"""tmdb"":1399,""tvrage"":24493}}," +
                             @"""seasons"":[{""number"":1,""episodes"":[{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital"",""resolution"":""hd_720p""," +
                             @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}," +
                             @"{""number"":2," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital"",""resolution"":""hd_720p""," +
                             @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}]}," +
                             @"{""number"":2,""episodes"":[{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital"",""resolution"":""hd_720p""," +
                             @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}," +
                             @"{""number"":2," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital"",""resolution"":""hd_720p""," +
                             @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}]}]}," +
                             $"{{\"last_collected_at\":\"{LAST_COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"last_updated_at\":\"{LAST_UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""show"":{""title"":""Game of Thrones"",""year"":2011," +
                             @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones""," +
                             @"""tvdb"":121361,""imdb"":""tt0944947""," +
                             @"""tmdb"":1399,""tvrage"":24493}}," +
                             @"""seasons"":[{""number"":1,""episodes"":[{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital"",""resolution"":""hd_720p""," +
                             @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}," +
                             @"{""number"":2," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital"",""resolution"":""hd_720p""," +
                             @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}]}," +
                             @"{""number"":2,""episodes"":[{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital"",""resolution"":""hd_720p""," +
                             @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}," +
                             @"{""number"":2," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital"",""resolution"":""hd_720p""," +
                             @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}]}]}]");
        }
    }
}
