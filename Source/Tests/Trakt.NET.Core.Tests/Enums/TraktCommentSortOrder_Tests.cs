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
    }
}
