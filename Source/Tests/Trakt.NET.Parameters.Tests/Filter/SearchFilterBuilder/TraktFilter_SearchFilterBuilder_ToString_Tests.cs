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
        public void Test_TraktFilter_SearchFilterBuilder_ToString_Empty()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter().Build();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithQuery_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithQuery("test query")
                .Build();

            filter.ToString().Should().Be("query=test query");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithYear_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithYear(2022)
                .Build();

            filter.ToString().Should().Be("years=2022");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithYears_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithYears(2020, 2022)
                .Build();

            filter.ToString().Should().Be("years=2020-2022");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithGenres_Params_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithGenres("action", "drama")
                .Build();

            filter.ToString().Should().Be("genres=action,drama");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithGenres_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithGenres(new List<string> { "action", "drama" })
                .Build();

            filter.ToString().Should().Be("genres=action,drama");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithLanguages_Params_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithLanguages("de", "en")
                .Build();

            filter.ToString().Should().Be("languages=de,en");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithLanguages_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithLanguages(new List<string> { "de", "en" })
                .Build();

            filter.ToString().Should().Be("languages=de,en");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCountries_Params_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithCountries("de", "us")
                .Build();

            filter.ToString().Should().Be("countries=de,us");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCountries_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithCountries(new List<string> { "de", "us" })
                .Build();

            filter.ToString().Should().Be("countries=de,us");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithRuntimes_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithRuntimes(90, 120)
                .Build();

            filter.ToString().Should().Be("runtimes=90-120");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithStudios_Params_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithStudios("marvel-studios", "disney-studios")
                .Build();

            filter.ToString().Should().Be("studios=marvel-studios,disney-studios");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithStudios_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithStudios(new List<string> { "marvel-studios", "disney-studios" })
                .Build();

            filter.ToString().Should().Be("studios=marvel-studios,disney-studios");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithRatings_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithRatings(70, 90)
                .Build();

            filter.ToString().Should().Be("ratings=70-90");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithVotes_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithVotes(7000, 9000)
                .Build();

            filter.ToString().Should().Be("votes=7000-9000");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCertifications_Params_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithCertifications("pg-13", "tv-pg")
                .Build();

            filter.ToString().Should().Be("certifications=pg-13,tv-pg");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCertifications_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithCertifications(new List<string> { "pg-13", "tv-pg" })
                .Build();

            filter.ToString().Should().Be("certifications=pg-13,tv-pg");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithTMDBRatings_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithTMDBRatings(7, 9)
                .Build();

            filter.ToString().Should().Be("tmdb_ratings=7.0-9.0");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithTMDBVotes_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithTMDBVotes(7000, 9000)
                .Build();

            filter.ToString().Should().Be("tmdb_votes=7000-9000");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithIMDBRatings_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithIMDBRatings(7, 9)
                .Build();

            filter.ToString().Should().Be("imdb_ratings=7.0-9.0");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithIMDBVotes_ToString()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithIMDBVotes(7000, 9000)
                .Build();

            filter.ToString().Should().Be("imdb_votes=7000-9000");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_ToString_Year()
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

            filter.ToString().Should().Be("query=test query" +
                                          "&years=2022" +
                                          "&genres=action,drama" +
                                          "&languages=de,en" +
                                          "&countries=de,us" +
                                          "&runtimes=90-120" +
                                          "&studios=marvel-studios,disney-studios" +
                                          "&certifications=pg-13,tv-pg" +
                                          "&ratings=70-90" +
                                          "&votes=7000-9000" +
                                          "&tmdb_ratings=7.0-9.0" +
                                          "&tmdb_votes=7000-9000" +
                                          "&imdb_ratings=7.0-9.0" +
                                          "&imdb_votes=7000-9000");
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_ToString_Years()
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

            filter.ToString().Should().Be("query=test query" +
                                          "&years=2020-2022" +
                                          "&genres=action,drama" +
                                          "&languages=de,en" +
                                          "&countries=de,us" +
                                          "&runtimes=90-120" +
                                          "&studios=marvel-studios,disney-studios" +
                                          "&certifications=pg-13,tv-pg" +
                                          "&ratings=70-90" +
                                          "&votes=7000-9000" +
                                          "&tmdb_ratings=7.0-9.0" +
                                          "&tmdb_votes=7000-9000" +
                                          "&imdb_ratings=7.0-9.0" +
                                          "&imdb_votes=7000-9000");
        }
    }
}
