namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktTimePeriodTests
    {
        [TestMethod]
        public void TestTraktTimePeriodIsTraktEnumeration()
        {
            var enumeration = new TraktTimePeriod();
            enumeration.Should().BeAssignableTo<TraktEnumeration>();
        }

        [TestMethod]
        public void TestTraktTimePeriodGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktTimePeriod>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktTimePeriod>() { TraktTimePeriod.Unspecified, TraktTimePeriod.Weekly,
                                                                     TraktTimePeriod.Monthly, TraktTimePeriod.Yearly,
                                                                     TraktTimePeriod.All });
        }
    }
}
