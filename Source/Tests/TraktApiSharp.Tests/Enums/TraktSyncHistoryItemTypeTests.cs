namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSyncHistoryItemTypeTests
    {
        [TestMethod]
        public void TestTraktSyncHistoryItemTypeHasMembers()
        {
            typeof(TraktSyncHistoryItemType).GetEnumNames().Should().HaveCount(5)
                                                           .And.Contain("Unspecified", "Movie", "Show", "Season", "Episode");
        }

        [TestMethod]
        public void TestTraktSyncHistoryItemTypeGetAsString()
        {
            TraktSyncHistoryItemType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktSyncHistoryItemType.Movie.AsString().Should().Be("movie");
            TraktSyncHistoryItemType.Show.AsString().Should().Be("show");
            TraktSyncHistoryItemType.Season.AsString().Should().Be("season");
            TraktSyncHistoryItemType.Episode.AsString().Should().Be("episode");
        }

        [TestMethod]
        public void TestTraktSyncHistoryItemTypeGetAsStringUriParameter()
        {
            TraktSyncHistoryItemType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktSyncHistoryItemType.Movie.AsStringUriParameter().Should().Be("movies");
            TraktSyncHistoryItemType.Show.AsStringUriParameter().Should().Be("shows");
            TraktSyncHistoryItemType.Season.AsStringUriParameter().Should().Be("seasons");
            TraktSyncHistoryItemType.Episode.AsStringUriParameter().Should().Be("episodes");
        }
    }
}
