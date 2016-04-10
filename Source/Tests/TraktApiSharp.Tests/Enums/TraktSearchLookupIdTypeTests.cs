namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSearchLookupIdTypeTests
    {
        [TestMethod]
        public void TestTraktSearchLookupIdTypeHasMembers()
        {
            typeof(TraktSearchLookupIdType).GetEnumNames().Should().HaveCount(8)
                                                          .And.Contain("TraktMovie", "TraktShow", "TraktEpisode", "ImDB", "TmDB", "TvDB", "TVRage", "Unspecified");
        }

        [TestMethod]
        public void TestTraktSearchLookupIdTypeGetAsString()
        {
            TraktSearchLookupIdType.TraktMovie.AsString().Should().Be("trakt-movie");
            TraktSearchLookupIdType.TraktShow.AsString().Should().Be("trakt-show");
            TraktSearchLookupIdType.TraktEpisode.AsString().Should().Be("trakt-episode");
            TraktSearchLookupIdType.ImDB.AsString().Should().Be("imdb");
            TraktSearchLookupIdType.TmDB.AsString().Should().Be("tmdb");
            TraktSearchLookupIdType.TvDB.AsString().Should().Be("tvdb");
            TraktSearchLookupIdType.TVRage.AsString().Should().Be("tvrage");
            TraktSearchLookupIdType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
        }
    }
}
