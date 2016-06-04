namespace TraktApiSharp.Tests.Objects.Post.Comments
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Post.Comments;

    [TestClass]
    public class TraktCommentUpdatePostTests
    {
        [TestMethod]
        public void TestTraktCommentUpdatePostDefaultConstructor()
        {
            var commentUpdate = new TraktCommentUpdatePost();

            commentUpdate.Comment.Should().BeNullOrEmpty();
            commentUpdate.Spoiler.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktCommentUpdatePostWriteJson()
        {
            var comment = "this is a comment";
            var spoiler = true;

            var commentUpdate = new TraktCommentUpdatePost { Comment = comment, Spoiler = spoiler };

            var strJson = JsonConvert.SerializeObject(commentUpdate);

            strJson.Should().NotBeNullOrEmpty();

            var commentUpdateFromJson = JsonConvert.DeserializeObject<TraktCommentUpdatePost>(strJson);

            commentUpdateFromJson.Should().NotBeNull();
            commentUpdateFromJson.Comment.Should().Be(comment);
            commentUpdateFromJson.Spoiler.Should().Be(spoiler);
        }
    }
}
