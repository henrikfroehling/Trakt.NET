namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktGenreTypeTests
    {
        [TestMethod]
        public void TestHasMembers()
        {
            typeof(TraktGenreType).GetEnumNames().Should().HaveCount(2)
                                                 .And.Contain("Shows", "Movies");
        }

        [TestMethod]
        public void TestGetAsString()
        {
            TraktGenreType.Shows.AsString().Should().Be("shows");
            TraktGenreType.Movies.AsString().Should().Be("movies");
        }
    }
}
