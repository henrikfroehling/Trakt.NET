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
        public void Test_TraktFilter_CalendarFilterBuilder_HasValues_Empty()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().Build();
            filter.HasValues.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithQuery_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithQuery("test query")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithYear_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithYear(2022)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithYears_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithYears(2020, 2022)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithGenres_Params_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithGenres("action", "drama")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithGenres_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithGenres(new List<string> { "action", "drama" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithLanguages_Params_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithLanguages("de", "en")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithLanguages_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithLanguages(new List<string> { "de", "en" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithCountries_Params_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithCountries("de", "us")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithCountries_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithCountries(new List<string> { "de", "us" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithRuntimes_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithRuntimes(90, 120)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithStudios_Params_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithStudios("marvel-studios", "disney-studios")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithStudios_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithStudios(new List<string> { "marvel-studios", "disney-studios" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithRatings_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithRatings(70, 90)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithVotes_HasValues()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithVotes(7000, 9000)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_HasValues_Year()
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

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_HasValues_Years()
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

            filter.HasValues.Should().BeTrue();
        }
    }
}
