namespace TraktApiSharp.Tests.Experimental.Requests.Comments
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Comments;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktCommentRepliesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("Without OAuth")]
        public void TestTraktCommentRepliesRequestIsNotAbstract()
        {
            typeof(TraktCommentRepliesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("Without OAuth")]
        public void TestTraktCommentRepliesRequestIsSealed()
        {
            typeof(TraktCommentRepliesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("Without OAuth")]
        public void TestTraktCommentRepliesRequestIsSubclassOfATraktPaginationGetByIdRequest()
        {
            //typeof(TraktCommentRepliesRequest).IsSubclassOf(typeof(ATraktPaginationGetByIdRequest<TraktComment>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("Without OAuth")]
        public void TestTraktCommentRepliesRequestHasAuthorizationNotRequired()
        {
            var request = new TraktCommentRepliesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("Without OAuth")]
        public void TestTraktCommentRepliesRequestHasValidUriTemplate()
        {
            var request = new TraktCommentRepliesRequest(null);
            request.UriTemplate.Should().Be("comments/{id}/replies{?page,limit}");
        }
    }
}
