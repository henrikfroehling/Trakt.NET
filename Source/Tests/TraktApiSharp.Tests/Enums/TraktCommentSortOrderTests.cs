namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktCommentSortOrderTests
    {
        [TestMethod]
        public void TestTraktCommentSortOrderIsTraktEnumeration()
        {
            var enumeration = new TraktCommentSortOrder();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktCommentSortOrderGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktCommentSortOrder>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktCommentSortOrder>() { TraktCommentSortOrder.Unspecified, TraktCommentSortOrder.Newest,
                                                                           TraktCommentSortOrder.Oldest, TraktCommentSortOrder.Likes,
                                                                           TraktCommentSortOrder.Replies });
        }
    }
}
