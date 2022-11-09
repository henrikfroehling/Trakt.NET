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

    [TestCategory("Objects.Get.Collections.JsonWriter")]
    public partial class CollectionShowEpisodeArrayJsonWriter_Tests
    {
        private readonly DateTime COLLECTED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_CollectionShowEpisodeArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShowEpisode>();
            IEnumerable<ITraktCollectionShowEpisode> traktCollectionShowEpisodes = new List<TraktCollectionShowEpisode>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktCollectionShowEpisodes);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktCollectionShowEpisode> traktCollectionShowEpisodes = new List<TraktCollectionShowEpisode>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShowEpisode>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCollectionShowEpisodes);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktCollectionShowEpisode> traktCollectionShowEpisodes = new List<ITraktCollectionShowEpisode>
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
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShowEpisode>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCollectionShowEpisodes);
                stringWriter.ToString().Should().Be(@"[{""number"":1," +
                                                    $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""metadata"":{""media_type"":""digital""," +
                                                    @"""resolution"":""hd_720p"",""audio"":""aac""," +
                                                    @"""audio_channels"":""5.1"",""3d"":true}}]");
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeArrayJsonWriter_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktCollectionShowEpisode> traktCollectionShowEpisodes = new List<ITraktCollectionShowEpisode>
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
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionShowEpisode>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCollectionShowEpisodes);
                stringWriter.ToString().Should().Be(@"[{""number"":1," +
                                                    $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""metadata"":{""media_type"":""digital""," +
                                                    @"""resolution"":""hd_720p"",""audio"":""aac""," +
                                                    @"""audio_channels"":""5.1"",""3d"":true}}," +
                                                    @"{""number"":1," +
                                                    $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""metadata"":{""media_type"":""digital""," +
                                                    @"""resolution"":""hd_720p"",""audio"":""aac""," +
                                                    @"""audio_channels"":""5.1"",""3d"":true}}," +
                                                    @"{""number"":1," +
                                                    $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""metadata"":{""media_type"":""digital""," +
                                                    @"""resolution"":""hd_720p"",""audio"":""aac""," +
                                                    @"""audio_channels"":""5.1"",""3d"":true}}]");
            }
        }
    }
}
