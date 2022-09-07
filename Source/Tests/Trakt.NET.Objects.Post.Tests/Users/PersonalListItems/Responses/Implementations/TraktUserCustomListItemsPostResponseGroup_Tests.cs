namespace TraktNet.Objects.Post.Tests.Users.PersonalListItems.Responses.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems.Responses;
    using TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.PersonalListItems.Responses.Implementations")]
    public class TraktUserPersonalListItemsPostResponseGroup_Tests
    {
        [Fact]
        public void Test_TraktUserPersonalListItemsPostResponseGroup_Default_Constructor()
        {
            var personalListItemsPostResponseGroup = new TraktUserPersonalListItemsPostResponseGroup();

            personalListItemsPostResponseGroup.Movies.Should().BeNull();
            personalListItemsPostResponseGroup.Shows.Should().BeNull();
            personalListItemsPostResponseGroup.Seasons.Should().BeNull();
            personalListItemsPostResponseGroup.Episodes.Should().BeNull();
            personalListItemsPostResponseGroup.People.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserPersonalListItemsPostResponseGroup_From_Json()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();
            var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON) as TraktUserPersonalListItemsPostResponseGroup;

            personalListItemsPostResponseGroup.Should().NotBeNull();
            personalListItemsPostResponseGroup.Movies.Should().Be(1);
            personalListItemsPostResponseGroup.Shows.Should().Be(2);
            personalListItemsPostResponseGroup.Seasons.Should().Be(3);
            personalListItemsPostResponseGroup.Episodes.Should().Be(4);
            personalListItemsPostResponseGroup.People.Should().Be(5);
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
