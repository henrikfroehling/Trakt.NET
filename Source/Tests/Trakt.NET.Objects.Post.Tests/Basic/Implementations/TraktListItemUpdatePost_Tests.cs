namespace TraktNet.Objects.Post.Tests.Basic.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Basic;
    using TraktNet.Objects.Post.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Basic.Implementations")]
    public class TraktListItemUpdatePost_Tests
    {
        [Fact]
        public void Test_TraktListItemUpdatePost_Default_Constructor()
        {
            var listItemUpdatePost = new TraktListItemUpdatePost();

            listItemUpdatePost.Notes.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemUpdatePost_From_Json()
        {
            var jsonReader = new ListItemUpdatePostObjectJsonReader();
            var listItemUpdatePost = await jsonReader.ReadObjectAsync(JSON) as TraktListItemUpdatePost;

            listItemUpdatePost.Should().NotBeNull();
            listItemUpdatePost.Notes.Should().Be("This is a great movie!");
        }

        private const string JSON =
            @"{
                ""notes"": ""This is a great movie!""
              }";
    }
}
