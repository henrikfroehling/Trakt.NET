namespace TraktApiSharp.Tests.Experimental.Requests.Comments.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Comments.OAuth;
    using TraktApiSharp.Objects.Post.Comments;

    [TestClass]
    public class TraktShowCommentPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktShowCommentPostRequestIsNotAbstract()
        {
            typeof(TraktShowCommentPostRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktShowCommentPostRequestIsSealed()
        {
            typeof(TraktShowCommentPostRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktShowCommentPostRequestIsSubclassOfATraktCommentPostRequest()
        {
            typeof(TraktShowCommentPostRequest).IsSubclassOf(typeof(ATraktCommentPostRequest<TraktShowCommentPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktShowCommentPostRequestHasValidUriTemplate()
        {
            var request = new TraktShowCommentPostRequest(null);
            request.UriTemplate.Should().Be("comments");
        }
    }
}
