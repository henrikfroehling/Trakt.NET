namespace TraktNet.Objects.Tests.Get.Movies.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class RecentlyUpdatedMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new RecentlyUpdatedMovieObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktRecentlyUpdatedMovie = await traktJsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new RecentlyUpdatedMovieObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktRecentlyUpdatedMovie = await traktJsonReader.ReadObjectAsync(stream);

                traktRecentlyUpdatedMovie.Should().NotBeNull();
                traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
                traktRecentlyUpdatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new RecentlyUpdatedMovieObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktRecentlyUpdatedMovie = await traktJsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new RecentlyUpdatedMovieObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktRecentlyUpdatedMovie = await traktJsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new RecentlyUpdatedMovieObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktRecentlyUpdatedMovie = await traktJsonReader.ReadObjectAsync(stream);

                traktRecentlyUpdatedMovie.Should().NotBeNull();
                traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
                traktRecentlyUpdatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new RecentlyUpdatedMovieObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktRecentlyUpdatedMovie = await traktJsonReader.ReadObjectAsync(stream);

                traktRecentlyUpdatedMovie.Should().NotBeNull();
                traktRecentlyUpdatedMovie.RecentlyUpdatedAt.Should().BeNull();
                traktRecentlyUpdatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new RecentlyUpdatedMovieObjectJsonReader();

            var traktRecentlyUpdatedMovie = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktRecentlyUpdatedMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedMovieObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new RecentlyUpdatedMovieObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktRecentlyUpdatedMovie = await traktJsonReader.ReadObjectAsync(stream);
                traktRecentlyUpdatedMovie.Should().BeNull();
            }
        }
    }
}
