namespace TraktApiSharp.Tests.Experimental.Requests.Comments
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Comments;
    using TraktApiSharp.Objects.Basic;

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
            typeof(TraktCommentRepliesRequest).IsSubclassOf(typeof(ATraktPaginationGetByIdRequest<TraktComment>)).Should().BeTrue();
        }
    }
}
