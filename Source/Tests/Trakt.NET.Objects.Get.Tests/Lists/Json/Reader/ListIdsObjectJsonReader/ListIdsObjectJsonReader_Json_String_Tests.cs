namespace TraktNet.Objects.Get.Tests.Lists.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Lists.JsonReader")]
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
            Func<Task<ITraktListIds>> traktListIds = () => jsonReader.ReadObjectAsync(default(string));
            await traktListIds.Should().ThrowAsync<ArgumentNullException>();
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
