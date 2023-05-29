namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktExtendedCommentSortOrder_Tests
    {
        [Fact]
        public void Test_TraktExtendedCommentSortOrder_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktExtendedCommentSortOrder>();

            allValues.Should().NotBeNull().And.HaveCount(8);
            allValues.Should().Contain(new List<TraktExtendedCommentSortOrder>() { TraktExtendedCommentSortOrder.Unspecified, TraktExtendedCommentSortOrder.Newest,
                                                                                   TraktExtendedCommentSortOrder.Oldest, TraktExtendedCommentSortOrder.Likes,
                                                                                   TraktExtendedCommentSortOrder.Replies, TraktExtendedCommentSortOrder.Highest,
                                                                                   TraktExtendedCommentSortOrder.Lowest, TraktExtendedCommentSortOrder.Plays });
        }

        [Fact]
        public void Test_TraktExtendedCommentSortOrder_Properties()
        {
            TraktExtendedCommentSortOrder.Newest.Value.Should().Be(1);
            TraktExtendedCommentSortOrder.Newest.ObjectName.Should().Be("newest");
            TraktExtendedCommentSortOrder.Newest.UriName.Should().Be("newest");
            TraktExtendedCommentSortOrder.Newest.DisplayName.Should().Be("Newest");

            TraktExtendedCommentSortOrder.Oldest.Value.Should().Be(2);
            TraktExtendedCommentSortOrder.Oldest.ObjectName.Should().Be("oldest");
            TraktExtendedCommentSortOrder.Oldest.UriName.Should().Be("oldest");
            TraktExtendedCommentSortOrder.Oldest.DisplayName.Should().Be("Oldest");

            TraktExtendedCommentSortOrder.Likes.Value.Should().Be(4);
            TraktExtendedCommentSortOrder.Likes.ObjectName.Should().Be("likes");
            TraktExtendedCommentSortOrder.Likes.UriName.Should().Be("likes");
            TraktExtendedCommentSortOrder.Likes.DisplayName.Should().Be("Likes");

            TraktExtendedCommentSortOrder.Replies.Value.Should().Be(8);
            TraktExtendedCommentSortOrder.Replies.ObjectName.Should().Be("replies");
            TraktExtendedCommentSortOrder.Replies.UriName.Should().Be("replies");
            TraktExtendedCommentSortOrder.Replies.DisplayName.Should().Be("Replies");

            TraktExtendedCommentSortOrder.Highest.Value.Should().Be(16);
            TraktExtendedCommentSortOrder.Highest.ObjectName.Should().Be("highest");
            TraktExtendedCommentSortOrder.Highest.UriName.Should().Be("highest");
            TraktExtendedCommentSortOrder.Highest.DisplayName.Should().Be("Highest");

            TraktExtendedCommentSortOrder.Lowest.Value.Should().Be(32);
            TraktExtendedCommentSortOrder.Lowest.ObjectName.Should().Be("lowest");
            TraktExtendedCommentSortOrder.Lowest.UriName.Should().Be("lowest");
            TraktExtendedCommentSortOrder.Lowest.DisplayName.Should().Be("Lowest");

            TraktExtendedCommentSortOrder.Plays.Value.Should().Be(64);
            TraktExtendedCommentSortOrder.Plays.ObjectName.Should().Be("plays");
            TraktExtendedCommentSortOrder.Plays.UriName.Should().Be("plays");
            TraktExtendedCommentSortOrder.Plays.DisplayName.Should().Be("Plays");
        }
    }
}
