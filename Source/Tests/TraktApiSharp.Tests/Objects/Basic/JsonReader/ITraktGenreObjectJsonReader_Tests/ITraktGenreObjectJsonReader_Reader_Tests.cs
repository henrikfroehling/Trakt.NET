namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ITraktGenreObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().Be("Action");
                traktGenre.Slug.Should().Be("action");
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().Be("Action");
                traktGenre.Slug.Should().BeNull();
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().BeNull();
                traktGenre.Slug.Should().Be("action");
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().Be("Action");
                traktGenre.Slug.Should().BeNull();
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().BeNull();
                traktGenre.Slug.Should().Be("action");
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().BeNull();
                traktGenre.Slug.Should().BeNull();
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktGenreObjectJsonReader();

            var traktGenre = await jsonReader.ReadObjectAsync(default(JsonTextReader));
            traktGenre.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktGenre.Should().BeNull();
            }
        }
    }
}
