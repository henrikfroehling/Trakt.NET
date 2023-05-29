namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktCommentSortOrder_Tests
    {
        [Fact]
        public void Test_TraktCommentSortOrder_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktCommentSortOrder>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktCommentSortOrder>() { TraktCommentSortOrder.Unspecified, TraktCommentSortOrder.Newest,
                                                                           TraktCommentSortOrder.Oldest, TraktCommentSortOrder.Likes,
                                                                           TraktCommentSortOrder.Replies });
        }

        [Fact]
        public void Test_TraktCommentSortOrder_Properties()
        {
            TraktCommentSortOrder.Newest.Value.Should().Be(1);
            TraktCommentSortOrder.Newest.ObjectName.Should().Be("newest");
            TraktCommentSortOrder.Newest.UriName.Should().Be("newest");
            TraktCommentSortOrder.Newest.DisplayName.Should().Be("Newest");

            TraktCommentSortOrder.Oldest.Value.Should().Be(2);
            TraktCommentSortOrder.Oldest.ObjectName.Should().Be("oldest");
            TraktCommentSortOrder.Oldest.UriName.Should().Be("oldest");
            TraktCommentSortOrder.Oldest.DisplayName.Should().Be("Oldest");

            TraktCommentSortOrder.Likes.Value.Should().Be(4);
            TraktCommentSortOrder.Likes.ObjectName.Should().Be("likes");
            TraktCommentSortOrder.Likes.UriName.Should().Be("likes");
            TraktCommentSortOrder.Likes.DisplayName.Should().Be("Likes");

            TraktCommentSortOrder.Replies.Value.Should().Be(8);
            TraktCommentSortOrder.Replies.ObjectName.Should().Be("replies");
            TraktCommentSortOrder.Replies.UriName.Should().Be("replies");
            TraktCommentSortOrder.Replies.DisplayName.Should().Be("Replies");
        }
    }
}
