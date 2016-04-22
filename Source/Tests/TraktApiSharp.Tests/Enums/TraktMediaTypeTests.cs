namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktMediaTypeTests
    {
        [TestMethod]
        public void TestTraktMediaTypeHasMembers()
        {
            typeof(TraktMediaType).GetEnumNames().Should().HaveCount(9)
                                                 .And.Contain("Unspecified", "Digital", "Bluray", "HD_DVD", "DVD", "VCD", "VHS", "BetaMax", "LaserDisc");
        }

        [TestMethod]
        public void TestTraktMediaTypeGetAsString()
        {
            TraktMediaType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktMediaType.Digital.AsString().Should().Be("digital");
            TraktMediaType.Bluray.AsString().Should().Be("bluray");
            TraktMediaType.HD_DVD.AsString().Should().Be("hddvd");
            TraktMediaType.DVD.AsString().Should().Be("dvd");
            TraktMediaType.VCD.AsString().Should().Be("vcd");
            TraktMediaType.VHS.AsString().Should().Be("vhs");
            TraktMediaType.BetaMax.AsString().Should().Be("betamax");
            TraktMediaType.LaserDisc.AsString().Should().Be("laserdisc");
        }
    }
}
