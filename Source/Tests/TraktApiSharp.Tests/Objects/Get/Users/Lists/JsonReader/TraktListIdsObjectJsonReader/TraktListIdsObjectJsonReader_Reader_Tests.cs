namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class TraktListIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktListIdsObjectJsonReader();

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
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktListIdsObjectJsonReader();

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
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktListIdsObjectJsonReader();

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
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktListIdsObjectJsonReader();

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
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktListIdsObjectJsonReader();

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
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktListIdsObjectJsonReader();

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
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktListIdsObjectJsonReader();

            var traktListIds = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktListIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktListIdsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktListIds = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktListIds.Should().BeNull();
            }
        }
    }
}
