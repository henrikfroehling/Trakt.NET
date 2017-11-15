namespace TraktApiSharp.Tests.Objects.Get.Movies.Json
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies.Json;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MovieIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(94024);
                traktMovieIds.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovieIds.Imdb.Should().Be("tt2488496");
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieIds.Should().NotBeNull();
                traktMovieIds.Trakt.Should().Be(0);
                traktMovieIds.Slug.Should().BeNull();
                traktMovieIds.Imdb.Should().BeNull();
                traktMovieIds.Tmdb.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            var traktMovieIds = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktMovieIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieIdsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new MovieIdsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktMovieIds = await traktJsonReader.ReadObjectAsync(stream);
                traktMovieIds.Should().BeNull();
            }
        }
    }
}
