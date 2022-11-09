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
        public void Test_TraktFilter_ShowFilterBuilder_GetParameters_Empty()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().Build();
            filter.GetParameters().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithQuery_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithQuery("test query")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "query", "test query" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithYear_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithYear(2022)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "years", "2022" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithYears_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithYears(2020, 2022)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "years", "2020-2022" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithGenres_Params_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithGenres("action", "drama")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "genres", "action,drama" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithGenres_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithGenres(new List<string> { "action", "drama" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "genres", "action,drama" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithLanguages_Params_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithLanguages("de", "en")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "languages", "de,en" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithLanguages_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithLanguages(new List<string> { "de", "en" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "languages", "de,en" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCountries_Params_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithCountries("de", "us")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "countries", "de,us" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCountries_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithCountries(new List<string> { "de", "us" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "countries", "de,us" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithRuntimes_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithRuntimes(90, 120)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "runtimes", "90-120" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStudios_Params_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithStudios("marvel-studios", "disney-studios")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "studios", "marvel-studios,disney-studios" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStudios_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithStudios(new List<string> { "marvel-studios", "disney-studios" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "studios", "marvel-studios,disney-studios" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithRatings_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithRatings(70, 90)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "ratings", "70-90" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithVotes_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithVotes(7000, 9000)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "votes", "7000-9000" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCertifications_Params_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithCertifications("pg-13", "tv-pg")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "certifications", "pg-13,tv-pg" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCertifications_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithCertifications(new List<string> { "pg-13", "tv-pg" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "certifications", "pg-13,tv-pg" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithTMDBRatings_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithTMDBRatings(7, 9)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "tmdb_ratings", "7.0-9.0" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithTMDBVotes_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithTMDBVotes(7000, 9000)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "tmdb_votes", "7000-9000" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithIMDBRatings_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithIMDBRatings(7, 9)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "imdb_ratings", "7.0-9.0" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithIMDBVotes_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithIMDBVotes(7000, 9000)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "imdb_votes", "7000-9000" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithNetworks_Params_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithNetworks("HBO", "Netflix")
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "networks", "HBO,Netflix" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithNetworks_GetParameters()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithNetworks(new List<string> { "HBO", "Netflix" })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "networks", "HBO,Netflix" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStates_Params_GetParameters()
        {
            var state1 = TraktShowStatus.Continuing;
            var state2 = TraktShowStatus.InProduction;

            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithStates(state1, state2)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "status", $"{state1.UriName},{state2.UriName}" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStates_GetParameters()
        {
            var state1 = TraktShowStatus.Continuing;
            var state2 = TraktShowStatus.InProduction;

            ITraktShowFilter filter = TraktFilter.NewShowFilter()
                .WithStates(new List<TraktShowStatus> { state1, state2 })
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(1);
            parameters.Should().Contain(new Dictionary<string, object> { { "status", $"{state1.UriName},{state2.UriName}" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_GetParameters_Year()
        {
            var state1 = TraktShowStatus.Continuing;
            var state2 = TraktShowStatus.InProduction;

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
                .WithNetworks("HBO", "Netflix")
                .WithStates(state1, state2)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(16);
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
                                                                         { "imdb_votes", "7000-9000" },
                                                                         { "networks", "HBO,Netflix" },
                                                                         { "status", $"{state1.UriName},{state2.UriName}" } });
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_GetParameters_Years()
        {
            var state1 = TraktShowStatus.Continuing;
            var state2 = TraktShowStatus.InProduction;

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
                .WithNetworks("HBO", "Netflix")
                .WithStates(state1, state2)
                .Build();

            IDictionary<string, object> parameters = filter.GetParameters();

            parameters.Should().NotBeNull().And.HaveCount(16);
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
                                                                         { "imdb_votes", "7000-9000" },
                                                                         { "networks", "HBO,Netflix" },
                                                                         { "status", $"{state1.UriName},{state2.UriName}" } });
        }
    }
}
