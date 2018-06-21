namespace TraktNet.Tests.Objects.Get.Movies.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MovieAliasObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new MovieAliasObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovieAlias.CountryCode.Should().Be("us");
            }
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new MovieAliasObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovieAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new MovieAliasObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().BeNull();
                traktMovieAlias.CountryCode.Should().Be("us");
            }
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new MovieAliasObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().BeNull();
                traktMovieAlias.CountryCode.Should().Be("us");
            }
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new MovieAliasObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovieAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new MovieAliasObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().BeNull();
                traktMovieAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new MovieAliasObjectJsonReader();

            var traktMovieAlias = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktMovieAlias.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieAliasObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new MovieAliasObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(stream);
                traktMovieAlias.Should().BeNull();
            }
        }
    }
}
