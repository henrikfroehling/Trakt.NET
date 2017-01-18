namespace TraktApiSharp.Tests.Objects.Post.Comments
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Post.Comments;

    [TestClass]
    public class TraktListCommentPostTests
    {
        [TestMethod]
        public void TestTraktListCommentPostDefaultConstructor()
        {
            var listComment = new TraktListCommentPost();

            listComment.Comment.Should().BeNullOrEmpty();
            listComment.Spoiler.Should().NotHaveValue();
            listComment.Sharing.Should().BeNull();
            listComment.List.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktListCommentPostWriteJson()
        {
            var comment = "this is a comment";
            var spoiler = false;
            var sharing = new TraktSharing { Facebook = false, Twitter = true, Tumblr = false };

            var listTraktId = 16U;

            var list = new TraktList { Ids = new TraktListIds { Trakt = listTraktId } };

            var listComment = new TraktListCommentPost
            {
                Comment = comment,
                Spoiler = spoiler,
                Sharing = sharing,
                List = list
            };

            var strJson = JsonConvert.SerializeObject(listComment);

            strJson.Should().NotBeNullOrEmpty();

            var listCommentFromJson = JsonConvert.DeserializeObject<TraktListCommentPost>(strJson);

            listCommentFromJson.Should().NotBeNull();
            listCommentFromJson.Comment.Should().Be(comment);
            listCommentFromJson.Spoiler.Should().Be(spoiler);
            listCommentFromJson.Sharing.Should().NotBeNull();
            listCommentFromJson.Sharing.Facebook.Should().BeFalse();
            listCommentFromJson.Sharing.Twitter.Should().BeTrue();
            listCommentFromJson.Sharing.Tumblr.Should().BeFalse();

            listCommentFromJson.List.Should().NotBeNull();
            listCommentFromJson.List.Ids.Should().NotBeNull();
            listCommentFromJson.List.Ids.Trakt.Should().Be(listTraktId);
        }
    }
}
