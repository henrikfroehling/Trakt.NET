namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktHiddenItemTypeTests
    {
        [TestMethod]
        public void TestHasMembers()
        {
            typeof(TraktHiddenItemType).GetEnumNames().Should().HaveCount(3)
                                                      .And.Contain("Movie", "Show", "Season");
        }

        [TestMethod]
        public void TestGetAsString()
        {
            TraktHiddenItemType.Movie.AsString().Should().Be("movie");
            TraktHiddenItemType.Show.AsString().Should().Be("show");
            TraktHiddenItemType.Season.AsString().Should().Be("season");
        }
    }
}
