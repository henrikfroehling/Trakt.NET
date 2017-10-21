namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktListSortOrderTests
    {
        [TestMethod]
        public void TestTraktListSortOrderGetAll()
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
