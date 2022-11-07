namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class GenreArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();
            IEnumerable<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktGenres.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();
            IEnumerable<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktGenres.Should().NotBeNull();
            ITraktGenre[] genres = traktGenres.ToArray();

            genres[0].Should().NotBeNull();
            genres[0].Name.Should().Be("Action");
            genres[0].Slug.Should().Be("action");
            genres[0].Type.Should().BeNull();

            genres[1].Should().NotBeNull();
            genres[1].Name.Should().Be("Action");
            genres[1].Slug.Should().Be("action");
            genres[1].Type.Should().BeNull();
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();
            IEnumerable<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktGenres.Should().NotBeNull();
            ITraktGenre[] genres = traktGenres.ToArray();

            genres[0].Should().NotBeNull();
            genres[0].Name.Should().Be("Action");
            genres[0].Slug.Should().Be("action");
            genres[0].Type.Should().BeNull();

            genres[1].Should().NotBeNull();
            genres[1].Name.Should().Be("Action");
            genres[1].Slug.Should().BeNull();
            genres[1].Type.Should().BeNull();
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();
            IEnumerable<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktGenres.Should().NotBeNull();
            ITraktGenre[] genres = traktGenres.ToArray();

            genres[0].Should().NotBeNull();
            genres[0].Name.Should().Be("Action");
            genres[0].Slug.Should().BeNull();
            genres[0].Type.Should().BeNull();

            genres[1].Should().NotBeNull();
            genres[1].Name.Should().Be("Action");
            genres[1].Slug.Should().Be("action");
            genres[1].Type.Should().BeNull();
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();
            IEnumerable<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktGenres.Should().NotBeNull();
            ITraktGenre[] genres = traktGenres.ToArray();

            genres[0].Should().NotBeNull();
            genres[0].Name.Should().BeNull();
            genres[0].Slug.Should().Be("action");
            genres[0].Type.Should().BeNull();

            genres[1].Should().NotBeNull();
            genres[1].Name.Should().Be("Action");
            genres[1].Slug.Should().Be("action");
            genres[1].Type.Should().BeNull();
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();
            IEnumerable<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktGenres.Should().NotBeNull();
            ITraktGenre[] genres = traktGenres.ToArray();

            genres[0].Should().NotBeNull();
            genres[0].Name.Should().Be("Action");
            genres[0].Slug.Should().Be("action");
            genres[0].Type.Should().BeNull();

            genres[1].Should().NotBeNull();
            genres[1].Name.Should().BeNull();
            genres[1].Slug.Should().Be("action");
            genres[1].Type.Should().BeNull();
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();
            IEnumerable<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            traktGenres.Should().NotBeNull();
            ITraktGenre[] genres = traktGenres.ToArray();

            genres[0].Should().NotBeNull();
            genres[0].Name.Should().BeNull();
            genres[0].Slug.Should().Be("action");
            genres[0].Type.Should().BeNull();

            genres[1].Should().NotBeNull();
            genres[1].Name.Should().BeNull();
            genres[1].Slug.Should().Be("action");
            genres[1].Type.Should().BeNull();
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();
            Func<Task<IEnumerable<ITraktGenre>>> traktGenres = () => jsonReader.ReadArrayAsync(default(string));
            await traktGenres.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();
            IEnumerable<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(string.Empty);
            traktGenres.Should().BeNull();
        }
    }
}
