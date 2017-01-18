namespace TraktApiSharp.Tests.Objects.Post.Users.ListItems.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses;
    using Utils;

    [TestClass]
    public class TraktUserCustomListItemsPostResponseTests
    {
        [TestMethod]
        public void TestTraktUserCustomListItemsPostResponseDefaultConstructor()
        {
            var userListItemsPostResponse = new TraktUserCustomListItemsPostResponse();

            userListItemsPostResponse.Added.Should().BeNull();
            userListItemsPostResponse.Existing.Should().BeNull();
            userListItemsPostResponse.NotFound.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserCustomListItemsPostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Users\CustomListItems\Responses\UserCustomListItemsPostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userListItemsPostResponse = JsonConvert.DeserializeObject<TraktUserCustomListItemsPostResponse>(jsonFile);

            userListItemsPostResponse.Should().NotBeNull();

            userListItemsPostResponse.Added.Should().NotBeNull();
            userListItemsPostResponse.Added.Movies.Should().Be(1);
            userListItemsPostResponse.Added.Shows.Should().Be(1);
            userListItemsPostResponse.Added.Seasons.Should().Be(1);
            userListItemsPostResponse.Added.Episodes.Should().Be(2);
            userListItemsPostResponse.Added.People.Should().Be(1);

            userListItemsPostResponse.Existing.Should().NotBeNull();
            userListItemsPostResponse.Existing.Movies.Should().Be(0);
            userListItemsPostResponse.Existing.Shows.Should().Be(0);
            userListItemsPostResponse.Existing.Seasons.Should().Be(0);
            userListItemsPostResponse.Existing.Episodes.Should().Be(0);
            userListItemsPostResponse.Existing.People.Should().Be(0);

            userListItemsPostResponse.NotFound.Should().NotBeNull();
            userListItemsPostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = userListItemsPostResponse.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            userListItemsPostResponse.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            userListItemsPostResponse.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            userListItemsPostResponse.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
            userListItemsPostResponse.NotFound.People.Should().NotBeNull().And.BeEmpty();
        }
    }
}
