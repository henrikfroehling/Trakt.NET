namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktWatchlistSortOrder_Tests
    {
        [Fact]
        public void Test_TraktWatchlistSortOrder_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktWatchlistSortOrder>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktWatchlistSortOrder>() { TraktWatchlistSortOrder.Unspecified, TraktWatchlistSortOrder.Rank,
                                                                             TraktWatchlistSortOrder.Added, TraktWatchlistSortOrder.Released,
                                                                             TraktWatchlistSortOrder.Title });
        }
    }
}
