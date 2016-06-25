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
            typeof(TraktSyncItemType).GetEnumNames().Should().HaveCount(5)
                                                             .And.Contain("Unspecified", "Movie", "Show", "Season", "Episode");
        }

        [TestMethod]
        public void TestTraktSyncWatchlistItemTypeGetAsString()
        {
            TraktSyncItemType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktSyncItemType.Movie.AsString().Should().Be("movie");
            TraktSyncItemType.Show.AsString().Should().Be("show");
            TraktSyncItemType.Season.AsString().Should().Be("season");
            TraktSyncItemType.Episode.AsString().Should().Be("episode");
        }

        [TestMethod]
        public void TestTraktSyncWatchlistItemTypeGetAsStringUriParameter()
        {
            TraktSyncItemType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktSyncItemType.Movie.AsStringUriParameter().Should().Be("movies");
            TraktSyncItemType.Show.AsStringUriParameter().Should().Be("shows");
            TraktSyncItemType.Season.AsStringUriParameter().Should().Be("seasons");
            TraktSyncItemType.Episode.AsStringUriParameter().Should().Be("episodes");
        }
    }
}
