namespace TraktApiSharp.Tests.Objects.Post.Comments
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Post.Comments.Implementations;

    [TestClass]
    public class TraktCommentReplyPostTests
    {
        [TestMethod]
        public void TestTraktCommentReplyPostDefaultConstructor()
        {
            var commentReply = new TraktCommentReplyPost();

            commentReply.Comment.Should().BeNullOrEmpty();
            commentReply.Spoiler.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktCommentReplyPostWriteJson()
        {
            var comment = "this is a comment reply";
            var spoiler = true;

            var commentReply = new TraktCommentReplyPost { Comment = comment, Spoiler = spoiler };

            var strJson = JsonConvert.SerializeObject(commentReply);

            strJson.Should().NotBeNullOrEmpty();

            var commentReplyFromJson = JsonConvert.DeserializeObject<TraktCommentReplyPost>(strJson);

            commentReplyFromJson.Should().NotBeNull();
            commentReplyFromJson.Comment.Should().Be(comment);
            commentReplyFromJson.Spoiler.Should().Be(spoiler);
        }
    }
}
