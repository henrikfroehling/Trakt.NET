namespace TraktNet.Objects.Get.Tests.Collections.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Objects.Get.Collections.Json.Writer;
    using TraktNet.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Collections.JsonWriter")]
    public partial class CollectionMovieObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_CollectionMovieObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new CollectionMovieObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonWriter_WriteObject_Object_Only_CollectedAt_Property()
        {
            ITraktCollectionMovie traktCollectionMovie = new TraktCollectionMovie
            {
                CollectedAt = COLLECTED_AT
            };

            var traktJsonWriter = new CollectionMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCollectionMovie);
            json.Should().Be($"{{\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonWriter_WriteObject_Object_Only_Metadata_Property()
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

            var traktJsonWriter = new CollectionMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCollectionMovie);
            json.Should().Be(@"{""metadata"":{""media_type"":""bluray"",""resolution"":""hd_1080p""," +
                             @"""audio"":""dts"",""audio_channels"":""6.1"",""3d"":false}}");
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonWriter_WriteObject_Object_Only_Movie_Property()
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

            var traktJsonWriter = new CollectionMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCollectionMovie);
            json.Should().Be(@"{""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}}}");
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonWriter_WriteObject_Object_Complete()
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

            var traktJsonWriter = new CollectionMovieObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCollectionMovie);
            json.Should().Be($"{{\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""movie"":{""title"":""Star Wars: The Force Awakens"",""year"":2015," +
                             @"""ids"":{""trakt"":94024,""slug"":""star-wars-the-force-awakens-2015""," +
                             @"""imdb"":""tt2488496"",""tmdb"":140607}}," +
                             @"""metadata"":{""media_type"":""bluray"",""resolution"":""hd_1080p""," +
                             @"""audio"":""dts"",""audio_channels"":""6.1"",""3d"":false}}");
        }
    }
}
