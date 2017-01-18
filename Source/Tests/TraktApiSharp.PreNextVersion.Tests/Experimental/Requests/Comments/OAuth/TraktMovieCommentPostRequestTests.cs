namespace TraktApiSharp.Tests.Experimental.Requests.Comments.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Comments.OAuth;
    using TraktApiSharp.Objects.Post.Comments;

    [TestClass]
    public class TraktMovieCommentPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktMovieCommentPostRequestIsNotAbstract()
        {
            typeof(TraktMovieCommentPostRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktMovieCommentPostRequestIsSealed()
        {
            typeof(TraktMovieCommentPostRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktMovieCommentPostRequestIsSubclassOfATraktCommentPostRequest()
        {
            typeof(TraktMovieCommentPostRequest).IsSubclassOf(typeof(ATraktCommentPostRequest<TraktMovieCommentPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktMovieCommentPostRequestHasValidUriTemplate()
        {
            var request = new TraktMovieCommentPostRequest(null);
            request.UriTemplate.Should().Be("comments");
        }
    }
}
