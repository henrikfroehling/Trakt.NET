namespace TraktNet.Objects.Get.Tests.Movies.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Movies.JsonReader")]
    public partial class RecentlyUpdatedMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new RecentlyUpdatedMovieObjectJsonReader();

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
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new RecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            traktRecentlyUpdatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new RecentlyUpdatedMovieObjectJsonReader();

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
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new RecentlyUpdatedMovieObjectJsonReader();

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
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new RecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            traktRecentlyUpdatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new RecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktRecentlyUpdatedMovie.Should().NotBeNull();
            traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().BeNull();
            traktRecentlyUpdatedMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new RecentlyUpdatedMovieObjectJsonReader();
            Func<Task<ITraktRecentlyUpdatedMovie>> traktRecentlyUpdatedMovie = () => jsonReader.ReadObjectAsync(default(string));
            await traktRecentlyUpdatedMovie.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new RecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = await jsonReader.ReadObjectAsync(string.Empty);
            traktRecentlyUpdatedMovie.Should().BeNull();
        }
    }
}
