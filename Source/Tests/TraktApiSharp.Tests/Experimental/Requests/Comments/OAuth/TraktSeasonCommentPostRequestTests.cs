namespace TraktApiSharp.Tests.Experimental.Requests.Comments.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Comments.OAuth;

    [TestClass]
    public class TraktSeasonCommentPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Comments"), TestCategory("With OAuth")]
        public void TestTraktSeasonCommentPostRequestIsNotAbstract()
        {
            typeof(TraktSeasonCommentPostRequest).IsAbstract.Should().BeFalse();
        }
    }
}
