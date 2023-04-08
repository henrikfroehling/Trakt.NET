namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktSortBy_Tests
    {
        [Fact]
        public void Test_TraktSortBy_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSortBy>();

            allValues.Should().NotBeNull().And.HaveCount(13);
            allValues.Should().Contain(new List<TraktSortBy>() { TraktSortBy.Unspecified, TraktSortBy.Rank,
                                                                 TraktSortBy.Added, TraktSortBy.Title,
                                                                 TraktSortBy.Released, TraktSortBy.Runtime,
                                                                 TraktSortBy.Popularity, TraktSortBy.Percentage,
                                                                 TraktSortBy.Votes, TraktSortBy.MyRating,
                                                                 TraktSortBy.Random, TraktSortBy.Watched,
                                                                 TraktSortBy.Collected });
        }
    }
}
