namespace TraktNet.Objects.Get.Tests.Users.Lists.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(55);
                traktListIds.Slug.Should().Be("star-wars-in-machete-order");
            }
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(0);
                traktListIds.Slug.Should().Be("star-wars-in-machete-order");
            }
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(55);
                traktListIds.Slug.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(0);
                traktListIds.Slug.Should().Be("star-wars-in-machete-order");
            }
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(55);
                traktListIds.Slug.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(0);
                traktListIds.Slug.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            var traktListIds = await jsonReader.ReadObjectAsync(default(Stream));
            traktListIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktListIds = await jsonReader.ReadObjectAsync(stream);
                traktListIds.Should().BeNull();
            }
        }
    }
}
