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
        public void Test_TraktFilter_MovieFilterBuilder_ToString_Empty()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter().Build();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithQuery_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithQuery("test query")
                .Build();

            filter.ToString().Should().Be("query=test query");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithYear_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithYear(2022)
                .Build();

            filter.ToString().Should().Be("years=2022");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithYears_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithYears(2020, 2022)
                .Build();

            filter.ToString().Should().Be("years=2020-2022");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithGenres_Params_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithGenres("action", "drama")
                .Build();

            filter.ToString().Should().Be("genres=action,drama");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithGenres_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithGenres(new List<string> { "action", "drama" })
                .Build();

            filter.ToString().Should().Be("genres=action,drama");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithLanguages_Params_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithLanguages("de", "en")
                .Build();

            filter.ToString().Should().Be("languages=de,en");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithLanguages_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithLanguages(new List<string> { "de", "en" })
                .Build();

            filter.ToString().Should().Be("languages=de,en");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCountries_Params_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithCountries("de", "us")
                .Build();

            filter.ToString().Should().Be("countries=de,us");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCountries_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithCountries(new List<string> { "de", "us" })
                .Build();

            filter.ToString().Should().Be("countries=de,us");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithRuntimes_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithRuntimes(90, 120)
                .Build();

            filter.ToString().Should().Be("runtimes=90-120");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithStudios_Params_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithStudios("marvel-studios", "disney-studios")
                .Build();

            filter.ToString().Should().Be("studios=marvel-studios,disney-studios");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithStudios_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithStudios(new List<string> { "marvel-studios", "disney-studios" })
                .Build();

            filter.ToString().Should().Be("studios=marvel-studios,disney-studios");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithRatings_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithRatings(70, 90)
                .Build();

            filter.ToString().Should().Be("ratings=70-90");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithVotes_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithVotes(7000, 9000)
                .Build();

            filter.ToString().Should().Be("votes=7000-9000");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCertifications_Params_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithCertifications("pg-13", "tv-pg")
                .Build();

            filter.ToString().Should().Be("certifications=pg-13,tv-pg");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCertifications_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithCertifications(new List<string> { "pg-13", "tv-pg" })
                .Build();

            filter.ToString().Should().Be("certifications=pg-13,tv-pg");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithTMDBRatings_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithTMDBRatings(7, 9)
                .Build();

            filter.ToString().Should().Be("tmdb_ratings=7.0-9.0");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithTMDBVotes_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithTMDBVotes(7000, 9000)
                .Build();

            filter.ToString().Should().Be("tmdb_votes=7000-9000");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithIMDBRatings_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithIMDBRatings(7, 9)
                .Build();

            filter.ToString().Should().Be("imdb_ratings=7.0-9.0");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithIMDBVotes_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithIMDBVotes(7000, 9000)
                .Build();

            filter.ToString().Should().Be("imdb_votes=7000-9000");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithRottenTomatoesMeter_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithRottenTomatoesMeter(70, 90)
                .Build();

            filter.ToString().Should().Be("rt_meters=70.0-90.0");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithMetascores_ToString()
        {
            ITraktMovieFilter filter = TraktFilter.NewMovieFilter()
                .WithMetascores(70, 90)
                .Build();

            filter.ToString().Should().Be("metascores=70.0-90.0");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_ToString_Year()
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
                                          "&imdb_votes=7000-9000" +
                                          "&rt_meters=70.0-90.0" +
                                          "&metascores=70.0-90.0");
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_ToString_Years()
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
                                          "&imdb_votes=7000-9000" +
                                          "&rt_meters=70.0-90.0" +
                                          "&metascores=70.0-90.0");
        }
    }
}
