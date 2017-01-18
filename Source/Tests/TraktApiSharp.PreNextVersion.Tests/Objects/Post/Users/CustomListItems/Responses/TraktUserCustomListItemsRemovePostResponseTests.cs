namespace TraktApiSharp.Tests.Objects.Post.Users.ListItems.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses;
    using Utils;

    [TestClass]
    public class TraktUserCustomListItemsRemovePostResponseTests
    {
        [TestMethod]
        public void TestTraktUserCustomListItemsRemovePostResponseDefaultConstructor()
        {
            var userListItemsRemovePostResponse = new TraktUserCustomListItemsRemovePostResponse();

            userListItemsRemovePostResponse.Deleted.Should().BeNull();
            userListItemsRemovePostResponse.NotFound.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserCustomListItemsRemovePostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Users\CustomListItems\Responses\UserCustomListItemsRemovePostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userListItemsRemovePostResponse = JsonConvert.DeserializeObject<TraktUserCustomListItemsRemovePostResponse>(jsonFile);

            userListItemsRemovePostResponse.Should().NotBeNull();

            userListItemsRemovePostResponse.Deleted.Should().NotBeNull();
            userListItemsRemovePostResponse.Deleted.Movies.Should().Be(1);
            userListItemsRemovePostResponse.Deleted.Shows.Should().Be(1);
            userListItemsRemovePostResponse.Deleted.Seasons.Should().Be(1);
            userListItemsRemovePostResponse.Deleted.Episodes.Should().Be(2);
            userListItemsRemovePostResponse.Deleted.People.Should().Be(1);

            userListItemsRemovePostResponse.NotFound.Should().NotBeNull();
            userListItemsRemovePostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = userListItemsRemovePostResponse.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            userListItemsRemovePostResponse.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            userListItemsRemovePostResponse.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            userListItemsRemovePostResponse.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
            userListItemsRemovePostResponse.NotFound.People.Should().NotBeNull().And.BeEmpty();
        }
    }
}
