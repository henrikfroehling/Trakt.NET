namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktCommentSortOrderTests
    {
        [TestMethod]
        public void TestTraktCommentSortOrderHasMembers()
        {
            typeof(TraktCommentSortOrder).GetEnumNames().Should().HaveCount(5)
                                                        .And.Contain("Unspecified", "Newest", "Oldest", "Likes", "Replies");
        }

        [TestMethod]
        public void TestTraktCommentSortOrderGetAsString()
        {
            TraktCommentSortOrder.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktCommentSortOrder.Newest.AsString().Should().Be("newest");
            TraktCommentSortOrder.Oldest.AsString().Should().Be("oldest");
            TraktCommentSortOrder.Likes.AsString().Should().Be("likes");
            TraktCommentSortOrder.Replies.AsString().Should().Be("replies");
        }
    }
}
