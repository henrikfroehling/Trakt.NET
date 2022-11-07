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
        public void Test_TraktFilter_CalendarFilterBuilder_GetParameters_Empty()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter().Build();
            filter.GetParameters().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithQuery_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithQuery("test query")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "query", "test query" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithYear_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithYear(2022)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "years", "2022" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithYears_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithYears(2020, 2022)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "years", "2020-2022" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithGenres_Params_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithGenres("action", "drama")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "genres", "action,drama" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithGenres_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithGenres(new List<string> { "action",  "drama"})
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "genres", "action,drama" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithLanguages_Params_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithLanguages("de", "en")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "languages", "de,en" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithLanguages_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithLanguages(new List<string> { "de", "en" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "languages", "de,en" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithCountries_Params_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithCountries("de", "us")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "countries", "de,us" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithCountries_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithCountries(new List<string> { "de", "us" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "countries", "de,us" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithRuntimes_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithRuntimes(90, 120)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "runtimes", "90-120" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithStudios_Params_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithStudios("marvel-studios", "disney-studios")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "studios", "marvel-studios,disney-studios" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithStudios_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithStudios(new List<string> { "marvel-studios", "disney-studios" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "studios", "marvel-studios,disney-studios" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithRatings_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithRatings(70, 90)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "ratings", "70-90" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithVotes_GetParameters()
        {
            ITraktCalendarFilter filter = TraktFilter.NewCalendarFilter()
                .WithVotes(7000, 9000)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "votes", "7000-9000" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_GetParameters_Year()
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

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(9);
            parameters.Should().Contain(new Dictionary<string, object> { { "query", "test query" },
                                                                         { "years", "2022" },
                                                                         { "genres", "action,drama" },
                                                                         { "languages", "de,en" },
                                                                         { "countries", "de,us" },
                                                                         { "runtimes", "90-120" },
                                                                         { "studios", "marvel-studios,disney-studios" },
                                                                         { "ratings", "70-90" },
                                                                         { "votes", "7000-9000" } });
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_GetParameters_Years()
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

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(9);
            parameters.Should().Contain(new Dictionary<string, object> { { "query", "test query" },
                                                                         { "years", "2020-2022" },
                                                                         { "genres", "action,drama" },
                                                                         { "languages", "de,en" },
                                                                         { "countries", "de,us" },
                                                                         { "runtimes", "90-120" },
                                                                         { "studios", "marvel-studios,disney-studios" },
                                                                         { "ratings", "70-90" },
                                                                         { "votes", "7000-9000" } });
        }
    }
}
