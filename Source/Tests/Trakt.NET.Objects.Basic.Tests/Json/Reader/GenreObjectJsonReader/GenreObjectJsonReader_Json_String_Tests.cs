namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class GenreObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_GenreObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new GenreObjectJsonReader();

            var traktGenre = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktGenre.Should().NotBeNull();
            traktGenre.Name.Should().Be("Action");
            traktGenre.Slug.Should().Be("action");
            traktGenre.Type.Should().BeNull();
        }

        [Fact]
        public async Task Test_GenreObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new GenreObjectJsonReader();

            var traktGenre = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktGenre.Should().NotBeNull();
            traktGenre.Name.Should().Be("Action");
            traktGenre.Slug.Should().BeNull();
            traktGenre.Type.Should().BeNull();
        }

        [Fact]
        public async Task Test_GenreObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new GenreObjectJsonReader();

            var traktGenre = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktGenre.Should().NotBeNull();
            traktGenre.Name.Should().BeNull();
            traktGenre.Slug.Should().Be("action");
            traktGenre.Type.Should().BeNull();
        }

        [Fact]
        public async Task Test_GenreObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new GenreObjectJsonReader();

            var traktGenre = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktGenre.Should().NotBeNull();
            traktGenre.Name.Should().Be("Action");
            traktGenre.Slug.Should().BeNull();
            traktGenre.Type.Should().BeNull();
        }

        [Fact]
        public async Task Test_GenreObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new GenreObjectJsonReader();

            var traktGenre = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktGenre.Should().NotBeNull();
            traktGenre.Name.Should().BeNull();
            traktGenre.Slug.Should().Be("action");
            traktGenre.Type.Should().BeNull();
        }

        [Fact]
        public async Task Test_GenreObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new GenreObjectJsonReader();

            var traktGenre = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktGenre.Should().NotBeNull();
            traktGenre.Name.Should().BeNull();
            traktGenre.Slug.Should().BeNull();
            traktGenre.Type.Should().BeNull();
        }

        [Fact]
        public async Task Test_GenreObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new GenreObjectJsonReader();

            var traktGenre = await jsonReader.ReadObjectAsync(default(string));
            traktGenre.Should().BeNull();
        }

        [Fact]
        public async Task Test_GenreObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new GenreObjectJsonReader();

            var traktGenre = await jsonReader.ReadObjectAsync(string.Empty);
            traktGenre.Should().BeNull();
        }
    }
}
