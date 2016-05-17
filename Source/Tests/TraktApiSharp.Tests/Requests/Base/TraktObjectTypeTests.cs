namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktObjectTypeTests
    {
        [TestMethod]
        public void TestTraktObjectTypeHasMembers()
        {
            typeof(TraktObjectType).GetEnumNames().Should().HaveCount(7)
                                                  .And.Contain("Unspecified", "Movie", "Show", "Season", "Episode", "List", "All");
        }

        [TestMethod]
        public void TestTraktObjectTypeGetAsString()
        {
            TraktObjectType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktObjectType.All.AsString().Should().NotBeNull().And.BeEmpty();
            TraktObjectType.Movie.AsString().Should().Be("movie");
            TraktObjectType.Show.AsString().Should().Be("show");
            TraktObjectType.Season.AsString().Should().Be("season");
            TraktObjectType.Episode.AsString().Should().Be("episode");
            TraktObjectType.List.AsString().Should().Be("list");
        }

        [TestMethod]
        public void TestTraktObjectTypeGetAsStringUriParameter()
        {
            TraktObjectType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktObjectType.All.AsStringUriParameter().Should().Be("all");
            TraktObjectType.Movie.AsStringUriParameter().Should().Be("movies");
            TraktObjectType.Show.AsStringUriParameter().Should().Be("shows");
            TraktObjectType.Season.AsStringUriParameter().Should().Be("seasons");
            TraktObjectType.Episode.AsStringUriParameter().Should().Be("episodes");
            TraktObjectType.List.AsStringUriParameter().Should().Be("lists");
        }
    }
}
