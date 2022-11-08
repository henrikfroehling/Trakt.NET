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
        public void Test_TraktFilter_SearchFilterBuilder_GetParameters_Empty()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter().Build();
            filter.GetParameters().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithQuery_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithQuery("test query")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "query", "test query" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithYear_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithYear(2022)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "years", "2022" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithYears_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithYears(2020, 2022)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "years", "2020-2022" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithGenres_Params_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithGenres("action", "drama")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "genres", "action,drama" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithGenres_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithGenres(new List<string> { "action", "drama" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "genres", "action,drama" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithLanguages_Params_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithLanguages("de", "en")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "languages", "de,en" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithLanguages_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithLanguages(new List<string> { "de", "en" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "languages", "de,en" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCountries_Params_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithCountries("de", "us")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "countries", "de,us" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCountries_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithCountries(new List<string> { "de", "us" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "countries", "de,us" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithRuntimes_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithRuntimes(90, 120)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "runtimes", "90-120" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithStudios_Params_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithStudios("marvel-studios", "disney-studios")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "studios", "marvel-studios,disney-studios" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithStudios_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithStudios(new List<string> { "marvel-studios", "disney-studios" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "studios", "marvel-studios,disney-studios" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithRatings_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithRatings(70, 90)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "ratings", "70-90" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithVotes_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithVotes(7000, 9000)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "votes", "7000-9000" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCertifications_Params_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithCertifications("pg-13", "tv-pg")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "certifications", "pg-13,tv-pg" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCertifications_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithCertifications(new List<string> { "pg-13", "tv-pg" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "certifications", "pg-13,tv-pg" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithTMDBRatings_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithTMDBRatings(7, 9)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "tmdb_ratings", "7.0-9.0" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithTMDBVotes_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithTMDBVotes(7000, 9000)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "tmdb_votes", "7000-9000" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithIMDBRatings_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithIMDBRatings(7, 9)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "imdb_ratings", "7.0-9.0" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithIMDBVotes_GetParameters()
        {
            ITraktSearchFilter filter = TraktFilter.NewSearchFilter()
                .WithIMDBVotes(7000, 9000)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "imdb_votes", "7000-9000" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_GetParameters_Year()
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

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(14);
            parameters.Should().Contain(new Dictionary<string, object> { { "query", "test query" },
                                                                         { "years", "2022" },
                                                                         { "genres", "action,drama" },
                                                                         { "languages", "de,en" },
                                                                         { "countries", "de,us" },
                                                                         { "runtimes", "90-120" },
                                                                         { "studios", "marvel-studios,disney-studios" },
                                                                         { "ratings", "70-90" },
                                                                         { "votes", "7000-9000" },
                                                                         { "certifications", "pg-13,tv-pg" },
                                                                         { "tmdb_ratings", "7.0-9.0" },
                                                                         { "tmdb_votes", "7000-9000" },
                                                                         { "imdb_ratings", "7.0-9.0" },
                                                                         { "imdb_votes", "7000-9000" } });
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_GetParameters_Years()
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

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(14);
            parameters.Should().Contain(new Dictionary<string, object> { { "query", "test query" },
                                                                         { "years", "2020-2022" },
                                                                         { "genres", "action,drama" },
                                                                         { "languages", "de,en" },
                                                                         { "countries", "de,us" },
                                                                         { "runtimes", "90-120" },
                                                                         { "studios", "marvel-studios,disney-studios" },
                                                                         { "ratings", "70-90" },
                                                                         { "votes", "7000-9000" },
                                                                         { "certifications", "pg-13,tv-pg" },
                                                                         { "tmdb_ratings", "7.0-9.0" },
                                                                         { "tmdb_votes", "7000-9000" },
                                                                         { "imdb_ratings", "7.0-9.0" },
                                                                         { "imdb_votes", "7000-9000" } });
        }
    }
}
