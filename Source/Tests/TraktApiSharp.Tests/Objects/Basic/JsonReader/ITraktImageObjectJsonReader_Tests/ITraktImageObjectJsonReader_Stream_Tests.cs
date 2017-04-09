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
    public partial class ITraktImageObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktImageObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new ITraktImageObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktImage = await traktJsonReader.ReadObjectAsync(stream);

                traktImage.Should().NotBeNull();
                traktImage.Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public async Task Test_ITraktImageObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var traktJsonReader = new ITraktImageObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var traktImage = await traktJsonReader.ReadObjectAsync(stream);

                traktImage.Should().NotBeNull();
                traktImage.Full.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktImageObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new ITraktImageObjectJsonReader();

            var traktImage = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktImage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktImageObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new ITraktImageObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktImage = await traktJsonReader.ReadObjectAsync(stream);
                traktImage.Should().BeNull();
            }
        }
    }
}
