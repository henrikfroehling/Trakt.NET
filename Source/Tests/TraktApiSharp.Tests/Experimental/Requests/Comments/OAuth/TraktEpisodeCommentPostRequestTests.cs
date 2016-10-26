namespace TraktApiSharp.Tests.Experimental.Requests.Comments.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Comments.OAuth;
    using TraktApiSharp.Objects.Post.Comments;

    [TestClass]
    public class TraktEpisodeCommentPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktEpisodeCommentPostRequestIsNotAbstract()
        {
            typeof(TraktEpisodeCommentPostRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktEpisodeCommentPostRequestIsSealed()
        {
            typeof(TraktEpisodeCommentPostRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktEpisodeCommentPostRequestIsSubclassOfATraktCommentPostRequest()
        {
            typeof(TraktEpisodeCommentPostRequest).IsSubclassOf(typeof(ATraktCommentPostRequest<TraktEpisodeCommentPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktEpisodeCommentPostRequestHasValidUriTemplate()
        {
            var request = new TraktEpisodeCommentPostRequest(null);
            request.UriTemplate.Should().Be("comments");
        }
    }
}
