namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktListSortOrder_Tests
    {
        [Fact]
        public void Test_TraktListSortOrder_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktListSortOrder>();

            allValues.Should().NotBeNull().And.HaveCount(7);
            allValues.Should().Contain(new List<TraktListSortOrder>() { TraktListSortOrder.Unspecified, TraktListSortOrder.Popular,
                                                                        TraktListSortOrder.Likes, TraktListSortOrder.Comments,
                                                                        TraktListSortOrder.Items, TraktListSortOrder.Added,
                                                                        TraktListSortOrder.Updated });
        }
    }
}
