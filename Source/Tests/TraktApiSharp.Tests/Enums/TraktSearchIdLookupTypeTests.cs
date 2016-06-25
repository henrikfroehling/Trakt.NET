namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSearchIdLookupTypeTests
    {
        [TestMethod]
        public void TestTraktSearchIdLookupTypeHasMembers()
        {
            typeof(TraktSearchIdLookupType).GetEnumNames().Should().HaveCount(8)
                                                          .And.Contain("TraktMovie", "TraktShow", "TraktEpisode", "ImDB", "TmDB", "TvDB", "TVRage", "Unspecified");
        }

        [TestMethod]
        public void TestTraktSearchIdLookupTypeGetAsString()
        {
            TraktSearchIdLookupType.TraktMovie.AsString().Should().Be("trakt-movie");
            TraktSearchIdLookupType.TraktShow.AsString().Should().Be("trakt-show");
            TraktSearchIdLookupType.TraktEpisode.AsString().Should().Be("trakt-episode");
            TraktSearchIdLookupType.ImDB.AsString().Should().Be("imdb");
            TraktSearchIdLookupType.TmDB.AsString().Should().Be("tmdb");
            TraktSearchIdLookupType.TvDB.AsString().Should().Be("tvdb");
            TraktSearchIdLookupType.TVRage.AsString().Should().Be("tvrage");
            TraktSearchIdLookupType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
        }
    }
}
