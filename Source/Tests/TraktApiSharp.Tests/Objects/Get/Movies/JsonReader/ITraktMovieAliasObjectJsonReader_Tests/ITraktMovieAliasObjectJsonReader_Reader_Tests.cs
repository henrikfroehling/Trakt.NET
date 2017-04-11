namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class ITraktMovieAliasObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovieAlias.CountryCode.Should().Be("us");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovieAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().BeNull();
                traktMovieAlias.CountryCode.Should().Be("us");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().BeNull();
                traktMovieAlias.CountryCode.Should().Be("us");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovieAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovieAlias.Should().NotBeNull();
                traktMovieAlias.Title.Should().BeNull();
                traktMovieAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            var traktMovieAlias = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktMovieAlias.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMovieAliasObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktMovieAliasObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovieAlias = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktMovieAlias.Should().BeNull();
            }
        }
    }
}
