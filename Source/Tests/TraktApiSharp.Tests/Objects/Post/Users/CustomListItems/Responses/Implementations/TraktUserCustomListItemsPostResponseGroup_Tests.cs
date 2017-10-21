namespace TraktApiSharp.Tests.Objects.Post.Users.CustomListItems.Responses.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Implementations;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Users.CustomListItems.Responses.Implementations")]
    public class TraktUserCustomListItemsPostResponseGroup_Tests
    {
        [Fact]
        public void Test_TraktUserCustomListItemsPostResponseGroup_Default_Constructor()
        {
            var customListItemsPostResponseGroup = new TraktUserCustomListItemsPostResponseGroup();

            customListItemsPostResponseGroup.Movies.Should().BeNull();
            customListItemsPostResponseGroup.Shows.Should().BeNull();
            customListItemsPostResponseGroup.Seasons.Should().BeNull();
            customListItemsPostResponseGroup.Episodes.Should().BeNull();
            customListItemsPostResponseGroup.People.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroup_From_Json()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();
            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON) as TraktUserCustomListItemsPostResponseGroup;

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().Be(1);
            customListItemsPostResponseGroup.Shows.Should().Be(2);
            customListItemsPostResponseGroup.Seasons.Should().Be(3);
            customListItemsPostResponseGroup.Episodes.Should().Be(4);
            customListItemsPostResponseGroup.People.Should().Be(5);
        }

        private const string JSON =
            @"{
                ""movies"": 1,
                ""shows"": 2,
                ""seasons"": 3,
                ""episodes"": 4,
                ""people"": 5
              }";
    }
}
