namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ErrorObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);

                traktError.Should().NotBeNull();
                traktError.Error.Should().Be("trakt error");
                traktError.Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);

                traktError.Should().NotBeNull();
                traktError.Error.Should().Be("trakt error");
                traktError.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);

                traktError.Should().NotBeNull();
                traktError.Error.Should().BeNull();
                traktError.Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);

                traktError.Should().NotBeNull();
                traktError.Error.Should().Be("trakt error");
                traktError.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);

                traktError.Should().NotBeNull();
                traktError.Error.Should().BeNull();
                traktError.Description.Should().Be("trakt error description");
            }
        }

        [Fact]
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);

                traktError.Should().NotBeNull();
                traktError.Error.Should().BeNull();
                traktError.Description.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

            var traktError = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktError.Should().BeNull();
        }

        [Fact]
        public async Task Test_ErrorObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new ErrorObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktError = await traktJsonReader.ReadObjectAsync(stream);
                traktError.Should().BeNull();
            }
        }
    }
}
