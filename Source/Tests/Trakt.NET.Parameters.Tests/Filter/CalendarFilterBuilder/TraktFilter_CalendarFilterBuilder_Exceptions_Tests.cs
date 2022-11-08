namespace TraktNet.Parameters.Tests.Filter
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Parameters;
    using Xunit;

    [TestCategory("Parameters.Filter")]
    public partial class TraktCalendarFilterBuilder_Tests
    {
        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithQuery_ArgumentNullException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithQuery(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithQuery_ArgumentException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithQuery(string.Empty)
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithYear_ArgumentOutOfRangeException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithYear(123)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewCalendarFilter()
                .WithYear(12345)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithYears_ArgumentOutOfRangeException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithYears(123, 1234)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewCalendarFilter()
                .WithYears(1234, 12345)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewCalendarFilter()
                .WithYears(2022, 2020)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithGenres_Params_ArgumentNullException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithGenres(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithGenres_ArgumentNullException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithGenres(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithLanguages_Params_ArgumentNullException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithLanguages(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithLanguages_ArgumentNullException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithLanguages(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithLanguages_Params_ArgumentOutOfRangeException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithLanguages("def")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewCalendarFilter()
                .WithLanguages("de", "eng")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithLanguages_ArgumentOutOfRangeException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithLanguages(new List<string> { "def" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewCalendarFilter()
                .WithLanguages(new List<string> { "de", "eng" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithCountries_Params_ArgumentNullException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithCountries(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithCountries_ArgumentNullException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithCountries(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithCountries_Params_ArgumentOutOfRangeException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithCountries("def")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewCalendarFilter()
                .WithCountries("de", "gbr")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithCountries_ArgumentOutOfRangeException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithCountries(new List<string> { "def" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewCalendarFilter()
                .WithCountries(new List<string> { "de", "gbr" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithRuntimes_ArgumentOutOfRangeException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithRuntimes(120, 90)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithStudios_Params_ArgumentNullException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithStudios(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithStudios_ArgumentNullException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithStudios(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithRatings_ArgumentOutOfRangeException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithRatings(90, 70)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
            
            act = () => TraktFilter.NewCalendarFilter()
                .WithRatings(101, 70)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
            
            act = () => TraktFilter.NewCalendarFilter()
                .WithRatings(90, 101)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_CalendarFilterBuilder_WithVotes_ArgumentOutOfRangeException()
        {
            Func<ITraktCalendarFilter> act = () => TraktFilter.NewCalendarFilter()
                .WithVotes(9000, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewCalendarFilter()
                .WithVotes(100001, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewCalendarFilter()
                .WithVotes(9000, 100001)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
