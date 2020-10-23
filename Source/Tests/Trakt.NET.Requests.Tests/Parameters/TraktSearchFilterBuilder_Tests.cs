namespace TraktNet.Requests.Tests.Parameters
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Requests.Parameters.Filter;
    using Xunit;

    [Category("Requests.Parameters")]
    public class TraktSearchFilter_Tests
    {
        [Fact]
        public void Test_TraktSearchFilterBuilder_EmptyFilter()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.Build();

            filter.Query.Should().BeNull();
            filter.Year.Should().BeNull();
            filter.Years.Should().BeNull();
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.Certifications.Should().BeNull();
            filter.Networks.Should().BeNull();
            filter.States.Should().BeNull();
            filter.HasValues.Should().BeFalse();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
            filter.GetParameters().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_HasValues()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.Build();
            filter.HasValues.Should().BeFalse();

            filter = TraktFilterDirectory.SearchFilter.WithQuery("query").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.SearchFilter.WithYear(2018).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.SearchFilter.WithYears(2016, 2018).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.SearchFilter.WithGenres("action", "drama").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.SearchFilter.WithLanguages("de", "en").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.SearchFilter.WithCountries("gb", "us").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.SearchFilter.WithRuntimes(30, 180).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.SearchFilter.WithRatings(60, 90).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.SearchFilter.WithCertifications("pg-13", "nr").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.SearchFilter.WithNetworks("abc", "fox").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.SearchFilter.WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction).Build();
            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_GetParameters_With_Query()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithQuery("query").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" } });
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_GetParameters_With_Year()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithYear(2018).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", "2018" } });
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_GetParameters_With_Years()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithYears(2016, 2018).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", "2016-2018" } });
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_GetParameters_With_Years_Reversed()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithYears(2018, 2016).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", "2016-2018" } });
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_GetParameters_With_Genres()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithGenres("action", "drama").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "genres", "action,drama" } });
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_GetParameters_With_Languages()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithLanguages("de", "en").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "languages", "de,en" } });
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_GetParameters_With_Countries()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithCountries("gb", "us").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "countries", "gb,us" } });
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_GetParameters_With_Runtimes()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithRuntimes(30, 180).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "runtimes", "30-180" } });
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_GetParameters_With_Ratings()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithRatings(60, 90).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "ratings", "60-90" } });
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_GetParameters_With_Certifications()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithCertifications("pg-13", "nr").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "certifications", "pg-13,nr" } });
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_GetParameters_With_Networks()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithNetworks("abc", "fox").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "networks", "abc,fox" } });
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_GetParameters_With_States()
        {
            TraktShowStatus state1 = TraktShowStatus.ReturningSeries;
            TraktShowStatus state2 = TraktShowStatus.InProduction;

            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithStates(state1, state2).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "status", $"{state1.UriName},{state2.UriName}" } });
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_GetParameters()
        {
            TraktShowStatus state1 = TraktShowStatus.ReturningSeries;
            TraktShowStatus state2 = TraktShowStatus.InProduction;

            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter
                .WithQuery("query")
                .WithYears(2016, 2018)
                .WithGenres("action", "drama")
                .WithLanguages("de", "en")
                .WithCountries("gb", "us")
                .WithRuntimes(30, 180)
                .WithRatings(60, 90)
                .WithCertifications("pg-13", "nr")
                .WithNetworks("abc", "fox")
                .WithStates(state1, state2)
                .Build();

            filter.GetParameters().Should().NotBeNull().And.HaveCount(10);

            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" },
                                                                                       { "years", "2016-2018" },
                                                                                       { "genres", "action,drama" },
                                                                                       { "languages", "de,en" },
                                                                                       { "countries", "gb,us" },
                                                                                       { "runtimes", "30-180" },
                                                                                       { "ratings", "60-90" },
                                                                                       { "certifications", "pg-13,nr" },
                                                                                       { "networks", "abc,fox" },
                                                                                       { "status", $"{state1.UriName},{state2.UriName}" } });
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_ToString_With_Query()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithQuery("query").Build();
            filter.ToString().Should().Be("query=query");
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_ToString_With_Year()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithYear(2018).Build();
            filter.ToString().Should().Be("years=2018");
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_ToString_With_Years()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithYears(2016, 2018).Build();
            filter.ToString().Should().Be("years=2016-2018");
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_ToString_With_Years_Reversed()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithYears(2018, 2016).Build();
            filter.ToString().Should().Be("years=2016-2018");
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_ToString_With_Genres()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithGenres("action", "drama").Build();
            filter.ToString().Should().Be("genres=action,drama");
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_ToString_With_Languages()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithLanguages("de", "en").Build();
            filter.ToString().Should().Be("languages=de,en");
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_ToString_With_Countries()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithCountries("gb", "us").Build();
            filter.ToString().Should().Be("countries=gb,us");
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_ToString_With_Runtimes()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithRuntimes(30, 180).Build();
            filter.ToString().Should().Be("runtimes=30-180");
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_ToString_With_Ratings()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithRatings(60, 90).Build();
            filter.ToString().Should().Be("ratings=60-90");
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_ToString_With_Certifications()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithCertifications("pg-13", "nr").Build();
            filter.ToString().Should().Be("certifications=pg-13,nr");
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_ToString_With_Networks()
        {
            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithNetworks("abc", "fox").Build();
            filter.ToString().Should().Be("networks=abc,fox");
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_ToString_With_States()
        {
            TraktShowStatus state1 = TraktShowStatus.ReturningSeries;
            TraktShowStatus state2 = TraktShowStatus.InProduction;

            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter.WithStates(state1, state2).Build();
            filter.ToString().Should().Be($"status={state1.UriName},{state2.UriName}");
        }

        [Fact]
        public void Test_TraktSearchFilterBuilder_ToString()
        {
            TraktShowStatus state1 = TraktShowStatus.ReturningSeries;
            TraktShowStatus state2 = TraktShowStatus.InProduction;

            ITraktSearchFilter filter = TraktFilterDirectory.SearchFilter
                .WithQuery("query")
                .WithYears(2016, 2018)
                .WithGenres("action", "drama")
                .WithLanguages("de", "en")
                .WithCountries("gb", "us")
                .WithRuntimes(30, 180)
                .WithRatings(60, 90)
                .WithCertifications("pg-13", "nr")
                .WithNetworks("abc", "fox")
                .WithStates(state1, state2)
                .Build();

            filter.ToString().Should().Be("query=query&years=2016-2018&genres=action,drama&languages=de,en" +
                                          "&countries=gb,us&runtimes=30-180&ratings=60-90&certifications=pg-13,nr" +
                                          $"&networks=abc,fox&status={state1.UriName},{state2.UriName}");
        }
    }
}
