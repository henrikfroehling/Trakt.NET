namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSyncWatchlistItemTypeTests
    {
        [TestMethod]
        public void TestTraktSyncWatchlistItemTypeHasMembers()
        {
            typeof(TraktSyncWatchlistItemType).GetEnumNames().Should().HaveCount(5)
                                                             .And.Contain("Unspecified", "Movie", "Show", "Season", "Episode");
        }

        [TestMethod]
        public void TestTraktSyncWatchlistItemTypeGetAsString()
        {
            TraktSyncWatchlistItemType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktSyncWatchlistItemType.Movie.AsString().Should().Be("movie");
            TraktSyncWatchlistItemType.Show.AsString().Should().Be("show");
            TraktSyncWatchlistItemType.Season.AsString().Should().Be("season");
            TraktSyncWatchlistItemType.Episode.AsString().Should().Be("episode");
        }

        [TestMethod]
        public void TestTraktSyncWatchlistItemTypeGetAsStringUriParameter()
        {
            TraktSyncWatchlistItemType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktSyncWatchlistItemType.Movie.AsStringUriParameter().Should().Be("movies");
            TraktSyncWatchlistItemType.Show.AsStringUriParameter().Should().Be("shows");
            TraktSyncWatchlistItemType.Season.AsStringUriParameter().Should().Be("seasons");
            TraktSyncWatchlistItemType.Episode.AsStringUriParameter().Should().Be("episodes");
        }
    }
}
