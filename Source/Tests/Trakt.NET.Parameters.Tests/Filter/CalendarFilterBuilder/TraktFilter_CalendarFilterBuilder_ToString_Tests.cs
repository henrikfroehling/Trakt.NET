namespace TraktNet.Parameters.Tests.Filter
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Parameters;
    using Xunit;

    [TestCategory("Parameters.Filter")]
    public partial class TraktCalendarFilterBuilder_Tests
    {
        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_ToString_Empty()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().Build();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithQuery_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithQuery("test query")
                .Build();

            filter.ToString().Should().Be("query=test query");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithYear_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithYear(2022)
                .Build();

            filter.ToString().Should().Be("years=2022");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithYears_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithYears(2020, 2022)
                .Build();

            filter.ToString().Should().Be("years=2020-2022");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithGenres_Params_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithGenres("action", "drama")
                .Build();

            filter.ToString().Should().Be("genres=action,drama");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithGenres_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithGenres(new List<string> { "action", "drama" })
                .Build();

            filter.ToString().Should().Be("genres=action,drama");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithLanguages_Params_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithLanguages("de", "en")
                .Build();

            filter.ToString().Should().Be("languages=de,en");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithLanguages_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithLanguages(new List<string> { "de", "en" })
                .Build();

            filter.ToString().Should().Be("languages=de,en");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithCountries_Params_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithCountries("de", "us")
                .Build();

            filter.ToString().Should().Be("countries=de,us");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithCountries_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithCountries(new List<string> { "de", "us" })
                .Build();

            filter.ToString().Should().Be("countries=de,us");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithRuntimes_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithRuntimes(90, 120)
                .Build();

            filter.ToString().Should().Be("runtimes=90-120");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithStudios_Params_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithStudios("marvel-studios", "disney-studios")
                .Build();

            filter.ToString().Should().Be("studios=marvel-studios,disney-studios");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithStudios_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithStudios(new List<string> { "marvel-studios", "disney-studios" })
                .Build();

            filter.ToString().Should().Be("studios=marvel-studios,disney-studios");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithRatings_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithRatings(70, 90)
                .Build();

            filter.ToString().Should().Be("ratings=70-90");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithVotes_ToString()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithVotes(7000, 9000)
                .Build();

            filter.ToString().Should().Be("votes=7000-9000");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_ToString_Year()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithQuery("test query")
                .WithYears(2020, 2022)
                .WithYear(2022) // should overwrite WithYears()
                .WithGenres("action", "drama")
                .WithLanguages("de", "en")
                .WithCountries("de", "us")
                .WithRuntimes(90, 120)
                .WithStudios("marvel-studios", "disney-studios")
                .WithRatings(70, 90)
                .WithVotes(7000, 9000)
                .Build();

            filter.ToString().Should().Be("query=test query" +
                                          "&years=2022" +
                                          "&genres=action,drama" +
                                          "&languages=de,en" +
                                          "&countries=de,us" +
                                          "&runtimes=90-120" +
                                          "&studios=marvel-studios,disney-studios" +
                                          "&ratings=70-90" +
                                          "&votes=7000-9000");
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_ToString_Years()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithQuery("test query")
                .WithYear(2022)
                .WithYears(2020, 2022) // should overwrite WithYear()
                .WithGenres("action", "drama")
                .WithLanguages("de", "en")
                .WithCountries("de", "us")
                .WithRuntimes(90, 120)
                .WithStudios("marvel-studios", "disney-studios")
                .WithRatings(70, 90)
                .WithVotes(7000, 9000)
                .Build();

            filter.ToString().Should().Be("query=test query" +
                                          "&years=2020-2022" +
                                          "&genres=action,drama" +
                                          "&languages=de,en" +
                                          "&countries=de,us" +
                                          "&runtimes=90-120" +
                                          "&studios=marvel-studios,disney-studios" +
                                          "&ratings=70-90" +
                                          "&votes=7000-9000");
        }
    }
}
