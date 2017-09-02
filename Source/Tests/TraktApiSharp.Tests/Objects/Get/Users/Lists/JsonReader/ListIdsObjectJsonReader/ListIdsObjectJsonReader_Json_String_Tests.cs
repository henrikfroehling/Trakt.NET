namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            var traktListIds = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktListIds.Should().NotBeNull();
            traktListIds.Trakt.Should().Be(55);
            traktListIds.Slug.Should().Be("star-wars-in-machete-order");
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            var traktListIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktListIds.Should().NotBeNull();
            traktListIds.Trakt.Should().Be(0);
            traktListIds.Slug.Should().Be("star-wars-in-machete-order");
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            var traktListIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktListIds.Should().NotBeNull();
            traktListIds.Trakt.Should().Be(55);
            traktListIds.Slug.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            var traktListIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktListIds.Should().NotBeNull();
            traktListIds.Trakt.Should().Be(0);
            traktListIds.Slug.Should().Be("star-wars-in-machete-order");
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            var traktListIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktListIds.Should().NotBeNull();
            traktListIds.Trakt.Should().Be(55);
            traktListIds.Slug.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            var traktListIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktListIds.Should().NotBeNull();
            traktListIds.Trakt.Should().Be(0);
            traktListIds.Slug.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            var traktListIds = await jsonReader.ReadObjectAsync(default(string));
            traktListIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListIdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ListIdsObjectJsonReader();

            var traktListIds = await jsonReader.ReadObjectAsync(string.Empty);
            traktListIds.Should().BeNull();
        }
    }
}
