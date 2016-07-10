namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSearchIdTypeTests
    {
        [TestMethod]
        public void TestTraktSearchIdTypeHasMembers()
        {
            typeof(TraktSearchIdType).GetEnumNames().Should().HaveCount(6)
                                                    .And.Contain("Trakt", "ImDB", "TmDB", "TvDB", "TVRage", "Unspecified");
        }

        [TestMethod]
        public void TestTraktSearchIdTypeGetAsString()
        {
            TraktSearchIdType.Trakt.AsString().Should().Be("trakt");
            TraktSearchIdType.ImDB.AsString().Should().Be("imdb");
            TraktSearchIdType.TmDB.AsString().Should().Be("tmdb");
            TraktSearchIdType.TvDB.AsString().Should().Be("tvdb");
            TraktSearchIdType.TVRage.AsString().Should().Be("tvrage");
            TraktSearchIdType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
        }
    }
}
