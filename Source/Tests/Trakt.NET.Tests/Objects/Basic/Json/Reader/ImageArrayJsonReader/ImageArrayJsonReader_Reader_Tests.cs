namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ImageArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ImageArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktImage> traktImages = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktImages.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ImageArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktImage> traktImages = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktImages.Should().NotBeNull();
                ITraktImage[] images = traktImages.ToArray();

                images[0].Should().NotBeNull();
                images[0].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");

                images[1].Should().NotBeNull();
                images[1].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ImageArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktImage> traktImages = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktImages.Should().NotBeNull();
                ITraktImage[] images = traktImages.ToArray();

                images[0].Should().NotBeNull();
                images[0].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");

                images[1].Should().NotBeNull();
                images[1].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ImageArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktImage> traktImages = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktImages.Should().NotBeNull();
                ITraktImage[] images = traktImages.ToArray();

                images[0].Should().NotBeNull();
                images[0].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");

                images[1].Should().NotBeNull();
                images[1].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ImageArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktImage> traktImages = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktImages.Should().NotBeNull();
                ITraktImage[] images = traktImages.ToArray();

                images[0].Should().NotBeNull();
                images[0].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");

                images[1].Should().NotBeNull();
                images[1].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ImageArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktImage> traktImages = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktImages.Should().NotBeNull();
                ITraktImage[] images = traktImages.ToArray();

                images[0].Should().NotBeNull();
                images[0].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");

                images[1].Should().NotBeNull();
                images[1].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ImageArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktImage> traktImages = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktImages.Should().NotBeNull();
                ITraktImage[] images = traktImages.ToArray();

                images[0].Should().NotBeNull();
                images[0].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");

                images[1].Should().NotBeNull();
                images[1].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ImageArrayJsonReader();
            IEnumerable<ITraktImage> traktImages = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktImages.Should().BeNull();
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ImageArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktImage> traktImages = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktImages.Should().BeNull();
            }
        }
    }
}
