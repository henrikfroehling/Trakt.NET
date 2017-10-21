namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktListTypeTests
    {
        [TestMethod]
        public void TestTraktListTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktListType>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktListType>() { TraktListType.Unspecified, TraktListType.Personal,
                                                                   TraktListType.Official, TraktListType.Watchlist,
                                                                   TraktListType.All });
        }
    }
}
