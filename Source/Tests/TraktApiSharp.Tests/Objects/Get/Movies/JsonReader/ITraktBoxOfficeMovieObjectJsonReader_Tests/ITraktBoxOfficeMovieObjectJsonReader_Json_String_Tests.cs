﻿namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class ITraktBoxOfficeMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktBoxOfficeMovie.Should().NotBeNull();
            traktBoxOfficeMovie.Revenue.Should().Be(166007347);
            traktBoxOfficeMovie.Movie.Should().NotBeNull();
            traktBoxOfficeMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktBoxOfficeMovie.Movie.Year.Should().Be(2015);
            traktBoxOfficeMovie.Movie.Ids.Should().NotBeNull();
            traktBoxOfficeMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktBoxOfficeMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktBoxOfficeMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktBoxOfficeMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktBoxOfficeMovie.Should().NotBeNull();
            traktBoxOfficeMovie.Revenue.Should().Be(166007347);
            traktBoxOfficeMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktBoxOfficeMovie.Should().NotBeNull();
            traktBoxOfficeMovie.Revenue.Should().BeNull();
            traktBoxOfficeMovie.Movie.Should().NotBeNull();
            traktBoxOfficeMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktBoxOfficeMovie.Movie.Year.Should().Be(2015);
            traktBoxOfficeMovie.Movie.Ids.Should().NotBeNull();
            traktBoxOfficeMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktBoxOfficeMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktBoxOfficeMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktBoxOfficeMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktBoxOfficeMovie.Should().NotBeNull();
            traktBoxOfficeMovie.Revenue.Should().BeNull();
            traktBoxOfficeMovie.Movie.Should().NotBeNull();
            traktBoxOfficeMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktBoxOfficeMovie.Movie.Year.Should().Be(2015);
            traktBoxOfficeMovie.Movie.Ids.Should().NotBeNull();
            traktBoxOfficeMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktBoxOfficeMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktBoxOfficeMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktBoxOfficeMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktBoxOfficeMovie.Should().NotBeNull();
            traktBoxOfficeMovie.Revenue.Should().Be(166007347);
            traktBoxOfficeMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktBoxOfficeMovie.Should().NotBeNull();
            traktBoxOfficeMovie.Revenue.Should().BeNull();
            traktBoxOfficeMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = await jsonReader.ReadObjectAsync(default(string));
            traktBoxOfficeMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktBoxOfficeMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktBoxOfficeMovieObjectJsonReader();

            var traktBoxOfficeMovie = await jsonReader.ReadObjectAsync(string.Empty);
            traktBoxOfficeMovie.Should().BeNull();
        }
    }
}
