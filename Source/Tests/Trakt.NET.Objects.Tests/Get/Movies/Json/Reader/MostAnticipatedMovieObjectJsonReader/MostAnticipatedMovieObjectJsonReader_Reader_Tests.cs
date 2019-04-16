﻿namespace TraktNet.Objects.Tests.Get.Movies.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MostAnticipatedMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().Be(12805);
                traktMostAnticipatedMovie.Movie.Should().NotBeNull();
                traktMostAnticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostAnticipatedMovie.Movie.Year.Should().Be(2015);
                traktMostAnticipatedMovie.Movie.Ids.Should().NotBeNull();
                traktMostAnticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostAnticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostAnticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostAnticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().Be(12805);
                traktMostAnticipatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().BeNull();
                traktMostAnticipatedMovie.Movie.Should().NotBeNull();
                traktMostAnticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostAnticipatedMovie.Movie.Year.Should().Be(2015);
                traktMostAnticipatedMovie.Movie.Ids.Should().NotBeNull();
                traktMostAnticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostAnticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostAnticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostAnticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().BeNull();
                traktMostAnticipatedMovie.Movie.Should().NotBeNull();
                traktMostAnticipatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostAnticipatedMovie.Movie.Year.Should().Be(2015);
                traktMostAnticipatedMovie.Movie.Ids.Should().NotBeNull();
                traktMostAnticipatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostAnticipatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostAnticipatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostAnticipatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().Be(12805);
                traktMostAnticipatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().BeNull();
                traktMostAnticipatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktMostAnticipatedMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktMostAnticipatedMovie.Should().BeNull();
            }
        }
    }
}
