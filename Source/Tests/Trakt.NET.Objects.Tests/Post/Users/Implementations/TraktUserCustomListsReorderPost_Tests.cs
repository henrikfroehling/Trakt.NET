namespace Trakt.NET.Objects.Tests.Post.Users.Implementations
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users;
    using TraktNet.Objects.Post.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.Implementations")]
    public class TraktUserCustomListsReorderPost_Tests
    {
        [Fact]
        public void Test_TraktUserCustomListsReorderPost_Default_Constructor()
        {
            var traktUserCustomListsReorderPost = new TraktUserCustomListsReorderPost();

            traktUserCustomListsReorderPost.Rank.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserCustomListsReorderPost_From_Json()
        {
            var jsonReader = new UserCustomListsReorderPostObjectJsonReader();
            var traktUserCustomListsReorderPost = await jsonReader.ReadObjectAsync(JSON) as TraktUserCustomListsReorderPost;

            traktUserCustomListsReorderPost.Should().NotBeNull();
            traktUserCustomListsReorderPost.Rank.Should().NotBeNull().And.HaveCount(7);
            traktUserCustomListsReorderPost.Rank.Should().BeEquivalentTo(new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 });
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
