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
    public partial class ITraktErrorObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);

                traktError.Should().NotBeNull();
                traktError.Error.Should().Be("trakt error");
                traktError.Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);

                traktError.Should().NotBeNull();
                traktError.Error.Should().Be("trakt error");
                traktError.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);

                traktError.Should().NotBeNull();
                traktError.Error.Should().BeNull();
                traktError.Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);

                traktError.Should().NotBeNull();
                traktError.Error.Should().Be("trakt error");
                traktError.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);

                traktError.Should().NotBeNull();
                traktError.Error.Should().BeNull();
                traktError.Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);

                traktError.Should().NotBeNull();
                traktError.Error.Should().BeNull();
                traktError.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            var traktError = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktError.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktErrorObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new ITraktErrorObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);
                traktError.Should().BeNull();
            }
        }
    }
}
