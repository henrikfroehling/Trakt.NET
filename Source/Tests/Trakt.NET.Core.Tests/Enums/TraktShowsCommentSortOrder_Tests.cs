namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktShowsCommentSortOrder_Tests
    {
        [Fact]
        public void Test_TraktShowsCommentSortOrder_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktShowsCommentSortOrder>();

            allValues.Should().NotBeNull().And.HaveCount(9);
            allValues.Should().Contain(new List<TraktShowsCommentSortOrder>() { TraktShowsCommentSortOrder.Unspecified, TraktShowsCommentSortOrder.Newest,
                                                                                TraktShowsCommentSortOrder.Oldest, TraktShowsCommentSortOrder.Likes,
                                                                                TraktShowsCommentSortOrder.Replies, TraktShowsCommentSortOrder.Highest,
                                                                                TraktShowsCommentSortOrder.Lowest, TraktShowsCommentSortOrder.Plays,
                                                                                TraktShowsCommentSortOrder.Watched });
        }

        [Fact]
        public void Test_TraktShowsCommentSortOrder_Properties()
        {
            TraktShowsCommentSortOrder.Newest.Value.Should().Be(1);
            TraktShowsCommentSortOrder.Newest.ObjectName.Should().Be("newest");
            TraktShowsCommentSortOrder.Newest.UriName.Should().Be("newest");
            TraktShowsCommentSortOrder.Newest.DisplayName.Should().Be("Newest");

            TraktShowsCommentSortOrder.Oldest.Value.Should().Be(2);
            TraktShowsCommentSortOrder.Oldest.ObjectName.Should().Be("oldest");
            TraktShowsCommentSortOrder.Oldest.UriName.Should().Be("oldest");
            TraktShowsCommentSortOrder.Oldest.DisplayName.Should().Be("Oldest");

            TraktShowsCommentSortOrder.Likes.Value.Should().Be(4);
            TraktShowsCommentSortOrder.Likes.ObjectName.Should().Be("likes");
            TraktShowsCommentSortOrder.Likes.UriName.Should().Be("likes");
            TraktShowsCommentSortOrder.Likes.DisplayName.Should().Be("Likes");

            TraktShowsCommentSortOrder.Replies.Value.Should().Be(8);
            TraktShowsCommentSortOrder.Replies.ObjectName.Should().Be("replies");
            TraktShowsCommentSortOrder.Replies.UriName.Should().Be("replies");
            TraktShowsCommentSortOrder.Replies.DisplayName.Should().Be("Replies");

            TraktShowsCommentSortOrder.Highest.Value.Should().Be(16);
            TraktShowsCommentSortOrder.Highest.ObjectName.Should().Be("highest");
            TraktShowsCommentSortOrder.Highest.UriName.Should().Be("highest");
            TraktShowsCommentSortOrder.Highest.DisplayName.Should().Be("Highest");

            TraktShowsCommentSortOrder.Lowest.Value.Should().Be(32);
            TraktShowsCommentSortOrder.Lowest.ObjectName.Should().Be("lowest");
            TraktShowsCommentSortOrder.Lowest.UriName.Should().Be("lowest");
            TraktShowsCommentSortOrder.Lowest.DisplayName.Should().Be("Lowest");

            TraktShowsCommentSortOrder.Plays.Value.Should().Be(64);
            TraktShowsCommentSortOrder.Plays.ObjectName.Should().Be("plays");
            TraktShowsCommentSortOrder.Plays.UriName.Should().Be("plays");
            TraktShowsCommentSortOrder.Plays.DisplayName.Should().Be("Plays");

            TraktShowsCommentSortOrder.Watched.Value.Should().Be(128);
            TraktShowsCommentSortOrder.Watched.ObjectName.Should().Be("watched");
            TraktShowsCommentSortOrder.Watched.UriName.Should().Be("watched");
            TraktShowsCommentSortOrder.Watched.DisplayName.Should().Be("Watched");
        }
    }
}
