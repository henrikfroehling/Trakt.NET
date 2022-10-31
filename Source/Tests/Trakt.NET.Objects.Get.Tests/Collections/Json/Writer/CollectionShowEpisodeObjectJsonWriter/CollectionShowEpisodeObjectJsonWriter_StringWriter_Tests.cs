namespace TraktNet.Objects.Get.Tests.Collections.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Objects.Get.Collections.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Collections.JsonWriter")]
    public partial class CollectionShowEpisodeObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new CollectionShowEpisodeObjectJsonWriter();
            ITraktCollectionShowEpisode traktCollectionShowEpisode = new TraktCollectionShowEpisode();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktCollectionShowEpisode);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonWriter_WriteObject_StringWriter_Only_Number_Property()
        {
            ITraktCollectionShowEpisode traktCollectionShowEpisode = new TraktCollectionShowEpisode
            {
                Number = 1
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CollectionShowEpisodeObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCollectionShowEpisode);
                json.Should().Be(@"{""number"":1}");
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonWriter_WriteObject_StringWriter_Only_CollectedAt_Property()
        {
            ITraktCollectionShowEpisode traktCollectionShowEpisode = new TraktCollectionShowEpisode
            {
                CollectedAt = COLLECTED_AT
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CollectionShowEpisodeObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCollectionShowEpisode);
                json.Should().Be($"{{\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonWriter_WriteObject_StringWriter_Only_Metadata_Property()
        {
            ITraktCollectionShowEpisode traktCollectionShowEpisode = new TraktCollectionShowEpisode
            {
                Metadata = new TraktMetadata
                {
                    MediaType = TraktMediaType.Digital,
                    MediaResolution = TraktMediaResolution.HD_720p,
                    Audio = TraktMediaAudio.AAC,
                    AudioChannels = TraktMediaAudioChannel.Channels_5_1,
                    ThreeDimensional = true
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CollectionShowEpisodeObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCollectionShowEpisode);
                json.Should().Be(@"{""metadata"":{""media_type"":""digital""," +
                                 @"""resolution"":""hd_720p"",""audio"":""aac""," +
                                 @"""audio_channels"":""5.1"",""3d"":true}}");
            }
        }

        [Fact]
        public async Task Test_CollectionShowEpisodeObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktCollectionShowEpisode traktCollectionShowEpisode = new TraktCollectionShowEpisode
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
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new CollectionShowEpisodeObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktCollectionShowEpisode);
                json.Should().Be(@"{""number"":1," +
                                 $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                                 @"""metadata"":{""media_type"":""digital""," +
                                 @"""resolution"":""hd_720p"",""audio"":""aac""," +
                                 @"""audio_channels"":""5.1"",""3d"":true}}");
            }
        }
    }
}
