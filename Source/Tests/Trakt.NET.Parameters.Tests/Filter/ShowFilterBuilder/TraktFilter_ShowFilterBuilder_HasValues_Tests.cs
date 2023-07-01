namespace TraktNet.Parameters.Tests.Filter
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Parameters;
    using Xunit;

    [TestCategory("Parameters.Filter")]
    public partial class TraktShowFilterBuilder_Tests
    {
        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_HasValues_Empty()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().Build();
            filter.HasValues.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithQuery_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithQuery("test query")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithYear_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithYear(2022)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithYears_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithYears(2020, 2022)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithGenres_Params_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithGenres("action", "drama")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithGenres_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithGenres(new List<string> { "action", "drama" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithLanguages_Params_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithLanguages("de", "en")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithLanguages_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithLanguages(new List<string> { "de", "en" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCountries_Params_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithCountries("de", "us")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCountries_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithCountries(new List<string> { "de", "us" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithRuntimes_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithRuntimes(90, 120)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStudios_Params_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithStudios("marvel-studios", "disney-studios")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStudios_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithStudios(new List<string> { "marvel-studios", "disney-studios" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithRatings_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithRatings(70, 90)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithVotes_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithVotes(7000, 9000)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCertifications_Params_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithCertifications("pg-13", "tv-pg")
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCertifications_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithCertifications(new List<string> { "pg-13", "tv-pg" })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithTMDBRatings_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithTMDBRatings(7, 9)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithTMDBVotes_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithTMDBVotes(7000, 9000)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithIMDBRatings_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithIMDBRatings(7, 9)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithIMDBVotes_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithIMDBVotes(7000, 9000)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithNetworkIds_Params_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithNetworkIds(53, 78)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithNetworkIds_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithNetworkIds(new List<uint> { 53, 78 })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStates_Params_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithStates(TraktShowStatus.Continuing, TraktShowStatus.InProduction)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStates_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithStates(new List<TraktShowStatus> { TraktShowStatus.Continuing, TraktShowStatus.InProduction })
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_HasValues_Year()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
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
                .WithNetworkIds(53, 78)
                .WithStates(TraktShowStatus.Continuing, TraktShowStatus.InProduction)
                .Build();

            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_HasValues_Years()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
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
                .WithNetworkIds(53, 78)
                .WithStates(TraktShowStatus.Continuing, TraktShowStatus.InProduction)
                .Build();

            filter.HasValues.Should().BeTrue();
        }
    }
}
