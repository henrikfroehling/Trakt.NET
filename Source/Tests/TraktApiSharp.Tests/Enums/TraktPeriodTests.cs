namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktPeriodTests
    {
        [TestMethod]
        public void TestTraktPeriodHasMembers()
        {
            typeof(TraktPeriod).GetEnumNames().Should().HaveCount(5)
                                              .And.Contain("Weekly", "Monthly", "Yearly", "All", "Unspecified");
        }

        [TestMethod]
        public void TestTraktPeriodGetAsString()
        {
            TraktPeriod.Weekly.AsString().Should().Be("weekly");
            TraktPeriod.Monthly.AsString().Should().Be("monthly");
            TraktPeriod.Yearly.AsString().Should().Be("yearly");
            TraktPeriod.All.AsString().Should().Be("all");
            TraktPeriod.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
        }
    }
}
