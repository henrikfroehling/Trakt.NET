namespace TraktNet.Objects.Get.Tests.Movies.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Movies.JsonReader")]
    public partial class MostAnticipatedMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(stream);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().Be(12805);
                traktMostAnticipatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(stream);

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
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(stream);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().Be(12805);
                traktMostAnticipatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(stream);

                traktMostAnticipatedMovie.Should().NotBeNull();
                traktMostAnticipatedMovie.ListCount.Should().BeNull();
                traktMostAnticipatedMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();
            Func<Task<ITraktMostAnticipatedMovie>> traktMostAnticipatedMovie = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await traktMostAnticipatedMovie.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MostAnticipatedMovieObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new MostAnticipatedMovieObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktMostAnticipatedMovie = await traktJsonReader.ReadObjectAsync(stream);
                traktMostAnticipatedMovie.Should().BeNull();
            }
        }
    }
}
