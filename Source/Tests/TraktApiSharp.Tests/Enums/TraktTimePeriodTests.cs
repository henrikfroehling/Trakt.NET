namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktTimePeriodTests
    {
        [TestMethod]
        public void TestTraktTimePeriodHasMembers()
        {
            typeof(TraktTimePeriod).GetEnumNames().Should().HaveCount(5)
                                                  .And.Contain("Weekly", "Monthly", "Yearly", "All", "Unspecified");
        }

        [TestMethod]
        public void TestTraktTimePeriodGetAsString()
        {
            TraktTimePeriod.Weekly.AsString().Should().Be("weekly");
            TraktTimePeriod.Monthly.AsString().Should().Be("monthly");
            TraktTimePeriod.Yearly.AsString().Should().Be("yearly");
            TraktTimePeriod.All.AsString().Should().Be("all");
            TraktTimePeriod.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
        }
    }
}
