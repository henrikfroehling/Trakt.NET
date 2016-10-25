namespace TraktApiSharp.Tests.Experimental.Requests.Comments
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Comments;

    [TestClass]
    public class TraktCommentSummaryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("Without OAuth")]
        public void TestTraktCommentSummaryRequestIsNotAbstract()
        {
            typeof(TraktCommentSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("Without OAuth")]
        public void TestTraktCommentSummaryRequestIsSealed()
        {
            typeof(TraktCommentSummaryRequest).IsSealed.Should().BeTrue();
        }
    }
}
