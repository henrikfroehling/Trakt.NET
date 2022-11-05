namespace TraktNet.Requests.Tests.Parameters
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Parameters;
    using Xunit;

    [TestCategory("Requests.Parameters")]
    public class TraktCalendarFilterBuilder_Tests
    {
        [Fact]
        public void Test_TraktCalendarFilterBuilder_EmptyFilter()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().Build();

            filter.Query.Should().BeNull();
            filter.Year.Should().BeNull();
            filter.Years.Should().BeNull();
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.HasValues.Should().BeFalse();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
            filter.GetParameters().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().Build();
            filter.HasValues.Should().BeFalse();

            filter = TraktFilter.NewCalendarFilter().WithQuery("query").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewCalendarFilter().WithYear(2018).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewCalendarFilter().WithYears(2016, 2018).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewCalendarFilter().WithGenres("action", "drama").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewCalendarFilter().WithLanguages("de", "en").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewCalendarFilter().WithCountries("gb", "us").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewCalendarFilter().WithRuntimes(30, 180).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewCalendarFilter().WithRatings(60, 90).Build();
            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_GetParameters_With_Query()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithQuery("query").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" } });
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_GetParameters_With_Year()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithYear(2018).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", "2018" } });
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_GetParameters_With_Years()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithYears(2016, 2018).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", "2016-2018" } });
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_GetParameters_With_Years_Reversed()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithYears(2018, 2016).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", "2016-2018" } });
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_GetParameters_With_Genres()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithGenres("action", "drama").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "genres", "action,drama" } });
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_GetParameters_With_Languages()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithLanguages("de", "en").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "languages", "de,en" } });
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_GetParameters_With_Countries()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithCountries("gb", "us").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "countries", "gb,us" } });
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_GetParameters_With_Runtimes()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithRuntimes(30, 180).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "runtimes", "30-180" } });
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_GetParameters_With_Ratings()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithRatings(60, 90).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "ratings", "60-90" } });
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithQuery("query")
                .WithYears(2016, 2018)
                .WithGenres("action", "drama")
                .WithLanguages("de", "en")
                .WithCountries("gb", "us")
                .WithRuntimes(30, 180)
                .WithRatings(60, 90)
                .Build();

            filter.GetParameters().Should().NotBeNull().And.HaveCount(7);

            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" },
                                                                                       { "years", "2016-2018" },
                                                                                       { "genres", "action,drama" },
                                                                                       { "languages", "de,en" },
                                                                                       { "countries", "gb,us" },
                                                                                       { "runtimes", "30-180" },
                                                                                       { "ratings", "60-90" } });
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_ToString_With_Query()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithQuery("query").Build();
            filter.ToString().Should().Be("query=query");
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_ToString_With_Year()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithYear(2018).Build();
            filter.ToString().Should().Be("years=2018");
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_ToString_With_Years()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithYears(2016, 2018).Build();
            filter.ToString().Should().Be("years=2016-2018");
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_ToString_With_Years_Reversed()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithYears(2018, 2016).Build();
            filter.ToString().Should().Be("years=2016-2018");
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_ToString_With_Genres()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithGenres("action", "drama").Build();
            filter.ToString().Should().Be("genres=action,drama");
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_ToString_With_Languages()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithLanguages("de", "en").Build();
            filter.ToString().Should().Be("languages=de,en");
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_ToString_With_Countries()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithCountries("gb", "us").Build();
            filter.ToString().Should().Be("countries=gb,us");
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_ToString_With_Runtimes()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithRuntimes(30, 180).Build();
            filter.ToString().Should().Be("runtimes=30-180");
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_ToString_With_Ratings()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().WithRatings(60, 90).Build();
            filter.ToString().Should().Be("ratings=60-90");
        }

        [Fact]
        public void Test_TraktCalendarFilterBuilder_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithQuery("query")
                .WithYears(2016, 2018)
                .WithGenres("action", "drama")
                .WithLanguages("de", "en")
                .WithCountries("gb", "us")
                .WithRuntimes(30, 180)
                .WithRatings(60, 90)
                .Build();

            filter.ToString().Should().Be("query=query&years=2016-2018&genres=action,drama&languages=de,en" +
                                          "&countries=gb,us&runtimes=30-180&ratings=60-90");
        }
    }
}
