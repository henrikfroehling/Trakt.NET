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
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Collections.JsonWriter")]
    public partial class CollectionMovieArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_CollectionMovieArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionMovie>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CollectionMovieArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktCollectionMovie> traktCollectionMovies = new List<TraktCollectionMovie>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionMovie>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCollectionMovies);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_CollectionMovieArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktCollectionMovie> traktCollectionMovies = new List<ITraktCollectionMovie>
            {
                new TraktCollectionMovie
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
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionMovie>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCollectionMovies);
            json.Should().Be($"[{{\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}}," +
                             @"""metadata"":{""media_type"":""bluray"",""resolution"":""hd_1080p""," +
                             @"""audio"":""dts"",""audio_channels"":""6.1"",""3d"":false}}]");
        }

        [Fact]
        public async Task Test_CollectionMovieArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktCollectionMovie> traktCollectionMovies = new List<ITraktCollectionMovie>
            {
                new TraktCollectionMovie
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
                },
                new TraktCollectionMovie
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
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktCollectionMovie>();
            string json = await traktJsonWriter.WriteArrayAsync(traktCollectionMovies);
            json.Should().Be($"[{{\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}}," +
                             @"""metadata"":{""media_type"":""bluray"",""resolution"":""hd_1080p""," +
                             @"""audio"":""dts"",""audio_channels"":""6.1"",""3d"":false}}," +
                             $"{{\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}}," +
                             @"""metadata"":{""media_type"":""bluray"",""resolution"":""hd_1080p""," +
                             @"""audio"":""dts"",""audio_channels"":""6.1"",""3d"":false}}]");
        }
    }
}
