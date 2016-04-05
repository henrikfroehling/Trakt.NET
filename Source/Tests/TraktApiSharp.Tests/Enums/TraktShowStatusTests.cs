namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktShowStatusTests
    {
        [TestMethod]
        public void TestHasMembers()
        {
            typeof(TraktShowStatus).GetEnumNames().Should().HaveCount(5)
                                                  .And.Contain("Unspecified", "ReturningSeries", "InProduction", "Canceled", "Ended");
        }

        [TestMethod]
        public void TestGetAsString()
        {
            TraktShowStatus.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktShowStatus.ReturningSeries.AsString().Should().Be("returning series");
            TraktShowStatus.InProduction.AsString().Should().Be("in production");
            TraktShowStatus.Canceled.AsString().Should().Be("canceled");
            TraktShowStatus.Ended.AsString().Should().Be("ended");
        }
    }
}
