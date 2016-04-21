namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSyncRatingsItemTypeTests
    {
        [TestMethod]
        public void TestTraktSyncRatingsItemTypeHasMembers()
        {
            typeof(TraktSyncRatingsItemType).GetEnumNames().Should().HaveCount(6)
                                                           .And.Contain("Unspecified", "Movie", "Show", "Season", "Episode", "All");
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeGetAsString()
        {
            TraktSyncRatingsItemType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktSyncRatingsItemType.All.AsString().Should().NotBeNull().And.BeEmpty();
            TraktSyncRatingsItemType.Movie.AsString().Should().Be("movie");
            TraktSyncRatingsItemType.Show.AsString().Should().Be("show");
            TraktSyncRatingsItemType.Season.AsString().Should().Be("season");
            TraktSyncRatingsItemType.Episode.AsString().Should().Be("episode");
        }

        [TestMethod]
        public void TestTraktSyncRatingsItemTypeGetAsStringUriParameter()
        {
            TraktSyncRatingsItemType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktSyncRatingsItemType.All.AsStringUriParameter().Should().Be("all");
            TraktSyncRatingsItemType.Movie.AsStringUriParameter().Should().Be("movies");
            TraktSyncRatingsItemType.Show.AsStringUriParameter().Should().Be("shows");
            TraktSyncRatingsItemType.Season.AsStringUriParameter().Should().Be("seasons");
            TraktSyncRatingsItemType.Episode.AsStringUriParameter().Should().Be("episodes");
        }
    }
}
