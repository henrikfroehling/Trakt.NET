namespace TraktApiSharp.Tests.Objects.Get.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;

    [TestClass]
    public class TraktUserLikeItemTests
    {
        [TestMethod]
        public void TestTraktUserLikeItemDefaultConstructor()
        {
            var userLike = new TraktUserLikeItem();

            userLike.LikedAt.Should().NotHaveValue();
            userLike.Type.Should().BeNull();
            userLike.Comment.Should().BeNull();
            userLike.List.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserLikeItemReadFromJsonComment()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserLikeComment.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userLike = JsonConvert.DeserializeObject<TraktUserLikeItem>(jsonFile);

            userLike.Should().NotBeNull();

            userLike.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
            userLike.Type.Should().Be(TraktUserLikeType.Comment);
            userLike.Comment.Should().NotBeNull();
            userLike.Comment.Id.Should().Be(190U);
            userLike.Comment.ParentId.Should().Be(0U);
            userLike.Comment.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            userLike.Comment.Comment.Should().Be("Oh, I wasn't really listening.");
            userLike.Comment.Spoiler.Should().BeFalse();
            userLike.Comment.Review.Should().BeFalse();
            userLike.Comment.Replies.Should().Be(0);
            userLike.Comment.Likes.Should().Be(0);
            userLike.Comment.UserRating.Should().NotHaveValue();
            userLike.Comment.User.Should().NotBeNull();
            userLike.Comment.User.Username.Should().Be("sean");
            userLike.Comment.User.Private.Should().BeFalse();
            userLike.Comment.User.Name.Should().Be("Sean Rudford");
            userLike.Comment.User.VIP.Should().BeTrue();
            userLike.Comment.User.VIP_EP.Should().BeFalse();
            userLike.List.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserLikeItemReadFromJsonList()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserLikeList.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userLike = JsonConvert.DeserializeObject<TraktUserLikeItem>(jsonFile);

            userLike.Should().NotBeNull();

            userLike.LikedAt.Should().Be(DateTime.Parse("2015-03-31T23:18:42.000Z").ToUniversalTime());
            userLike.Type.Should().Be(TraktUserLikeType.List);
            userLike.Comment.Should().BeNull();
            userLike.List.Should().NotBeNull();
            userLike.List.Name.Should().Be("Star Wars in NEW machete order");
            userLike.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            userLike.List.Privacy.Should().Be(TraktAccessScope.Private);
            userLike.List.DisplayNumbers.Should().BeTrue();
            userLike.List.AllowComments.Should().BeFalse();
            userLike.List.UpdatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            userLike.List.ItemCount.Should().Be(5);
            userLike.List.CommentCount.Should().Be(0);
            userLike.List.Likes.Should().Be(0);
            userLike.List.Ids.Should().NotBeNull();
            userLike.List.Ids.Trakt.Should().Be(55U);
            userLike.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            userLike.List.User.Should().NotBeNull();
            userLike.List.User.Username.Should().Be("sean");
            userLike.List.User.Private.Should().BeFalse();
            userLike.List.User.Name.Should().Be("Sean Rudford");
            userLike.List.User.VIP.Should().BeTrue();
            userLike.List.User.VIP_EP.Should().BeFalse();
        }
    }
}
