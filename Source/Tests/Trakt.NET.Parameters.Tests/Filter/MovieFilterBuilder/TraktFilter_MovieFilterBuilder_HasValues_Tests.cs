namespace TraktNet.Parameters.Tests.Filter
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Parameters;
    using Xunit;

    [TestCategory("Parameters.Filter")]
    public partial class TraktMovieFilterBuilder_Tests
    {
        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_HasValues_Empty()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter().Build();
            filter.HasValues.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithQuery_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithQuery("test query")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithYear_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithYear(2022)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithYears_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithYears(2020, 2022)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithGenres_Params_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithGenres("action", "drama")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithGenres_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithGenres(new List<string> { "action", "drama" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithLanguages_Params_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithLanguages("de", "en")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithLanguages_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithLanguages(new List<string> { "de", "en" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCountries_Params_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithCountries("de", "us")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCountries_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithCountries(new List<string> { "de", "us" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithRuntimes_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithRuntimes(90, 120)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithStudios_Params_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithStudios("marvel-studios", "disney-studios")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithStudios_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithStudios(new List<string> { "marvel-studios", "disney-studios" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithRatings_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithRatings(70, 90)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithVotes_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithVotes(7000, 9000)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCertifications_Params_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithCertifications("pg-13", "tv-pg")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCertifications_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithCertifications(new List<string> { "pg-13", "tv-pg" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithTMDBRatings_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithTMDBRatings(7, 9)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithTMDBVotes_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithTMDBVotes(7000, 9000)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithIMDBRatings_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithIMDBRatings(7, 9)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithIMDBVotes_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithIMDBVotes(7000, 9000)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithRottenTomatoesMeter_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithRottenTomatoesMeter(70, 90)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithMetascores_HasValues()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithMetascores(70, 90)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_HasValues_Year()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
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
                .WithRottenTomatoesMeter(70, 90)
                .WithMetascores(70, 90)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_HasValues_Years()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
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
                .WithRottenTomatoesMeter(70, 90)
                .WithMetascores(70, 90)
                .Build();

            filter.HasValues.Should().BeTrue();
        }
    }
}
