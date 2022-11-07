namespace TraktNet.Objects.Post.Tests.Basic.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic.Responses;
    using TraktNet.Objects.Post.Basic.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Basic.Responses.JsonReader")]
    public partial class ListItemsReorderPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();
            var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(JSON_COMPLETE);

            listItemsReorderPostResponse.Should().NotBeNull();
            listItemsReorderPostResponse.Updated.Should().Be(6);
            listItemsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
            listItemsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();
            var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            listItemsReorderPostResponse.Should().NotBeNull();
            listItemsReorderPostResponse.Updated.Should().BeNull();
            listItemsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
            listItemsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();
            var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            listItemsReorderPostResponse.Should().NotBeNull();
            listItemsReorderPostResponse.Updated.Should().Be(6);
            listItemsReorderPostResponse.SkippedIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();
            var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            listItemsReorderPostResponse.Should().NotBeNull();
            listItemsReorderPostResponse.Updated.Should().BeNull();
            listItemsReorderPostResponse.SkippedIds.Should().NotBeNull().And.HaveCount(1);
            listItemsReorderPostResponse.SkippedIds.Should().BeEquivalentTo(new List<uint> { 2 });
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();
            var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            listItemsReorderPostResponse.Should().NotBeNull();
            listItemsReorderPostResponse.Updated.Should().Be(6);
            listItemsReorderPostResponse.SkippedIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();
            var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            listItemsReorderPostResponse.Should().NotBeNull();
            listItemsReorderPostResponse.Updated.Should().BeNull();
            listItemsReorderPostResponse.SkippedIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();
            Func<Task<ITraktListItemsReorderPostResponse>> listItemsReorderPostResponse = () => traktJsonReader.ReadObjectAsync(default(string));
            await listItemsReorderPostResponse.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostResponseObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var traktJsonReader = new ListItemsReorderPostResponseObjectJsonReader();
            var listItemsReorderPostResponse = await traktJsonReader.ReadObjectAsync(string.Empty);
            listItemsReorderPostResponse.Should().BeNull();
        }
    }
}
