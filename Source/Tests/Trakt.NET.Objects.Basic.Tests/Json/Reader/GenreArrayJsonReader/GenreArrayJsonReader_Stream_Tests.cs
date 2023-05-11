namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class GenreArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IList<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(stream);
                traktGenres.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IList<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IList<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IList<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IList<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IList<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IList<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();
            Func<Task<IList<ITraktGenre>>> traktGenres = () => jsonReader.ReadArrayAsync(default(Stream));
            await traktGenres.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_GenreArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktGenre>();

            using (var stream = string.Empty.ToStream())
            {
                IList<ITraktGenre> traktGenres = await jsonReader.ReadArrayAsync(stream);
                traktGenres.Should().BeNull();
            }
        }
    }
}
