namespace TraktApiSharp.Tests.Experimental.Requests.Comments
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Comments;

    [TestClass]
    public class TraktCommentRepliesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("Without OAuth")]
        public void TestTraktCommentRepliesRequestIsNotAbstract()
        {
            typeof(TraktCommentRepliesRequest).IsAbstract.Should().BeFalse();
        }
    }
}
