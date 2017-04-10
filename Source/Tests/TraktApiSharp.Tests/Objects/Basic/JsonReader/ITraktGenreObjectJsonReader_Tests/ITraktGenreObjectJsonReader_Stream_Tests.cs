namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ITraktGenreObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(stream);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().Be("Action");
                traktGenre.Slug.Should().Be("action");
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(stream);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().Be("Action");
                traktGenre.Slug.Should().BeNull();
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(stream);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().BeNull();
                traktGenre.Slug.Should().Be("action");
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(stream);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().Be("Action");
                traktGenre.Slug.Should().BeNull();
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(stream);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().BeNull();
                traktGenre.Slug.Should().Be("action");
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(stream);

                traktGenre.Should().NotBeNull();
                traktGenre.Name.Should().BeNull();
                traktGenre.Slug.Should().BeNull();
                traktGenre.Type.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            var traktGenre = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktGenre.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktGenreObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new ITraktGenreObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktGenre = await traktJsonReader.ReadObjectAsync(stream);
                traktGenre.Should().BeNull();
            }
        }
    }
}
