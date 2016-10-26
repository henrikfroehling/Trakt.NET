namespace TraktApiSharp.Tests.Experimental.Requests.Comments.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post;
    using TraktApiSharp.Experimental.Requests.Comments.OAuth;
    using TraktApiSharp.Objects.Post.Comments;
    using TraktApiSharp.Objects.Post.Comments.Responses;

    [TestClass]
    public class TraktCommentReplyRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktCommentReplyRequestIsNotAbstract()
        {
            typeof(TraktCommentReplyRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktCommentReplyRequestIsSealed()
        {
            typeof(TraktCommentReplyRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktCommentReplyRequestIsSubclassOfATraktSingleItemPostByIdRequest()
        {
            typeof(TraktCommentReplyRequest).IsSubclassOf(typeof(ATraktSingleItemPostByIdRequest<TraktCommentPostResponse, TraktCommentReplyPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktCommentReplyRequestHasValidUriTemplate()
        {
            var request = new TraktCommentReplyRequest(null);
            request.UriTemplate.Should().Be("comments/{id}/replies");
        }
    }
}
