namespace TraktNet.Parameters.Tests.Filter
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Parameters;
    using Xunit;

    [TestCategory("Parameters.Filter")]
    public class TraktShowFilter_Tests
    {
        [Fact]
        public void Test_TraktShowFilterBuilder_EmptyFilter()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().Build();

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
        public void Test_TraktShowFilterBuilder_HasValues()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().Build();
            filter.HasValues.Should().BeFalse();

            filter = TraktFilter.NewShowFilter().WithQuery("query").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewShowFilter().WithYear(2018).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewShowFilter().WithYears(2016, 2018).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewShowFilter().WithGenres("action", "drama").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewShowFilter().WithLanguages("de", "en").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewShowFilter().WithCountries("gb", "us").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewShowFilter().WithRuntimes(30, 180).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewShowFilter().WithRatings(60, 90).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewShowFilter().WithCertifications("pg-13", "nr").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewShowFilter().WithNetworks("abc", "fox").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilter.NewShowFilter().WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction).Build();
            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_GetParameters_With_Query()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithQuery("query").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" } });
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_GetParameters_With_Year()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithYear(2018).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", "2018" } });
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_GetParameters_With_Years()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithYears(2016, 2018).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", "2016-2018" } });
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_GetParameters_With_Years_Reversed()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithYears(2018, 2016).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", "2016-2018" } });
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_GetParameters_With_Genres()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithGenres("action", "drama").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "genres", "action,drama" } });
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_GetParameters_With_Languages()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithLanguages("de", "en").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "languages", "de,en" } });
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_GetParameters_With_Countries()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithCountries("gb", "us").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "countries", "gb,us" } });
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_GetParameters_With_Runtimes()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithRuntimes(30, 180).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "runtimes", "30-180" } });
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_GetParameters_With_Ratings()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithRatings(60, 90).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "ratings", "60-90" } });
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_GetParameters_With_Certifications()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithCertifications("pg-13", "nr").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "certifications", "pg-13,nr" } });
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_GetParameters_With_Networks()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithNetworks("abc", "fox").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "networks", "abc,fox" } });
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_GetParameters_With_States()
        {
            TraktShowStatus state1 = TraktShowStatus.ReturningSeries;
            TraktShowStatus state2 = TraktShowStatus.InProduction;

            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithStates(state1, state2).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "status", $"{state1.UriName},{state2.UriName}" } });
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_GetParameters()
        {
            TraktShowStatus state1 = TraktShowStatus.ReturningSeries;
            TraktShowStatus state2 = TraktShowStatus.InProduction;

            ITraktShowFilter filter = TraktFilter.NewShowFilter()
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
        public void Test_TraktShowFilterBuilder_ToString_With_Query()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithQuery("query").Build();
            filter.ToString().Should().Be("query=query");
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_ToString_With_Year()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithYear(2018).Build();
            filter.ToString().Should().Be("years=2018");
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_ToString_With_Years()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithYears(2016, 2018).Build();
            filter.ToString().Should().Be("years=2016-2018");
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_ToString_With_Years_Reversed()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithYears(2018, 2016).Build();
            filter.ToString().Should().Be("years=2016-2018");
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_ToString_With_Genres()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithGenres("action", "drama").Build();
            filter.ToString().Should().Be("genres=action,drama");
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_ToString_With_Languages()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithLanguages("de", "en").Build();
            filter.ToString().Should().Be("languages=de,en");
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_ToString_With_Countries()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithCountries("gb", "us").Build();
            filter.ToString().Should().Be("countries=gb,us");
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_ToString_With_Runtimes()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithRuntimes(30, 180).Build();
            filter.ToString().Should().Be("runtimes=30-180");
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_ToString_With_Ratings()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithRatings(60, 90).Build();
            filter.ToString().Should().Be("ratings=60-90");
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_ToString_With_Certifications()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithCertifications("pg-13", "nr").Build();
            filter.ToString().Should().Be("certifications=pg-13,nr");
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_ToString_With_Networks()
        {
            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithNetworks("abc", "fox").Build();
            filter.ToString().Should().Be("networks=abc,fox");
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_ToString_With_States()
        {
            TraktShowStatus state1 = TraktShowStatus.ReturningSeries;
            TraktShowStatus state2 = TraktShowStatus.InProduction;

            ITraktShowFilter filter = TraktFilter.NewShowFilter().WithStates(state1, state2).Build();
            filter.ToString().Should().Be($"status={state1.UriName},{state2.UriName}");
        }

        [Fact]
        public void Test_TraktShowFilterBuilder_ToString()
        {
            TraktShowStatus state1 = TraktShowStatus.ReturningSeries;
            TraktShowStatus state2 = TraktShowStatus.InProduction;

            ITraktShowFilter filter = TraktFilter.NewShowFilter()
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
