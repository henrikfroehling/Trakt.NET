namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
