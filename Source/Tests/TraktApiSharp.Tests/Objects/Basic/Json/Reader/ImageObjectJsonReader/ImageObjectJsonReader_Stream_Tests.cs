namespace TraktApiSharp.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ImageObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ImageObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new ImageObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktImage = await traktJsonReader.ReadObjectAsync(stream);

                traktImage.Should().NotBeNull();
                traktImage.Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public async Task Test_ImageObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var traktJsonReader = new ImageObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var traktImage = await traktJsonReader.ReadObjectAsync(stream);

                traktImage.Should().NotBeNull();
                traktImage.Full.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ImageObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new ImageObjectJsonReader();

            var traktImage = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktImage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ImageObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new ImageObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktImage = await traktJsonReader.ReadObjectAsync(stream);
                traktImage.Should().BeNull();
            }
        }
    }
}
