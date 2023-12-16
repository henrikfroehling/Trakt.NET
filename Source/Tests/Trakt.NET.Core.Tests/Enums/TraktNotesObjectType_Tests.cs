namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktNotesObjectType_Tests
    {
        [Fact]
        public void Test_TraktNotesObjectType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktNotesObjectType>();

            allValues.Should().NotBeNull().And.HaveCount(10);
            allValues.Should().Contain(new List<TraktNotesObjectType>() { TraktNotesObjectType.Unspecified, TraktNotesObjectType.All,
                                                                          TraktNotesObjectType.Movie, TraktNotesObjectType.Show,
                                                                          TraktNotesObjectType.Season, TraktNotesObjectType.Episode,
                                                                          TraktNotesObjectType.Person, TraktNotesObjectType.History,
                                                                          TraktNotesObjectType.Collection, TraktNotesObjectType.Rating});
        }

        [Fact]
        public void Test_TraktNotesObjectType_Properties()
        {
            TraktNotesObjectType.All.Value.Should().Be(1);
            TraktNotesObjectType.All.ObjectName.Should().Be("all");
            TraktNotesObjectType.All.UriName.Should().Be("all");
            TraktNotesObjectType.All.DisplayName.Should().Be("All");

            TraktNotesObjectType.Movie.Value.Should().Be(2);
            TraktNotesObjectType.Movie.ObjectName.Should().Be("movie");
            TraktNotesObjectType.Movie.UriName.Should().Be("movie");
            TraktNotesObjectType.Movie.DisplayName.Should().Be("Movie");

            TraktNotesObjectType.Show.Value.Should().Be(4);
            TraktNotesObjectType.Show.ObjectName.Should().Be("show");
            TraktNotesObjectType.Show.UriName.Should().Be("show");
            TraktNotesObjectType.Show.DisplayName.Should().Be("Show");

            TraktNotesObjectType.Season.Value.Should().Be(8);
            TraktNotesObjectType.Season.ObjectName.Should().Be("season");
            TraktNotesObjectType.Season.UriName.Should().Be("season");
            TraktNotesObjectType.Season.DisplayName.Should().Be("Season");

            TraktNotesObjectType.Episode.Value.Should().Be(16);
            TraktNotesObjectType.Episode.ObjectName.Should().Be("episode");
            TraktNotesObjectType.Episode.UriName.Should().Be("episode");
            TraktNotesObjectType.Episode.DisplayName.Should().Be("Episode");

            TraktNotesObjectType.Person.Value.Should().Be(32);
            TraktNotesObjectType.Person.ObjectName.Should().Be("person");
            TraktNotesObjectType.Person.UriName.Should().Be("person");
            TraktNotesObjectType.Person.DisplayName.Should().Be("Person");

            TraktNotesObjectType.History.Value.Should().Be(64);
            TraktNotesObjectType.History.ObjectName.Should().Be("history");
            TraktNotesObjectType.History.UriName.Should().Be("history");
            TraktNotesObjectType.History.DisplayName.Should().Be("History");

            TraktNotesObjectType.Collection.Value.Should().Be(128);
            TraktNotesObjectType.Collection.ObjectName.Should().Be("collection");
            TraktNotesObjectType.Collection.UriName.Should().Be("collection");
            TraktNotesObjectType.Collection.DisplayName.Should().Be("Collection");

            TraktNotesObjectType.Rating.Value.Should().Be(256);
            TraktNotesObjectType.Rating.ObjectName.Should().Be("rating");
            TraktNotesObjectType.Rating.UriName.Should().Be("rating");
            TraktNotesObjectType.Rating.DisplayName.Should().Be("Rating");
        }

        [Fact]
        public void Test_TraktNotesObjectType_ToPlural()
        {
            TraktNotesObjectType.ToPlural(TraktNotesObjectType.Unspecified).Should().BeEmpty();
            TraktNotesObjectType.ToPlural(TraktNotesObjectType.All).Should().Be("all");
            TraktNotesObjectType.ToPlural(TraktNotesObjectType.Movie).Should().Be("movies");
            TraktNotesObjectType.ToPlural(TraktNotesObjectType.Show).Should().Be("shows");
            TraktNotesObjectType.ToPlural(TraktNotesObjectType.Season).Should().Be("seasons");
            TraktNotesObjectType.ToPlural(TraktNotesObjectType.Episode).Should().Be("episodes");
            TraktNotesObjectType.ToPlural(TraktNotesObjectType.Person).Should().Be("people");
            TraktNotesObjectType.ToPlural(TraktNotesObjectType.History).Should().Be("history");
            TraktNotesObjectType.ToPlural(TraktNotesObjectType.Collection).Should().Be("collection");
            TraktNotesObjectType.ToPlural(TraktNotesObjectType.Rating).Should().Be("ratings");
        }
    }
}
