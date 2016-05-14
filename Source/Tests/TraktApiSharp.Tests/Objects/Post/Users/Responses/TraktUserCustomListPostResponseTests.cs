namespace TraktApiSharp.Tests.Objects.Post.Users.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Post.Users.Responses;
    using Utils;

    [TestClass]
    public class TraktUserCustomListPostResponseTests
    {
        [TestMethod]
        public void TestTraktUserCustomListPostResponseDefaultConstructor()
        {
            var userListPostResponse = new TraktUserCustomListPostResponse();

            userListPostResponse.Name.Should().BeNullOrEmpty();
            userListPostResponse.Description.Should().BeNullOrEmpty();
            userListPostResponse.Privacy.Should().Be(TraktAccessScope.Unspecified);
            userListPostResponse.DisplayNumbers.Should().NotHaveValue();
            userListPostResponse.AllowComments.Should().NotHaveValue();
            userListPostResponse.SortBy.Should().BeNullOrEmpty();
            userListPostResponse.SortHow.Should().BeNullOrEmpty();
            userListPostResponse.CreatedAt.Should().NotHaveValue();
            userListPostResponse.UpdatedAt.Should().NotHaveValue();
            userListPostResponse.ItemCount.Should().NotHaveValue();
            userListPostResponse.CommentCount.Should().NotHaveValue();
            userListPostResponse.Likes.Should().NotHaveValue();
            userListPostResponse.Ids.Should().BeNull();
            userListPostResponse.User.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserCustomListPostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Users\Responses\UserCustomListPostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userListPostResponse = JsonConvert.DeserializeObject<TraktUserCustomListPostResponse>(jsonFile);

            userListPostResponse.Should().NotBeNull();
            userListPostResponse.Name.Should().Be("Star Wars in machete order");
            userListPostResponse.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            userListPostResponse.Privacy.Should().Be(TraktAccessScope.Public);
            userListPostResponse.DisplayNumbers.Should().BeTrue();
            userListPostResponse.AllowComments.Should().BeTrue();
            userListPostResponse.SortBy.Should().Be("rank");
            userListPostResponse.SortHow.Should().Be("asc");
            userListPostResponse.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            userListPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            userListPostResponse.ItemCount.Should().Be(0);
            userListPostResponse.CommentCount.Should().Be(0);
            userListPostResponse.Likes.Should().Be(0);
            userListPostResponse.Ids.Should().NotBeNull();
            userListPostResponse.Ids.Trakt.Should().Be(55);
            userListPostResponse.Ids.Slug.Should().Be("star-wars-in-machete-order");
            userListPostResponse.User.Should().BeNull();
        }
    }
}
