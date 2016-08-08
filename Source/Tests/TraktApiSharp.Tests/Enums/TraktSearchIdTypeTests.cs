namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSearchIdTypeTests
    {
        [TestMethod]
        public void TestTraktSearchIdTypeIsTraktEnumeration()
        {
            var enumeration = new TraktSearchIdType();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktSearchIdTypeGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSearchIdType>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktSearchIdType>() { TraktSearchIdType.Unspecified, TraktSearchIdType.Trakt,
                                                                       TraktSearchIdType.ImDB, TraktSearchIdType.TmDB,
                                                                       TraktSearchIdType.TvDB, TraktSearchIdType.TVRage });
        }
    }
}
