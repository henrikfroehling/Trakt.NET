namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktListItemType_Tests
    {
        [Fact]
        public void Test_TraktListItemType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktListItemType>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktListItemType>() { TraktListItemType.Unspecified, TraktListItemType.Movie,
                                                                       TraktListItemType.Show, TraktListItemType.Season,
                                                                       TraktListItemType.Episode, TraktListItemType.Person });
        }

        [Fact]
        public void Test_TraktListItemType_OrOperator()
        {
            var nullResult = default(TraktListItemType);

            var result = nullResult | TraktListItemType.Movie;
            result.Should().BeNull();

            result = TraktListItemType.Movie | nullResult;
            result.Should().BeNull();

            result = nullResult | nullResult;
            result.Should().BeNull();

            // -----------------------------------------------------

            result = TraktListItemType.Movie | TraktListItemType.Unspecified;
            result.Should().Be(TraktListItemType.Unspecified);

            result = TraktListItemType.Unspecified | TraktListItemType.Movie;
            result.Should().Be(TraktListItemType.Unspecified);

            result = TraktListItemType.Unspecified | TraktListItemType.Unspecified;
            result.Should().Be(TraktListItemType.Unspecified);

            // -----------------------------------------------------

            result = TraktListItemType.Movie;

            result.Value.Should().Be(1);
            result.ObjectName.Should().Be("movie");
            result.UriName.Should().Be("movies");
            result.DisplayName.Should().Be("Movie");

            var oldResult = result;
            result = TraktListItemType.Movie | TraktListItemType.Show;

            oldResult = result;
            result.Value.Should().Be(oldResult.Value | TraktListItemType.Show.Value);
            result.ObjectName.Should().Be("movie,show");
            result.UriName.Should().Be("movies,shows");
            result.DisplayName.Should().Be("Movie, Show");

            oldResult = result;
            result |= TraktListItemType.Episode;

            result.Value.Should().Be(oldResult.Value | TraktListItemType.Episode.Value);
            result.ObjectName.Should().Be("movie,show,episode");
            result.UriName.Should().Be("movies,shows,episodes");
            result.DisplayName.Should().Be("Movie, Show, Episode");

            oldResult = result;
            result |= TraktListItemType.Person;

            result.Value.Should().Be(oldResult.Value | TraktListItemType.Person.Value);
            result.ObjectName.Should().Be("movie,show,episode,person");
            result.UriName.Should().Be("movies,shows,episodes,people");
            result.DisplayName.Should().Be("Movie, Show, Episode, Person");

            oldResult = result;
            result |= TraktListItemType.Season;

            result.Value.Should().Be(oldResult.Value | TraktListItemType.Season.Value);
            result.ObjectName.Should().Be("movie,show,episode,person,season");
            result.UriName.Should().Be("movies,shows,episodes,people,seasons");
            result.DisplayName.Should().Be("Movie, Show, Episode, Person, Season");
        }
    }
}
