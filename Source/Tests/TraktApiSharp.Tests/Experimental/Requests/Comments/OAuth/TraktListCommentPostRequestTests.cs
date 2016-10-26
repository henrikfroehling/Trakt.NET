namespace TraktApiSharp.Tests.Experimental.Requests.Comments.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Comments.OAuth;
    using TraktApiSharp.Objects.Post.Comments;

    [TestClass]
    public class TraktListCommentPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktListCommentPostRequestIsNotAbstract()
        {
            typeof(TraktListCommentPostRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktListCommentPostRequestIsSealed()
        {
            typeof(TraktListCommentPostRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktListCommentPostRequestIsSubclassOfATraktCommentPostRequest()
        {
            typeof(TraktListCommentPostRequest).IsSubclassOf(typeof(ATraktCommentPostRequest<TraktListCommentPost>)).Should().BeTrue();
        }
    }
}
