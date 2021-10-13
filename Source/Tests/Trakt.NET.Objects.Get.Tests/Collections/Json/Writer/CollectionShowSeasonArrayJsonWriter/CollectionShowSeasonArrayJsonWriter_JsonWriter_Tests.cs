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
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Collections.JsonWriter")]
    public partial class CollectionShowSeasonArrayJsonWriter_Tests
    {
        private readonly DateTime COLLECTED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShowSeason>();
            IEnumerable<ITraktCollectionShowSeason> traktCollectionShowSeasons = new List<TraktCollectionShowSeason>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktCollectionShowSeasons);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktCollectionShowSeason> traktCollectionShowSeasons = new List<TraktCollectionShowSeason>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShowSeason>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCollectionShowSeasons);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShowSeason>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCollectionShowSeasons);
                stringWriter.ToString().Should().Be(@"[{""number"":1,""episodes"":[{""number"":1," +
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

        [Fact]
        public async Task Test_CollectionShowSeasonArrayJsonWriter_WriteArray_JsonWriter_Complete()
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

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShowSeason>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCollectionShowSeasons);
                stringWriter.ToString().Should().Be(@"[{""number"":1,""episodes"":[{""number"":1," +
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
}
