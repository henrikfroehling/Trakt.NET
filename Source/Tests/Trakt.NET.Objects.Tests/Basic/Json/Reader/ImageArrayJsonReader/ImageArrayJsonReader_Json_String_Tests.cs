namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ImageArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ImageArrayJsonReader();
            IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktImages.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ImageArrayJsonReader();
            IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktImages.Should().NotBeNull();
            ITraktImage[] images = traktImages.ToArray();

            images[0].Should().NotBeNull();
            images[0].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");

            images[1].Should().NotBeNull();
            images[1].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ImageArrayJsonReader();
            IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktImages.Should().NotBeNull();
            ITraktImage[] images = traktImages.ToArray();

            images[0].Should().NotBeNull();
            images[0].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");

            images[1].Should().NotBeNull();
            images[1].Full.Should().BeNull();
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ImageArrayJsonReader();
            IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktImages.Should().NotBeNull();
            ITraktImage[] images = traktImages.ToArray();

            images[0].Should().NotBeNull();
            images[0].Full.Should().BeNull();

            images[1].Should().NotBeNull();
            images[1].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ImageArrayJsonReader();
            IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktImages.Should().NotBeNull();
            ITraktImage[] images = traktImages.ToArray();

            images[0].Should().NotBeNull();
            images[0].Full.Should().BeNull();

            images[1].Should().NotBeNull();
            images[1].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ImageArrayJsonReader();
            IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktImages.Should().NotBeNull();
            ITraktImage[] images = traktImages.ToArray();

            images[0].Should().NotBeNull();
            images[0].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");

            images[1].Should().NotBeNull();
            images[1].Full.Should().BeNull();
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ImageArrayJsonReader();
            IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            traktImages.Should().NotBeNull();
            ITraktImage[] images = traktImages.ToArray();

            images[0].Should().NotBeNull();
            images[0].Full.Should().BeNull();

            images[1].Should().NotBeNull();
            images[1].Full.Should().BeNull();
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ImageArrayJsonReader();
            IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(default(string));
            traktImages.Should().BeNull();
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ImageArrayJsonReader();
            IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(string.Empty);
            traktImages.Should().BeNull();
        }
    }
}
