namespace TraktNet.Objects.Get.Tests.Collections.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Objects.Get.Collections.Json.Writer;
    using TraktNet.Objects.Get.Movies;
    using Xunit;

    [TestCategory("Objects.Get.Collections.JsonWriter")]
    public partial class CollectionMovieObjectJsonWriter_Tests
    {
        private readonly DateTime COLLECTED_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_CollectionMovieObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new CollectionMovieObjectJsonWriter();
            ITraktCollectionMovie traktCollectionMovie = new TraktCollectionMovie();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktCollectionMovie);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonWriter_WriteObject_JsonWriter_Only_CollectedAt_Property()
        {
            ITraktCollectionMovie traktCollectionMovie = new TraktCollectionMovie
            {
                CollectedAt = COLLECTED_AT
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CollectionMovieObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCollectionMovie);
                stringWriter.ToString().Should().Be($"{{\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonWriter_WriteObject_JsonWriter_Only_Metadata_Property()
        {
            ITraktCollectionMovie traktCollectionMovie = new TraktCollectionMovie
            {
                Metadata = new TraktMetadata
                {
                    MediaType = TraktMediaType.Bluray,
                    MediaResolution = TraktMediaResolution.HD_1080p,
                    Audio = TraktMediaAudio.DTS,
                    AudioChannels = TraktMediaAudioChannel.Channels_6_1,
                    ThreeDimensional = false
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CollectionMovieObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCollectionMovie);
                stringWriter.ToString().Should().Be(@"{""metadata"":{""media_type"":""bluray"",""resolution"":""hd_1080p""," +
                                                    @"""audio"":""dts"",""audio_channels"":""6.1"",""3d"":false}}");
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonWriter_WriteObject_JsonWriter_Only_Movie_Property()
        {
            ITraktCollectionMovie traktCollectionMovie = new TraktCollectionMovie
            {
                Movie = new TraktMovie
                {
                    Title = "Star Wars: The Force Awakens",
                    Year = 2015,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 94024U,
                        Slug = "star-wars-the-force-awakens-2015",
                        Imdb = "tt2488496",
                        Tmdb = 140607U
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CollectionMovieObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCollectionMovie);
                stringWriter.ToString().Should().Be(@"{""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                                                    @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                                                    @"""imdb"":""tt2488496"",""tmdb"":140607}}}");
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktCollectionMovie traktCollectionMovie = new TraktCollectionMovie
            {
                CollectedAt = COLLECTED_AT,
                Metadata = new TraktMetadata
                {
                    MediaType = TraktMediaType.Bluray,
                    MediaResolution = TraktMediaResolution.HD_1080p,
                    Audio = TraktMediaAudio.DTS,
                    AudioChannels = TraktMediaAudioChannel.Channels_6_1,
                    ThreeDimensional = false
                },
                Movie = new TraktMovie
                {
                    Title = "Star Wars: The Force Awakens",
                    Year = 2015,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 94024U,
                        Slug = "star-wars-the-force-awakens-2015",
                        Imdb = "tt2488496",
                        Tmdb = 140607U
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new CollectionMovieObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktCollectionMovie);
                stringWriter.ToString().Should().Be($"{{\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                                                    @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                                                    @"""imdb"":""tt2488496"",""tmdb"":140607}}," +
                                                    @"""metadata"":{""media_type"":""bluray"",""resolution"":""hd_1080p""," +
                                                    @"""audio"":""dts"",""audio_channels"":""6.1"",""3d"":false}}");
            }
        }
    }
}
