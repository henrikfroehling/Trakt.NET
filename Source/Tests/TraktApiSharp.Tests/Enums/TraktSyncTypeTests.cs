namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktSyncTypeTests
    {
        [TestMethod]
        public void TestTraktSyncTypeHasMembers()
        {
            typeof(TraktSyncType).GetEnumNames().Should().HaveCount(3)
                                                         .And.Contain("Unspecified", "Movie", "Episode");
        }

        [TestMethod]
        public void TestTraktSyncTypeGetAsString()
        {
            TraktSyncType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktSyncType.Movie.AsString().Should().Be("movie");
            TraktSyncType.Episode.AsString().Should().Be("episode");
        }

        [TestMethod]
        public void TestTraktSyncTypeGetAsStringUriParameter()
        {
            TraktSyncType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktSyncType.Movie.AsStringUriParameter().Should().Be("movies");
            TraktSyncType.Episode.AsStringUriParameter().Should().Be("episodes");
        }
    }
}
