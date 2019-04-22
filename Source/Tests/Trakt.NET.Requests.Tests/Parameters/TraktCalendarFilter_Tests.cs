namespace TraktNet.Requests.Tests.Parameters
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Parameters;
    using TraktNet.Utils;
    using Xunit;

    [Category("Requests.Parameters")]
    public class TraktCalendarFilter_Tests
    {
        [Fact]
        public void Test_TraktCalendarFilter_DefaultConstructor()
        {
            var filter = new TraktCalendarFilter();

            filter.Query.Should().BeNull();
            filter.StartYear.Should().NotHaveValue();
            filter.EndYear.Should().NotHaveValue();
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktCalendarFilter_Constructor()
        {
            var filter = new TraktCalendarFilter("query", 2010, 2016, new string[] { "action", "drama" },
                                                 new string[] { "de", "en" },
                                                 new string[] { "gb", "us" },
                                                 new Range<int>(40, 100), new Range<int>(70, 90));

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
        }

        [Fact]
        public void Test_TraktCalendarFilter_HasValues()
        {
            var filter = new TraktCalendarFilter();

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
        }

        [Fact]
        public void Test_TraktCalendarFilter_ClearQuery()
        {
            var filter = new TraktCalendarFilter();

            filter.Query.Should().BeNull();

            filter.WithQuery("query");
            filter.Query.Should().Be("query");

            filter.ClearQuery();
            filter.Query.Should().BeNull();
        }

        [Fact]
        public void Test_TraktCalendarFilter_ClearStartYear()
        {
            var filter = new TraktCalendarFilter();

            filter.StartYear.Should().NotHaveValue();

            filter.WithStartYear(2010);
            filter.StartYear.Should().Be(2010);

            filter.ClearStartYear();
            filter.StartYear.Should().NotHaveValue();
        }

        [Fact]
        public void Test_TraktCalendarFilter_ClearEndYear()
        {
            var filter = new TraktCalendarFilter();

            filter.EndYear.Should().NotHaveValue();

            filter.WithEndYear(2016);
            filter.EndYear.Should().Be(2016);

            filter.ClearEndYear();
            filter.EndYear.Should().NotHaveValue();
        }

        [Fact]
        public void Test_TraktCalendarFilter_ClearYears()
        {
            var filter = new TraktCalendarFilter();

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
        public void Test_TraktCalendarFilter_ClearGenres()
        {
            var filter = new TraktCalendarFilter();

            filter.Genres.Should().BeNull();

            filter.WithGenres("action", "drama");
            filter.Genres.Should().NotBeNull().And.HaveCount(2);

            filter.ClearGenres();
            filter.Genres.Should().BeNull();
        }

        [Fact]
        public void Test_TraktCalendarFilter_ClearLanguages()
        {
            var filter = new TraktCalendarFilter();

            filter.Languages.Should().BeNull();

            filter.WithLanguages("de", "en");
            filter.Languages.Should().NotBeNull().And.HaveCount(2);

            filter.ClearLanguages();
            filter.Languages.Should().BeNull();
        }

        [Fact]
        public void Test_TraktCalendarFilter_ClearCountries()
        {
            var filter = new TraktCalendarFilter();

            filter.Countries.Should().BeNull();

            filter.WithCountries("gb", "us");
            filter.Countries.Should().NotBeNull().And.HaveCount(2);

            filter.ClearCountries();
            filter.Countries.Should().BeNull();
        }

        [Fact]
        public void Test_TraktCalendarFilter_ClearRuntimes()
        {
            var filter = new TraktCalendarFilter();

            filter.Runtimes.Should().BeNull();

            filter.WithRuntimes(30, 180);
            filter.Runtimes.Should().NotBeNull();
            filter.Runtimes.Value.Begin.Should().Be(30);
            filter.Runtimes.Value.End.Should().Be(180);

            filter.ClearRuntimes();
            filter.Runtimes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktCalendarFilter_ClearRatings()
        {
            var filter = new TraktCalendarFilter();

            filter.Ratings.Should().BeNull();

            filter.WithRatings(60, 90);
            filter.Ratings.Should().NotBeNull();
            filter.Ratings.Value.Begin.Should().Be(60);
            filter.Ratings.Value.End.Should().Be(90);

            filter.ClearRatings();
            filter.Ratings.Should().BeNull();
        }

        [Fact]
        public void Test_TraktCalendarFilter_Clear()
        {
            var filter = new TraktCalendarFilter();

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

            filter.Clear();

            filter.Query.Should().BeNull();
            filter.StartYear.Should().NotHaveValue();
            filter.EndYear.Should().NotHaveValue();
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktCalendarFilter_GetParametersWithStartYear()
        {
            var filter = new TraktCalendarFilter();

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
        }

        [Fact]
        public void Test_TraktCalendarFilter_GetParametersWithEndYear()
        {
            var filter = new TraktCalendarFilter();

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
        }

        [Fact]
        public void Test_TraktCalendarFilter_GetParametersWithYearsReversed()
        {
            var filter = new TraktCalendarFilter();

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
        }

        [Fact]
        public void Test_TraktCalendarFilter_GetParameters()
        {
            var filter = new TraktCalendarFilter();

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
        }

        [Fact]
        public void Test_TraktCalendarFilter_ToStringWithStartYear()
        {
            var filter = new TraktCalendarFilter();

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
        }

        [Fact]
        public void Test_TraktCalendarFilter_ToStringWithEndYear()
        {
            var filter = new TraktCalendarFilter();

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
        }

        [Fact]
        public void Test_TraktCalendarFilter_ToStringWithYearsReversed()
        {
            var filter = new TraktCalendarFilter();

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
        }

        [Fact]
        public void Test_TraktCalendarFilter_ToString()
        {
            var filter = new TraktCalendarFilter();

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
        }
    }
}
