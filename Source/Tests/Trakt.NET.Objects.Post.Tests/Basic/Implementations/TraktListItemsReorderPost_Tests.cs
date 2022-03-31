namespace TraktNet.Objects.Post.Tests.Basic.Implementations
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic;
    using TraktNet.Objects.Post.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Basic.Implementations")]
    public class TraktListItemsReorderPost_Tests
    {
        [Fact]
        public void Test_TraktListItemsReorderPost_Default_Constructor()
        {
            var listItemsReorderPost = new TraktListItemsReorderPost();

            listItemsReorderPost.Rank.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemsReorderPost_From_Json()
        {
            var jsonReader = new ListItemsReorderPostObjectJsonReader();
            var listItemsReorderPost = await jsonReader.ReadObjectAsync(JSON) as TraktListItemsReorderPost;

            listItemsReorderPost.Should().NotBeNull();
            listItemsReorderPost.Rank.Should().NotBeNull().And.HaveCount(7);
            listItemsReorderPost.Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });
        }

        private const string JSON =
            @"{
                ""rank"": [
                  823,
                  224,
                  88768,
                  356456,
                  245,
                  2,
                  890
                ]
              }";
    }
}
