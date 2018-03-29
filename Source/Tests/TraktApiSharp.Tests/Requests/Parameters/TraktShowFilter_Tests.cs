namespace TraktApiSharp.Tests.Requests.Parameters
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Utils;
    using Xunit;

    [Category("Requests.Parameters")]
    public class TraktShowFilter_Tests
    {
        [Fact]
        public void Test_TraktShowFilter_DefaultConstructor()
        {
            var filter = new TraktShowFilter();

            filter.Query.Should().BeNull();
            filter.StartYear.Should().NotHaveValue();
            filter.EndYear.Should().NotHaveValue();
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.Certifications.Should().BeNull();
            filter.Networks.Should().BeNull();
            filter.States.Should().BeNull();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktShowFilter_Constructor()
        {
            var filter = new TraktShowFilter("query", 2010, 2016, new string[] { "action", "drama" },
                                             new string[] { "de", "en" },
                                             new string[] { "gb", "us" },
                                             new Range<int>(40, 100), new Range<int>(70, 90),
                                             new string[] { "cert1", "cert2" },
                                             new string[] { "network1", "network2" },
                                             new TraktShowStatus[] { TraktShowStatus.Ended, TraktShowStatus.InProduction });

            filter.Query.Should().Be("query");
            filter.StartYear.Should().Be(2010);
            filter.EndYear.Should().Be(2016);

            filter.Genres.Should().NotBeNull().And.HaveCount(2);
            filter.Languages.Should().NotBeNull().And.HaveCount(2);
            filter.Countries.Should().NotBeNull().And.HaveCount(2);

            filter.Runtimes.Should().NotBeNull();
            filter.Runtimes.Value.Begin.Should().Be(40);
            filter.Runtimes.Value.End.Should().Be(100);

            filter.Ratings.Should().NotBeNull();
            filter.Ratings.Value.Begin.Should().Be(70);
            filter.Ratings.Value.End.Should().Be(90);

            filter.Certifications.Should().NotBeNull().And.HaveCount(2);
            filter.Networks.Should().NotBeNull().And.HaveCount(2);
            filter.States.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktShowFilter_AddCertifications()
        {
            var filter = new TraktShowFilter();

            filter.AddCertifications(null);
            filter.Certifications.Should().BeNull();

            filter.AddCertifications(null, "cert1");
            filter.Certifications.Should().NotBeNull().And.HaveCount(1);

            filter.AddCertifications("cert1", "cert2", "cert3");
            filter.Certifications.Should().NotBeNull().And.HaveCount(4);

            filter.AddCertifications("cert4");
            filter.Certifications.Should().NotBeNull().And.HaveCount(5);

            filter.AddCertifications(null);
            filter.Certifications.Should().NotBeNull().And.HaveCount(5);

            filter.AddCertifications("cert5", "cert6");
            filter.Certifications.Should().NotBeNull().And.HaveCount(7);
        }

        [Fact]
        public void Test_TraktShowFilter_WithCertifications()
        {
            var filter = new TraktShowFilter();

            filter.WithCertifications(null);
            filter.Certifications.Should().BeNull();

            filter.WithCertifications(null, "cert1");
            filter.Certifications.Should().NotBeNull().And.HaveCount(1);

            filter.AddCertifications("cert1", "cert2");
            filter.Certifications.Should().NotBeNull().And.HaveCount(3);

            filter.WithCertifications(null);
            filter.Certifications.Should().BeNull();

            filter.WithCertifications(null, "cert1");
            filter.Certifications.Should().NotBeNull().And.HaveCount(1);

            filter.WithCertifications("cert1", "cert2");
            filter.Certifications.Should().NotBeNull().And.HaveCount(2);

            filter.WithCertifications("cert1", "cert2", "cert3", "cert4");
            filter.Certifications.Should().NotBeNull().And.HaveCount(4);

            filter.WithCertifications("cert5");
            filter.Certifications.Should().NotBeNull().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktShowFilter_AddNetworks()
        {
            var filter = new TraktShowFilter();

            filter.AddNetworks(null);
            filter.Networks.Should().BeNull();

            filter.AddNetworks(null, "network1");
            filter.Networks.Should().NotBeNull().And.HaveCount(1);

            filter.AddNetworks("network1", "network2", "network3");
            filter.Networks.Should().NotBeNull().And.HaveCount(4);

            filter.AddNetworks("network4");
            filter.Networks.Should().NotBeNull().And.HaveCount(5);

            filter.AddNetworks(null);
            filter.Networks.Should().NotBeNull().And.HaveCount(5);

            filter.AddNetworks("network5", "network6");
            filter.Networks.Should().NotBeNull().And.HaveCount(7);
        }

        [Fact]
        public void Test_TraktShowFilter_WithNetworks()
        {
            var filter = new TraktShowFilter();

            filter.WithNetworks(null);
            filter.Networks.Should().BeNull();

            filter.WithNetworks(null, "network1");
            filter.Networks.Should().NotBeNull().And.HaveCount(1);

            filter.AddNetworks("network1", "network2");
            filter.Networks.Should().NotBeNull().And.HaveCount(3);

            filter.WithNetworks(null);
            filter.Networks.Should().BeNull();

            filter.WithNetworks(null, "network1");
            filter.Networks.Should().NotBeNull().And.HaveCount(1);

            filter.WithNetworks("network1", "network2");
            filter.Networks.Should().NotBeNull().And.HaveCount(2);

            filter.WithNetworks("network1", "network2", "network3", "network4");
            filter.Networks.Should().NotBeNull().And.HaveCount(4);

            filter.WithNetworks("network5");
            filter.Networks.Should().NotBeNull().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktShowFilter_AddStates()
        {
            var filter = new TraktShowFilter();

            filter.AddStates(TraktShowStatus.Unspecified);
            filter.States.Should().BeNull();

            var state1 = TraktShowStatus.ReturningSeries;
            var state2 = TraktShowStatus.InProduction;
            var state3 = TraktShowStatus.Ended;
            var state4 = TraktShowStatus.Canceled;

            Action act = () => filter.AddStates(state1, TraktShowStatus.Unspecified);
            act.Should().Throw<ArgumentException>();

            act = () => filter.AddStates(state1, state2, TraktShowStatus.Unspecified, state3);
            act.Should().Throw<ArgumentException>();

            filter.AddStates(TraktShowStatus.Unspecified, state1);
            filter.States.Should().NotBeNull().And.HaveCount(1);

            filter.AddStates(state1, state2, state3);
            filter.States.Should().NotBeNull().And.HaveCount(4);

            filter.AddStates(state4);
            filter.States.Should().NotBeNull().And.HaveCount(5);

            filter.AddStates(TraktShowStatus.Unspecified);
            filter.States.Should().NotBeNull().And.HaveCount(5);

            filter.AddStates(state1, state2);
            filter.States.Should().NotBeNull().And.HaveCount(7);
        }

        [Fact]
        public void Test_TraktShowFilter_WithStates()
        {
            var filter = new TraktShowFilter();

            filter.WithStates(TraktShowStatus.Unspecified);
            filter.States.Should().BeNull();

            var state1 = TraktShowStatus.ReturningSeries;
            var state2 = TraktShowStatus.InProduction;
            var state3 = TraktShowStatus.Ended;
            var state4 = TraktShowStatus.Canceled;

            Action act = () => filter.WithStates(state1, TraktShowStatus.Unspecified);
            act.Should().Throw<ArgumentException>();

            act = () => filter.WithStates(state1, state2, TraktShowStatus.Unspecified, state3);
            act.Should().Throw<ArgumentException>();

            filter.WithStates(TraktShowStatus.Unspecified, state1);
            filter.States.Should().NotBeNull().And.HaveCount(1);

            filter.AddStates(state1, state2);
            filter.States.Should().NotBeNull().And.HaveCount(3);

            filter.WithStates(TraktShowStatus.Unspecified);
            filter.States.Should().BeNull();

            filter.WithStates(TraktShowStatus.Unspecified, state3);
            filter.States.Should().NotBeNull().And.HaveCount(1);

            filter.WithStates(state1, state2);
            filter.States.Should().NotBeNull().And.HaveCount(2);

            filter.WithStates(state1, state2, state3, state4);
            filter.States.Should().NotBeNull().And.HaveCount(4);

            filter.WithStates(state1);
            filter.States.Should().NotBeNull().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktShowFilter_HasValues()
        {
            var filter = new TraktShowFilter();

            filter.HasValues.Should().BeFalse();

            filter.WithQuery("query");
            filter.Query.Should().Be("query");
            filter.HasValues.Should().BeTrue();

            filter.Clear();
            filter.HasValues.Should().BeFalse();

            filter.WithStartYear(2010);
            filter.StartYear.Should().Be(2010);
            filter.HasValues.Should().BeTrue();

            filter.Clear();
            filter.HasValues.Should().BeFalse();

            filter.WithEndYear(2016);
            filter.EndYear.Should().Be(2016);
            filter.HasValues.Should().BeTrue();

            filter.Clear();
            filter.HasValues.Should().BeFalse();

            filter.WithGenres("action", "drama");
            filter.Genres.Should().NotBeNull().And.HaveCount(2);
            filter.HasValues.Should().BeTrue();

            filter.Clear();
            filter.HasValues.Should().BeFalse();

            filter.WithLanguages("de", "en");
            filter.Languages.Should().NotBeNull().And.HaveCount(2);
            filter.HasValues.Should().BeTrue();

            filter.Clear();
            filter.HasValues.Should().BeFalse();

            filter.WithCountries("gb", "us");
            filter.Countries.Should().NotBeNull().And.HaveCount(2);
            filter.HasValues.Should().BeTrue();

            filter.Clear();
            filter.HasValues.Should().BeFalse();

            filter.WithRuntimes(30, 180);
            filter.Runtimes.Should().NotBeNull();
            filter.Runtimes.Value.Begin.Should().Be(30);
            filter.Runtimes.Value.End.Should().Be(180);
            filter.HasValues.Should().BeTrue();

            filter.Clear();
            filter.HasValues.Should().BeFalse();

            filter.WithRatings(60, 90);
            filter.Ratings.Should().NotBeNull();
            filter.Ratings.Value.Begin.Should().Be(60);
            filter.Ratings.Value.End.Should().Be(90);
            filter.HasValues.Should().BeTrue();

            filter.Clear();
            filter.HasValues.Should().BeFalse();

            filter.WithCertifications("cert1", "cert2");
            filter.Certifications.Should().NotBeNull().And.HaveCount(2);
            filter.HasValues.Should().BeTrue();

            filter.Clear();
            filter.HasValues.Should().BeFalse();

            filter.WithNetworks("network1", "network2");
            filter.Networks.Should().NotBeNull().And.HaveCount(2);
            filter.HasValues.Should().BeTrue();

            filter.Clear();
            filter.HasValues.Should().BeFalse();

            var state1 = TraktShowStatus.ReturningSeries;
            var state2 = TraktShowStatus.InProduction;

            filter.WithStates(state1, state2);
            filter.States.Should().NotBeNull().And.HaveCount(2);
            filter.HasValues.Should().BeTrue();

            filter.Clear();
            filter.HasValues.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowFilter_ClearQuery()
        {
            var filter = new TraktShowFilter();

            filter.Query.Should().BeNull();

            filter.WithQuery("query");
            filter.Query.Should().Be("query");

            filter.ClearQuery();
            filter.Query.Should().BeNull();
        }

        [Fact]
        public void Test_TraktShowFilter_ClearStartYear()
        {
            var filter = new TraktShowFilter();

            filter.StartYear.Should().NotHaveValue();

            filter.WithStartYear(2010);
            filter.StartYear.Should().Be(2010);

            filter.ClearStartYear();
            filter.StartYear.Should().NotHaveValue();
        }

        [Fact]
        public void Test_TraktShowFilter_ClearEndYear()
        {
            var filter = new TraktShowFilter();

            filter.EndYear.Should().NotHaveValue();

            filter.WithEndYear(2016);
            filter.EndYear.Should().Be(2016);

            filter.ClearEndYear();
            filter.EndYear.Should().NotHaveValue();
        }

        [Fact]
        public void Test_TraktShowFilter_ClearYears()
        {
            var filter = new TraktShowFilter();

            filter.StartYear.Should().NotHaveValue();
            filter.EndYear.Should().NotHaveValue();

            filter.WithYears(2010, 2016);
            filter.StartYear.Should().Be(2010);
            filter.EndYear.Should().Be(2016);

            filter.ClearYears();
            filter.StartYear.Should().NotHaveValue();
            filter.EndYear.Should().NotHaveValue();
        }

        [Fact]
        public void Test_TraktShowFilter_ClearGenres()
        {
            var filter = new TraktShowFilter();

            filter.Genres.Should().BeNull();

            filter.WithGenres("action", "drama");
            filter.Genres.Should().NotBeNull().And.HaveCount(2);

            filter.ClearGenres();
            filter.Genres.Should().BeNull();
        }

        [Fact]
        public void Test_TraktShowFilter_ClearLanguages()
        {
            var filter = new TraktShowFilter();

            filter.Languages.Should().BeNull();

            filter.WithLanguages("de", "en");
            filter.Languages.Should().NotBeNull().And.HaveCount(2);

            filter.ClearLanguages();
            filter.Languages.Should().BeNull();
        }

        [Fact]
        public void Test_TraktShowFilter_ClearCuntries()
        {
            var filter = new TraktShowFilter();

            filter.Countries.Should().BeNull();

            filter.WithCountries("gb", "us");
            filter.Countries.Should().NotBeNull().And.HaveCount(2);

            filter.ClearCountries();
            filter.Countries.Should().BeNull();
        }

        [Fact]
        public void Test_TraktShowFilter_ClearRuntimes()
        {
            var filter = new TraktShowFilter();

            filter.Runtimes.Should().BeNull();

            filter.WithRuntimes(30, 180);
            filter.Runtimes.Should().NotBeNull();
            filter.Runtimes.Value.Begin.Should().Be(30);
            filter.Runtimes.Value.End.Should().Be(180);

            filter.ClearRuntimes();
            filter.Runtimes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktShowFilter_ClearRatings()
        {
            var filter = new TraktShowFilter();

            filter.Ratings.Should().BeNull();

            filter.WithRatings(60, 90);
            filter.Ratings.Should().NotBeNull();
            filter.Ratings.Value.Begin.Should().Be(60);
            filter.Ratings.Value.End.Should().Be(90);

            filter.ClearRatings();
            filter.Ratings.Should().BeNull();
        }

        [Fact]
        public void Test_TraktShowFilter_ClearCertifications()
        {
            var filter = new TraktShowFilter();

            filter.Certifications.Should().BeNull();

            filter.WithCertifications("cert1", "cert2");
            filter.Certifications.Should().NotBeNull().And.HaveCount(2);

            filter.ClearCertifications();
            filter.Certifications.Should().BeNull();
        }

        [Fact]
        public void Test_TraktShowFilter_ClearNetworks()
        {
            var filter = new TraktShowFilter();

            filter.Networks.Should().BeNull();

            filter.WithCertifications("cert1", "cert2");
            filter.Certifications.Should().NotBeNull().And.HaveCount(2);

            filter.ClearNetworks();
            filter.Networks.Should().BeNull();
        }

        [Fact]
        public void Test_TraktShowFilter_ClearStates()
        {
            var filter = new TraktShowFilter();

            filter.States.Should().BeNull();

            var state1 = TraktShowStatus.ReturningSeries;
            var state2 = TraktShowStatus.InProduction;

            filter.WithStates(state1, state2);
            filter.States.Should().NotBeNull().And.HaveCount(2);

            filter.ClearStates();
            filter.States.Should().BeNull();
        }

        [Fact]
        public void Test_TraktShowFilter_Clear()
        {
            var filter = new TraktShowFilter();

            filter.WithQuery("query");
            filter.Query.Should().Be("query");

            filter.WithStartYear(2010);
            filter.StartYear.Should().Be(2010);

            filter.WithEndYear(2016);
            filter.EndYear.Should().Be(2016);

            filter.WithGenres("action", "drama");
            filter.Genres.Should().NotBeNull().And.HaveCount(2);

            filter.WithLanguages("de", "en");
            filter.Languages.Should().NotBeNull().And.HaveCount(2);

            filter.WithCountries("gb", "us");
            filter.Countries.Should().NotBeNull().And.HaveCount(2);

            filter.WithRuntimes(30, 180);
            filter.Runtimes.Should().NotBeNull();
            filter.Runtimes.Value.Begin.Should().Be(30);
            filter.Runtimes.Value.End.Should().Be(180);

            filter.WithRatings(60, 90);
            filter.Ratings.Should().NotBeNull();
            filter.Ratings.Value.Begin.Should().Be(60);
            filter.Ratings.Value.End.Should().Be(90);

            filter.WithCertifications("cert1", "cert2");
            filter.Certifications.Should().NotBeNull().And.HaveCount(2);

            filter.WithNetworks("network1", "network2");
            filter.Networks.Should().NotBeNull().And.HaveCount(2);

            var state1 = TraktShowStatus.ReturningSeries;
            var state2 = TraktShowStatus.InProduction;

            filter.WithStates(state1, state2);
            filter.States.Should().NotBeNull().And.HaveCount(2);

            filter.Clear();

            filter.Query.Should().BeNull();
            filter.StartYear.Should().NotHaveValue();
            filter.EndYear.Should().NotHaveValue();
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.Certifications.Should().BeNull();
            filter.Networks.Should().BeNull();
            filter.States.Should().BeNull();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktShowFilter_GetParametersWithStartYear()
        {
            var filter = new TraktShowFilter();

            filter.GetParameters().Should().NotBeNull().And.BeEmpty();

            filter.WithQuery("query");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" } });

            var startYear = 2010;
            var years = $"{startYear}";

            filter.WithStartYear(startYear);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(2);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years } });

            filter.WithGenres("action", "drama", "fantasy");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(3);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" } });

            filter.WithLanguages("de", "en", "es");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(4);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" } });

            filter.WithCountries("gb", "us", "fr");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(5);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" } });

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(6);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" } });

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(7);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"} });

            filter.WithCertifications("cert1", "cert2", "cert3");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(8);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"},
                                                                                       { "certifications", "cert1,cert2,cert3" } });

            filter.WithNetworks("network1", "network2");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(9);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"},
                                                                                       { "certifications", "cert1,cert2,cert3" },
                                                                                       { "networks", "network1,network2" } });

            var state1 = TraktShowStatus.ReturningSeries;
            var state2 = TraktShowStatus.InProduction;

            filter.WithStates(state1, state2);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(10);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"},
                                                                                       { "certifications", "cert1,cert2,cert3" },
                                                                                       { "networks", "network1,network2" },
                                                                                       { "status", $"{state1.UriName},{state2.UriName}" } });
        }

        [Fact]
        public void Test_TraktShowFilter_GetParametersWithEndYear()
        {
            var filter = new TraktShowFilter();

            filter.GetParameters().Should().NotBeNull().And.BeEmpty();

            filter.WithQuery("query");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" } });

            var endYear = 2016;
            var years = $"{endYear}";

            filter.WithEndYear(endYear);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(2);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years } });

            filter.WithGenres("action", "drama", "fantasy");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(3);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" } });

            filter.WithLanguages("de", "en", "es");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(4);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" } });

            filter.WithCountries("gb", "us", "fr");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(5);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" } });

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(6);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" } });

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(7);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"} });

            filter.WithCertifications("cert1", "cert2", "cert3");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(8);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"},
                                                                                       { "certifications", "cert1,cert2,cert3" } });

            filter.WithNetworks("network1", "network2");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(9);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"},
                                                                                       { "certifications", "cert1,cert2,cert3" },
                                                                                       { "networks", "network1,network2" } });

            var state1 = TraktShowStatus.ReturningSeries;
            var state2 = TraktShowStatus.InProduction;

            filter.WithStates(state1, state2);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(10);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"},
                                                                                       { "certifications", "cert1,cert2,cert3" },
                                                                                       { "networks", "network1,network2" },
                                                                                       { "status", $"{state1.UriName},{state2.UriName}" } });
        }

        [Fact]
        public void Test_TraktShowFilter_GetParametersWithYearsReversed()
        {
            var filter = new TraktShowFilter();

            filter.GetParameters().Should().NotBeNull().And.BeEmpty();

            filter.WithQuery("query");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" } });

            var startYear = 2010;
            var endYear = 2016;
            var years = $"{startYear}-{endYear}";

            filter.WithYears(endYear, startYear);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(2);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years } });

            filter.WithGenres("action", "drama", "fantasy");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(3);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" } });

            filter.WithLanguages("de", "en", "es");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(4);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" } });

            filter.WithCountries("gb", "us", "fr");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(5);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" } });

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(6);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" } });

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(7);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"} });

            filter.WithCertifications("cert1", "cert2", "cert3");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(8);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"},
                                                                                       { "certifications", "cert1,cert2,cert3" } });

            filter.WithNetworks("network1", "network2");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(9);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"},
                                                                                       { "certifications", "cert1,cert2,cert3" },
                                                                                       { "networks", "network1,network2" } });

            var state1 = TraktShowStatus.ReturningSeries;
            var state2 = TraktShowStatus.InProduction;

            filter.WithStates(state1, state2);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(10);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"},
                                                                                       { "certifications", "cert1,cert2,cert3" },
                                                                                       { "networks", "network1,network2" },
                                                                                       { "status", $"{state1.UriName},{state2.UriName}" } });
        }

        [Fact]
        public void Test_TraktShowFilter_GetParameters()
        {
            var filter = new TraktShowFilter();

            filter.GetParameters().Should().NotBeNull().And.BeEmpty();

            filter.WithQuery("query");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" } });

            var startYear = 2010;
            var endYear = 2016;
            var years = $"{startYear}-{endYear}";

            filter.WithYears(startYear, endYear);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(2);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years } });

            filter.WithGenres("action", "drama", "fantasy");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(3);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" } });

            filter.WithLanguages("de", "en", "es");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(4);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years",years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" } });

            filter.WithCountries("gb", "us", "fr");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(5);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" } });

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(6);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" } });

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(7);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"} });

            filter.WithCertifications("cert1", "cert2", "cert3");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(8);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"},
                                                                                       { "certifications", "cert1,cert2,cert3" } });

            filter.WithNetworks("network1", "network2");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(9);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"},
                                                                                       { "certifications", "cert1,cert2,cert3" },
                                                                                       { "networks", "network1,network2" } });

            var state1 = TraktShowStatus.ReturningSeries;
            var state2 = TraktShowStatus.InProduction;

            filter.WithStates(state1, state2);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(10);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"},
                                                                                       { "certifications", "cert1,cert2,cert3" },
                                                                                       { "networks", "network1,network2" },
                                                                                       { "status", $"{state1.UriName},{state2.UriName}" } });
        }

        [Fact]
        public void Test_TraktShowFilter_ToStringWithStartYear()
        {
            var filter = new TraktShowFilter();

            filter.ToString().Should().NotBeNull().And.BeEmpty();

            filter.WithQuery("query");
            filter.ToString().Should().Be("query=query");

            var startYear = 2010;
            var years = $"{startYear}";

            filter.WithStartYear(startYear);
            filter.ToString().Should().Be($"years={years}&query=query");

            filter.WithGenres("action", "drama", "fantasy");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&query=query");

            filter.WithLanguages("de", "en", "es");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&query=query");

            filter.WithCountries("gb", "us", "fr");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr&query=query");

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&query=query");

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query");

            filter.WithCertifications("cert1", "cert2", "cert3");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query" +
                                          $"&certifications=cert1,cert2,cert3");

            filter.WithNetworks("network1", "network2");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query" +
                                          $"&certifications=cert1,cert2,cert3" +
                                          $"&networks=network1,network2");

            var state1 = TraktShowStatus.ReturningSeries;
            var state2 = TraktShowStatus.InProduction;

            filter.WithStates(state1, state2);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query" +
                                          $"&certifications=cert1,cert2,cert3" +
                                          $"&networks=network1,network2" +
                                          $"&status={state1.UriName},{state2.UriName}");
        }

        [Fact]
        public void Test_TraktShowFilter_ToStringWithEndYear()
        {
            var filter = new TraktShowFilter();

            filter.ToString().Should().NotBeNull().And.BeEmpty();

            filter.WithQuery("query");
            filter.ToString().Should().Be("query=query");

            var endYear = 2016;
            var years = $"{endYear}";

            filter.WithEndYear(endYear);
            filter.ToString().Should().Be($"years={years}&query=query");

            filter.WithGenres("action", "drama", "fantasy");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&query=query");

            filter.WithLanguages("de", "en", "es");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&query=query");

            filter.WithCountries("gb", "us", "fr");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr&query=query");

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&query=query");

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query");

            filter.WithCertifications("cert1", "cert2", "cert3");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query" +
                                          $"&certifications=cert1,cert2,cert3");

            filter.WithNetworks("network1", "network2");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query" +
                                          $"&certifications=cert1,cert2,cert3" +
                                          $"&networks=network1,network2");

            var state1 = TraktShowStatus.ReturningSeries;
            var state2 = TraktShowStatus.InProduction;

            filter.WithStates(state1, state2);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query" +
                                          $"&certifications=cert1,cert2,cert3" +
                                          $"&networks=network1,network2" +
                                          $"&status={state1.UriName},{state2.UriName}");
        }

        [Fact]
        public void Test_TraktShowFilter_ToStringWithYearsReversed()
        {
            var filter = new TraktShowFilter();

            filter.ToString().Should().NotBeNull().And.BeEmpty();

            filter.WithQuery("query");
            filter.ToString().Should().Be("query=query");

            var startYear = 2010;
            var endYear = 2016;
            var years = $"{startYear}-{endYear}";

            filter.WithYears(endYear, startYear);
            filter.ToString().Should().Be($"years={years}&query=query");

            filter.WithGenres("action", "drama", "fantasy");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&query=query");

            filter.WithLanguages("de", "en", "es");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&query=query");

            filter.WithCountries("gb", "us", "fr");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr&query=query");

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&query=query");

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query");

            filter.WithCertifications("cert1", "cert2", "cert3");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query" +
                                          $"&certifications=cert1,cert2,cert3");

            filter.WithNetworks("network1", "network2");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query" +
                                          $"&certifications=cert1,cert2,cert3" +
                                          $"&networks=network1,network2");

            var state1 = TraktShowStatus.ReturningSeries;
            var state2 = TraktShowStatus.InProduction;

            filter.WithStates(state1, state2);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query" +
                                          $"&certifications=cert1,cert2,cert3" +
                                          $"&networks=network1,network2" +
                                          $"&status={state1.UriName},{state2.UriName}");
        }

        [Fact]
        public void Test_TraktShowFilter_ToString()
        {
            var filter = new TraktShowFilter();

            filter.ToString().Should().NotBeNull().And.BeEmpty();

            filter.WithQuery("query");
            filter.ToString().Should().Be("query=query");

            var startYear = 2010;
            var endYear = 2016;
            var years = $"{startYear}-{endYear}";

            filter.WithYears(startYear, endYear);
            filter.ToString().Should().Be($"years={years}&query=query");

            filter.WithGenres("action", "drama", "fantasy");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&query=query");

            filter.WithLanguages("de", "en", "es");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&query=query");

            filter.WithCountries("gb", "us", "fr");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr&query=query");

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&query=query");

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query");

            filter.WithCertifications("cert1", "cert2", "cert3");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query" +
                                          $"&certifications=cert1,cert2,cert3");

            filter.WithNetworks("network1", "network2");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query" +
                                          $"&certifications=cert1,cert2,cert3" +
                                          $"&networks=network1,network2");

            var state1 = TraktShowStatus.ReturningSeries;
            var state2 = TraktShowStatus.InProduction;

            filter.WithStates(state1, state2);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query" +
                                          $"&certifications=cert1,cert2,cert3" +
                                          $"&networks=network1,network2" +
                                          $"&status={state1.UriName},{state2.UriName}");
        }
    }
}
