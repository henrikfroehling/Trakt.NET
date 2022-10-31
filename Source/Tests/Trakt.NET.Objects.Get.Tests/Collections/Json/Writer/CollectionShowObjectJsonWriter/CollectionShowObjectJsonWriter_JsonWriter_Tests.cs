namespace TraktNet.Objects.Get.Tests.Collections.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Objects.Get.Collections.Json.Writer;
    using TraktNet.Objects.Get.Shows;
    using Xunit;

    [TestCategory("Objects.Get.Collections.JsonWriter")]
    public partial class CollectionShowObjectJsonWriter_Tests
    {
        private readonly DateTime LAST_COLLECTED_AT = DateTime.UtcNow;
        private readonly DateTime LAST_UPDATED_AT = DateTime.UtcNow;
        private readonly DateTime COLLECTED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_CollectionShowObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new CollectionShowObjectJsonWriter();
            ITraktCollectionShow traktCollectionShow = new TraktCollectionShow();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktCollectionShow);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonWriter_WriteObject_JsonWriter_Only_LastCollectedAt_Property()
        {
            ITraktCollectionShow traktCollectionShow = new TraktCollectionShow
            {
                LastCollectedAt = LAST_COLLECTED_AT
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CollectionShowObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCollectionShow);
                stringWriter.ToString().Should().Be($"{{\"last_collected_at\":\"{LAST_COLLECTED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonWriter_WriteObject_JsonWriter_Only_LastUpdatedAt_Property()
        {
            ITraktCollectionShow traktCollectionShow = new TraktCollectionShow
            {
                LastUpdatedAt = LAST_UPDATED_AT
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CollectionShowObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCollectionShow);
                stringWriter.ToString().Should().Be($"{{\"last_updated_at\":\"{LAST_UPDATED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonWriter_WriteObject_JsonWriter_Only_Show_Property()
        {
            ITraktCollectionShow traktCollectionShow = new TraktCollectionShow
            {
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CollectionShowObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCollectionShow);
                stringWriter.ToString().Should().Be(@"{""show"":{""title"":""Game of Thrones"",""year"":2011," +
                                                    @"""ids"":{""trakt"":1390,""slug"":""game-of-thrones""," +
                                                    @"""tvdb"":121361,""imdb"":""tt0944947""," +
                                                    @"""tmdb"":1399,""tvrage"":24493}}}");
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonWriter_WriteObject_JsonWriter_Only_CollectionSeasons_Property()
        {
            ITraktCollectionShow traktCollectionShow = new TraktCollectionShow
            {
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
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CollectionShowObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCollectionShow);
                stringWriter.ToString().Should().Be(@"{""seasons"":[{""number"":1,""episodes"":[{""number"":1," +
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
                                                    @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}]}]}");
            }
        }

        [Fact]
        public async Task Test_CollectionShowObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktCollectionShow traktCollectionShow = new TraktCollectionShow
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
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CollectionShowObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCollectionShow);
                stringWriter.ToString().Should().Be($"{{\"last_collected_at\":\"{LAST_COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
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
                                                    @"""audio"":""aac"",""audio_channels"":""5.1"",""3d"":true}}]}]}");
            }
        }
    }
}
