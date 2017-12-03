namespace TraktApiSharp.Tests.Objects.Get.Collections.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Collections.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CollectionMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionMovie.Should().NotBeNull();
                traktCollectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktCollectionMovie.Movie.Should().NotBeNull();
                traktCollectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktCollectionMovie.Movie.Year.Should().Be(2015);
                traktCollectionMovie.Movie.Ids.Should().NotBeNull();
                traktCollectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktCollectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktCollectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktCollectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);

                traktCollectionMovie.Metadata.Should().NotBeNull();
                traktCollectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                traktCollectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                traktCollectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                traktCollectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                traktCollectionMovie.Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CollectionMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionMovie.Should().NotBeNull();
                traktCollectionMovie.CollectedAt.Should().BeNull();

                traktCollectionMovie.Movie.Should().NotBeNull();
                traktCollectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktCollectionMovie.Movie.Year.Should().Be(2015);
                traktCollectionMovie.Movie.Ids.Should().NotBeNull();
                traktCollectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktCollectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktCollectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktCollectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);

                traktCollectionMovie.Metadata.Should().NotBeNull();
                traktCollectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                traktCollectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                traktCollectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                traktCollectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                traktCollectionMovie.Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CollectionMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionMovie.Should().NotBeNull();
                traktCollectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktCollectionMovie.Movie.Should().BeNull();

                traktCollectionMovie.Metadata.Should().NotBeNull();
                traktCollectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                traktCollectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                traktCollectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                traktCollectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                traktCollectionMovie.Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new CollectionMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionMovie.Should().NotBeNull();
                traktCollectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktCollectionMovie.Movie.Should().NotBeNull();
                traktCollectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktCollectionMovie.Movie.Year.Should().Be(2015);
                traktCollectionMovie.Movie.Ids.Should().NotBeNull();
                traktCollectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktCollectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktCollectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktCollectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);

                traktCollectionMovie.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new CollectionMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionMovie.Should().NotBeNull();
                traktCollectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktCollectionMovie.Movie.Should().BeNull();
                traktCollectionMovie.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new CollectionMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionMovie.Should().NotBeNull();
                traktCollectionMovie.CollectedAt.Should().BeNull();

                traktCollectionMovie.Movie.Should().NotBeNull();
                traktCollectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktCollectionMovie.Movie.Year.Should().Be(2015);
                traktCollectionMovie.Movie.Ids.Should().NotBeNull();
                traktCollectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktCollectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktCollectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktCollectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);

                traktCollectionMovie.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new CollectionMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionMovie.Should().NotBeNull();
                traktCollectionMovie.CollectedAt.Should().BeNull();
                traktCollectionMovie.Movie.Should().BeNull();

                traktCollectionMovie.Metadata.Should().NotBeNull();
                traktCollectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                traktCollectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                traktCollectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                traktCollectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                traktCollectionMovie.Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CollectionMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionMovie.Should().NotBeNull();
                traktCollectionMovie.CollectedAt.Should().BeNull();

                traktCollectionMovie.Movie.Should().NotBeNull();
                traktCollectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktCollectionMovie.Movie.Year.Should().Be(2015);
                traktCollectionMovie.Movie.Ids.Should().NotBeNull();
                traktCollectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktCollectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktCollectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktCollectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);

                traktCollectionMovie.Metadata.Should().NotBeNull();
                traktCollectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                traktCollectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                traktCollectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                traktCollectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                traktCollectionMovie.Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CollectionMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionMovie.Should().NotBeNull();
                traktCollectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktCollectionMovie.Movie.Should().BeNull();

                traktCollectionMovie.Metadata.Should().NotBeNull();
                traktCollectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                traktCollectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                traktCollectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                traktCollectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                traktCollectionMovie.Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CollectionMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionMovie.Should().NotBeNull();
                traktCollectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                traktCollectionMovie.Movie.Should().NotBeNull();
                traktCollectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktCollectionMovie.Movie.Year.Should().Be(2015);
                traktCollectionMovie.Movie.Ids.Should().NotBeNull();
                traktCollectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktCollectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktCollectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktCollectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);

                traktCollectionMovie.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new CollectionMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktCollectionMovie.Should().NotBeNull();
                traktCollectionMovie.CollectedAt.Should().BeNull();
                traktCollectionMovie.Movie.Should().BeNull();
                traktCollectionMovie.Metadata.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktCollectionMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CollectionMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCollectionMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktCollectionMovie.Should().BeNull();
            }
        }
    }
}
