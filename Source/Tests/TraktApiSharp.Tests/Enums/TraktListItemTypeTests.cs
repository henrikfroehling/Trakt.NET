namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktListItemTypeTests
    {
        [TestMethod]
        public void TestTraktListItemTypeHasMembers()
        {
            typeof(TraktListItemType).GetEnumNames().Should().HaveCount(6)
                                                    .And.Contain("Unspecified", "Movie", "Show", "Season", "Episode", "Person");
        }

        [TestMethod]
        public void TestTraktListItemTypeGetAsString()
        {
            TraktListItemType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktListItemType.Movie.AsString().Should().Be("movie");
            TraktListItemType.Show.AsString().Should().Be("show");
            TraktListItemType.Season.AsString().Should().Be("season");
            TraktListItemType.Episode.AsString().Should().Be("episode");
            TraktListItemType.Person.AsString().Should().Be("person");
        }

        [TestMethod]
        public void TestTraktListItemTypeGetAsStringUriParameter()
        {
            TraktListItemType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktListItemType.Movie.AsStringUriParameter().Should().Be("movies");
            TraktListItemType.Show.AsStringUriParameter().Should().Be("shows");
            TraktListItemType.Season.AsStringUriParameter().Should().Be("seasons");
            TraktListItemType.Episode.AsStringUriParameter().Should().Be("episodes");
            TraktListItemType.Person.AsStringUriParameter().Should().Be("people");
        }
    }
}
