namespace TraktNet.Parameters.Tests.Filter
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Parameters;
    using Xunit;

    [TestCategory("Parameters.Filter")]
    public partial class TraktSearchFilterBuilder_Tests
    {
        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_HasValues_Empty()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter().Build();
            filter.HasValues.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithQuery_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithQuery("test query")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithYear_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithYear(2022)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithYears_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithYears(2020, 2022)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithGenres_Params_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithGenres("action", "drama")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithGenres_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithGenres(new List<string> { "action", "drama" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithLanguages_Params_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithLanguages("de", "en")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithLanguages_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithLanguages(new List<string> { "de", "en" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCountries_Params_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithCountries("de", "us")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCountries_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithCountries(new List<string> { "de", "us" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithRuntimes_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithRuntimes(90, 120)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithStudios_Params_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithStudios("marvel-studios", "disney-studios")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithStudios_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithStudios(new List<string> { "marvel-studios", "disney-studios" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithRatings_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithRatings(70, 90)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithVotes_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithVotes(7000, 9000)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCertifications_Params_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithCertifications("pg-13", "tv-pg")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCertifications_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithCertifications(new List<string> { "pg-13", "tv-pg" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithTMDBRatings_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithTMDBRatings(7, 9)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithTMDBVotes_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithTMDBVotes(7000, 9000)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithIMDBRatings_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithIMDBRatings(7, 9)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithIMDBVotes_HasValues()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithIMDBVotes(7000, 9000)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_HasValues_Year()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
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
                .WithCertifications("pg-13", "tv-pg")
                .WithTMDBRatings(7, 9)
                .WithTMDBVotes(7000, 9000)
                .WithIMDBRatings(7, 9)
                .WithIMDBVotes(7000, 9000)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_HasValues_Years()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
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
                .WithCertifications("pg-13", "tv-pg")
                .WithTMDBRatings(7, 9)
                .WithTMDBVotes(7000, 9000)
                .WithIMDBRatings(7, 9)
                .WithIMDBVotes(7000, 9000)
                .Build();

            filter.HasValues.Should().BeTrue();
        }
    }
}
