﻿namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class TraktRecentlyUpdatedMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            traktRecentlyUpdatedMovie.Movie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecentlyUpdatedMovie.Movie.Year.Should().Be(2015);
            traktRecentlyUpdatedMovie.Movie.Ids.Should().NotBeNull();
            traktRecentlyUpdatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktRecentlyUpdatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecentlyUpdatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktRecentlyUpdatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_TraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            traktRecentlyUpdatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().BeNull();
            traktRecentlyUpdatedMovie.Movie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecentlyUpdatedMovie.Movie.Year.Should().Be(2015);
            traktRecentlyUpdatedMovie.Movie.Ids.Should().NotBeNull();
            traktRecentlyUpdatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktRecentlyUpdatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecentlyUpdatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktRecentlyUpdatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_TraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().BeNull();
            traktRecentlyUpdatedMovie.Movie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecentlyUpdatedMovie.Movie.Year.Should().Be(2015);
            traktRecentlyUpdatedMovie.Movie.Ids.Should().NotBeNull();
            traktRecentlyUpdatedMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktRecentlyUpdatedMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecentlyUpdatedMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktRecentlyUpdatedMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_TraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            traktRecentlyUpdatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().BeNull();
            traktRecentlyUpdatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = await jsonReader.ReadObjectAsync(default(string));
            traktRecentlyUpdatedMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktRecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = await jsonReader.ReadObjectAsync(string.Empty);
            traktRecentlyUpdatedMovie.Should().BeNull();
        }
    }
}