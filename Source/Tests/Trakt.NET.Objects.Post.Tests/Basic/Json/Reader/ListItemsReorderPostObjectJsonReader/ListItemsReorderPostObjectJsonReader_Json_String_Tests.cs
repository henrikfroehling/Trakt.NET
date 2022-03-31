namespace TraktNet.Objects.Post.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic;
    using TraktNet.Objects.Post.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Basic.JsonReader")]
    public partial class ListItemsReorderPostObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemsReorderPostObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var traktJsonReader = new ListItemsReorderPostObjectJsonReader();
            var listItemsReorderPost = await traktJsonReader.ReadObjectAsync(JSON_COMPLETE);

            listItemsReorderPost.Should().NotBeNull();
            listItemsReorderPost.Rank.Should().NotBeNull().And.HaveCount(7);
            listItemsReorderPost.Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });
        }

        [Fact]
        public async Task Test_ListItemsReorderPostObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var traktJsonReader = new ListItemsReorderPostObjectJsonReader();
            var listItemsReorderPost = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID);

            listItemsReorderPost.Should().NotBeNull();
            listItemsReorderPost.Rank.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var traktJsonReader = new ListItemsReorderPostObjectJsonReader();
            Func<Task<ITraktListItemsReorderPost>> listItemsReorderPost = () => traktJsonReader.ReadObjectAsync(default(string));
            await listItemsReorderPost.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var traktJsonReader = new ListItemsReorderPostObjectJsonReader();
            var listItemsReorderPost = await traktJsonReader.ReadObjectAsync(string.Empty);
            listItemsReorderPost.Should().BeNull();
        }
    }
}
