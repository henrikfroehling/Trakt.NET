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
    public class TraktUserCustomListUpdatePostResponseTests
    {
        [TestMethod]
        public void TestTraktUserCustomListUpdatePostResponseDefaultConstructor()
        {
            var userListUpdatePostResponse = new TraktUserCustomListUpdatePostResponse();

            userListUpdatePostResponse.Name.Should().BeNullOrEmpty();
            userListUpdatePostResponse.Description.Should().BeNullOrEmpty();
            userListUpdatePostResponse.Privacy.Should().Be(TraktAccessScope.Unspecified);
            userListUpdatePostResponse.DisplayNumbers.Should().NotHaveValue();
            userListUpdatePostResponse.AllowComments.Should().NotHaveValue();
            userListUpdatePostResponse.SortBy.Should().BeNullOrEmpty();
            userListUpdatePostResponse.SortHow.Should().BeNullOrEmpty();
            userListUpdatePostResponse.CreatedAt.Should().NotHaveValue();
            userListUpdatePostResponse.UpdatedAt.Should().NotHaveValue();
            userListUpdatePostResponse.ItemCount.Should().NotHaveValue();
            userListUpdatePostResponse.CommentCount.Should().NotHaveValue();
            userListUpdatePostResponse.Likes.Should().NotHaveValue();
            userListUpdatePostResponse.Ids.Should().BeNull();
            userListUpdatePostResponse.User.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserCustomListUpdatePostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Users\Responses\UserCustomListUpdatePostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userListUpdatePostResponse = JsonConvert.DeserializeObject<TraktUserCustomListUpdatePostResponse>(jsonFile);

            userListUpdatePostResponse.Should().NotBeNull();
            userListUpdatePostResponse.Name.Should().Be("Star Wars in NEW machete order");
            userListUpdatePostResponse.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            userListUpdatePostResponse.Privacy.Should().Be(TraktAccessScope.Private);
            userListUpdatePostResponse.DisplayNumbers.Should().BeTrue();
            userListUpdatePostResponse.AllowComments.Should().BeFalse();
            userListUpdatePostResponse.SortBy.Should().Be("rank");
            userListUpdatePostResponse.SortHow.Should().Be("asc");
            userListUpdatePostResponse.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            userListUpdatePostResponse.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            userListUpdatePostResponse.ItemCount.Should().Be(5);
            userListUpdatePostResponse.CommentCount.Should().Be(0);
            userListUpdatePostResponse.Likes.Should().Be(0);
            userListUpdatePostResponse.Ids.Should().NotBeNull();
            userListUpdatePostResponse.Ids.Trakt.Should().Be(55);
            userListUpdatePostResponse.Ids.Slug.Should().Be("star-wars-in-machete-order");
            userListUpdatePostResponse.User.Should().NotBeNull();
            userListUpdatePostResponse.User.Username.Should().Be("sean");
            userListUpdatePostResponse.User.Private.Should().BeFalse();
            userListUpdatePostResponse.User.Name.Should().Be("Sean Rudford");
            userListUpdatePostResponse.User.VIP.Should().BeTrue();
            userListUpdatePostResponse.User.VIP_EP.Should().BeFalse();
        }
    }
}
