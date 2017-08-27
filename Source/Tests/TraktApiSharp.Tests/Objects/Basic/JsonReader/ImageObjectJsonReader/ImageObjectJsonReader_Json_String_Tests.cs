namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ImageObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ImageObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ImageObjectJsonReader();

            var traktImage = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktImage.Should().NotBeNull();
            traktImage.Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
        }

        [Fact]
        public async Task Test_ImageObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new ImageObjectJsonReader();

            var traktImage = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            traktImage.Should().NotBeNull();
            traktImage.Full.Should().BeNull();
        }

        [Fact]
        public async Task Test_ImageObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ImageObjectJsonReader();

            var traktImage = await jsonReader.ReadObjectAsync(default(string));
            traktImage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ImageObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ImageObjectJsonReader();

            var traktImage = await jsonReader.ReadObjectAsync(string.Empty);
            traktImage.Should().BeNull();
        }
    }
}
