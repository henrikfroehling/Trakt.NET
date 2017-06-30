namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class TraktListIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new TraktListIdsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(55);
                traktListIds.Slug.Should().Be("star-wars-in-machete-order");
            }
        }

        [Fact]
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new TraktListIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(0);
                traktListIds.Slug.Should().Be("star-wars-in-machete-order");
            }
        }

        [Fact]
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new TraktListIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(55);
                traktListIds.Slug.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new TraktListIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(0);
                traktListIds.Slug.Should().Be("star-wars-in-machete-order");
            }
        }

        [Fact]
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new TraktListIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(55);
                traktListIds.Slug.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new TraktListIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(0);
                traktListIds.Slug.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktListIdsObjectJsonReader();

            var traktListIds = await jsonReader.ReadObjectAsync(default(Stream));
            traktListIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktListIdsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);
                traktListIds.Should().BeNull();
            }
        }
    }
}
