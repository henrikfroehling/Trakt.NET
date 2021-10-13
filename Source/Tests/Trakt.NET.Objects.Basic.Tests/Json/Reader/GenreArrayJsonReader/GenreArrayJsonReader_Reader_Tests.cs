namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class GenreArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktGenre> traktGenres = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktGenres.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktGenre> traktGenres = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktGenre> traktGenres = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktGenre> traktGenres = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktGenre> traktGenres = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktGenre> traktGenres = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktGenre> traktGenres = await traktJsonReader.ReadArrayAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktGenre>();
            Func<Task<IEnumerable<ITraktGenre>>> traktGenres = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            await traktGenres.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktGenre> traktGenres = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktGenres.Should().BeNull();
            }
        }
    }
}
