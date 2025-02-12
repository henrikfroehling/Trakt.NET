namespace TraktNET.Json.Comments
{
    public sealed class TraktCommentTests
    {
        [Fact]
        public void TestTraktCommentConstructor()
        {
            var comment = new TraktComment();

            comment.ID.ShouldBeNull();
            comment.ParentID.ShouldBeNull();
            comment.Comment.ShouldBeNull();
            comment.Spoiler.ShouldBeNull();
            comment.Review.ShouldBeNull();
            comment.Replies.ShouldBeNull();
            comment.Likes.ShouldBeNull();
            comment.CreatedAt.ShouldBeNull();
            comment.UpdatedAt.ShouldBeNull();
            comment.UserStats.ShouldBeNull();
            comment.User.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCommentFromJson()
        {
            TraktComment? comment = await TraktTestUtility.DeserializeJsonAsync<TraktComment>("Comments\\comment.json");

            comment.ShouldNotBeNull();

            comment!.ID.ShouldBe(7149524U);
            comment!.ParentID.ShouldBe(0U);
            comment!.Comment.ShouldBe("Comment content.");
            comment!.Spoiler.ShouldBe(false);
            comment!.Review.ShouldBe(false);
            comment!.Replies.ShouldBe(0U);
            comment!.Likes.ShouldBe(0U);
            comment!.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-10-04T16:25:36.000Z"));
            comment!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-10-04T16:25:36.000Z"));

            comment!.UserStats.ShouldNotBeNull();
            comment!.UserStats!.Rating.ShouldBe(9U);
            comment!.UserStats!.PlayCount.ShouldBe(3U);
            comment!.UserStats!.CompletedCount.ShouldBe(1U);

            comment!.User.ShouldNotBeNull();
            comment!.User!.Username.ShouldBe("user1");
            comment!.User!.Private.ShouldBe(true);
            comment!.User!.IDs.ShouldNotBeNull();
            comment!.User!.IDs!.Slug.ShouldBe("user1");
        }
    }
}
