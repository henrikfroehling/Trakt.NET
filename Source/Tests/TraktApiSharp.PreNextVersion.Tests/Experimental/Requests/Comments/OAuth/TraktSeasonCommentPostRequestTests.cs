namespace TraktApiSharp.Tests.Experimental.Requests.Comments.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Comments.OAuth;
    using TraktApiSharp.Objects.Post.Comments;

    [TestClass]
    public class TraktSeasonCommentPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktSeasonCommentPostRequestIsNotAbstract()
        {
            typeof(TraktSeasonCommentPostRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktSeasonCommentPostRequestIsSealed()
        {
            typeof(TraktSeasonCommentPostRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktSeasonCommentPostRequestIsSubclassOfATraktCommentPostRequest()
        {
            typeof(TraktSeasonCommentPostRequest).IsSubclassOf(typeof(ATraktCommentPostRequest<TraktSeasonCommentPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktSeasonCommentPostRequestHasValidUriTemplate()
        {
            var request = new TraktSeasonCommentPostRequest(null);
            request.UriTemplate.Should().Be("comments");
        }
    }
}
