namespace TraktNet.Objects.Post.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic;
    using TraktNet.Objects.Post.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Basic.JsonReader")]
    public partial class ListItemsReorderPostObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemsReorderPostObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new ListItemsReorderPostObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var listItemsReorderPost = await traktJsonReader.ReadObjectAsync(stream);

                listItemsReorderPost.Should().NotBeNull();
                listItemsReorderPost.Rank.Should().NotBeNull().And.HaveCount(7);
                listItemsReorderPost.Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var traktJsonReader = new ListItemsReorderPostObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var listItemsReorderPost = await traktJsonReader.ReadObjectAsync(stream);

                listItemsReorderPost.Should().NotBeNull();
                listItemsReorderPost.Rank.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemsReorderPostObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new ListItemsReorderPostObjectJsonReader();
            Func<Task<ITraktListItemsReorderPost>> listItemsReorderPost = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await listItemsReorderPost.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ListItemsReorderPostObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new ListItemsReorderPostObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var listItemsReorderPost = await traktJsonReader.ReadObjectAsync(stream);
                listItemsReorderPost.Should().BeNull();
            }
        }
    }
}
