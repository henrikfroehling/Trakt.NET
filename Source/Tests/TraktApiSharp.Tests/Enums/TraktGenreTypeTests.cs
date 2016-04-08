namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktGenreTypeTests
    {
        [TestMethod]
        public void TestTraktGenreTypeHasMembers()
        {
            typeof(TraktGenreType).GetEnumNames().Should().HaveCount(3)
                                                 .And.Contain("Shows", "Movies", "Unspecified");
        }

        [TestMethod]
        public void TestTraktGenreTypeGetAsString()
        {
            TraktGenreType.Shows.AsString().Should().Be("shows");
            TraktGenreType.Movies.AsString().Should().Be("movies");
            TraktGenreType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
        }
    }
}
