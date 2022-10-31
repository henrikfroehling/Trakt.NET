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
    public partial class ImageArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktImage>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(stream);
                traktImages.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktImage>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(stream);

                traktImages.Should().NotBeNull();
                ITraktImage[] images = traktImages.ToArray();

                images[0].Should().NotBeNull();
                images[0].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");

                images[1].Should().NotBeNull();
                images[1].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktImage>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(stream);

                traktImages.Should().NotBeNull();
                ITraktImage[] images = traktImages.ToArray();

                images[0].Should().NotBeNull();
                images[0].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");

                images[1].Should().NotBeNull();
                images[1].Full.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktImage>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(stream);

                traktImages.Should().NotBeNull();
                ITraktImage[] images = traktImages.ToArray();

                images[0].Should().NotBeNull();
                images[0].Full.Should().BeNull();

                images[1].Should().NotBeNull();
                images[1].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktImage>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(stream);

                traktImages.Should().NotBeNull();
                ITraktImage[] images = traktImages.ToArray();

                images[0].Should().NotBeNull();
                images[0].Full.Should().BeNull();

                images[1].Should().NotBeNull();
                images[1].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktImage>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(stream);

                traktImages.Should().NotBeNull();
                ITraktImage[] images = traktImages.ToArray();

                images[0].Should().NotBeNull();
                images[0].Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");

                images[1].Should().NotBeNull();
                images[1].Full.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktImage>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(stream);

                traktImages.Should().NotBeNull();
                ITraktImage[] images = traktImages.ToArray();

                images[0].Should().NotBeNull();
                images[0].Full.Should().BeNull();

                images[1].Should().NotBeNull();
                images[1].Full.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktImage>();
            Func<Task<IEnumerable<ITraktImage>>> traktImages = () => jsonReader.ReadArrayAsync(default(Stream));
            await traktImages.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ImageArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktImage>();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktImage> traktImages = await jsonReader.ReadArrayAsync(stream);
                traktImages.Should().BeNull();
            }
        }
    }
}
