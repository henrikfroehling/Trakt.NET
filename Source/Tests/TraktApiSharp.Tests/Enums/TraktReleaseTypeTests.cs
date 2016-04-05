namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktReleaseTypeTests
    {
        [TestMethod]
        public void TestHasMembers()
        {
            typeof(TraktReleaseType).GetEnumNames().Should().HaveCount(7)
                                                   .And.Contain("Unknown", "Premiere", "Limited", "Theatrical", "Digital", "Physical", "Tv");
        }

        [TestMethod]
        public void TestGetAsString()
        {
            TraktReleaseType.Unknown.AsString().Should().Be("unknown");
            TraktReleaseType.Premiere.AsString().Should().Be("premiere");
            TraktReleaseType.Limited.AsString().Should().Be("limited");
            TraktReleaseType.Theatrical.AsString().Should().Be("theatrical");
            TraktReleaseType.Digital.AsString().Should().Be("digital");
            TraktReleaseType.Physical.AsString().Should().Be("physical");
            TraktReleaseType.Tv.AsString().Should().Be("tv");
        }
    }
}
