namespace TraktNet.Objects.Get.Tests.Users.Lists.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ListIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(55);
                traktListIds.Slug.Should().Be("star-wars-in-machete-order");
            }
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ListIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(0);
                traktListIds.Slug.Should().Be("star-wars-in-machete-order");
            }
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ListIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(55);
                traktListIds.Slug.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ListIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(0);
                traktListIds.Slug.Should().Be("star-wars-in-machete-order");
            }
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ListIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(55);
                traktListIds.Slug.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ListIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktListIds.Should().NotBeNull();
                traktListIds.Trakt.Should().Be(0);
                traktListIds.Slug.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ListIdsObjectJsonReader();

            var traktListIds = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktListIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ListIdsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListIds = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktListIds.Should().BeNull();
            }
        }
    }
}
