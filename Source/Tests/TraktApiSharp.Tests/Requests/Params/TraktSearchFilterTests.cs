namespace TraktApiSharp.Tests.Requests.Params
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Utils;

    [TestClass]
    public class TraktSearchFilterTests
    {
        [TestMethod]
        public void TestTraktSearchFilterDefaultConstructor()
        {
            var filter = new TraktSearchFilter();

            filter.StartYear.Should().NotHaveValue();
            filter.EndYear.Should().NotHaveValue();
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSearchFilterConstructor()
        {
            var filter = new TraktSearchFilter(2010, 2016, new string[] { "action", "drama" },
                                               new string[] { "de", "en" },
                                               new string[] { "gb", "us" },
                                               new Range<int>(40, 100), new Range<int>(70, 90));

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

        [TestMethod]
        public void TestTraktSearchFilterHasValues()
        {
            var filter = new TraktSearchFilter();

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

        [TestMethod]
        public void TestTraktSearchFilterClearStartYear()
        {
            var filter = new TraktSearchFilter();

            filter.StartYear.Should().NotHaveValue();

            filter.WithStartYear(2010);
            filter.StartYear.Should().Be(2010);

            filter.ClearStartYear();
            filter.StartYear.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSearchFilterClearEndYear()
        {
            var filter = new TraktSearchFilter();

            filter.EndYear.Should().NotHaveValue();

            filter.WithEndYear(2016);
            filter.EndYear.Should().Be(2016);

            filter.ClearEndYear();
            filter.EndYear.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSearchFilterClearYears()
        {
            var filter = new TraktSearchFilter();

            filter.StartYear.Should().NotHaveValue();
            filter.EndYear.Should().NotHaveValue();

            filter.WithYears(2010, 2016);
            filter.StartYear.Should().Be(2010);
            filter.EndYear.Should().Be(2016);

            filter.ClearYears();
            filter.StartYear.Should().NotHaveValue();
            filter.EndYear.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSearchFilterClearGenres()
        {
            var filter = new TraktSearchFilter();

            filter.Genres.Should().BeNull();

            filter.WithGenres("action", "drama");
            filter.Genres.Should().NotBeNull().And.HaveCount(2);

            filter.ClearGenres();
            filter.Genres.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSearchFilterClearLanguages()
        {
            var filter = new TraktSearchFilter();

            filter.Languages.Should().BeNull();

            filter.WithLanguages("de", "en");
            filter.Languages.Should().NotBeNull().And.HaveCount(2);

            filter.ClearLanguages();
            filter.Languages.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSearchFilterClearCountries()
        {
            var filter = new TraktSearchFilter();

            filter.Countries.Should().BeNull();

            filter.WithCountries("gb", "us");
            filter.Countries.Should().NotBeNull().And.HaveCount(2);

            filter.ClearCountries();
            filter.Countries.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSearchFilterClearRuntimes()
        {
            var filter = new TraktSearchFilter();

            filter.Runtimes.Should().BeNull();

            filter.WithRuntimes(30, 180);
            filter.Runtimes.Should().NotBeNull();
            filter.Runtimes.Value.Begin.Should().Be(30);
            filter.Runtimes.Value.End.Should().Be(180);

            filter.ClearRuntimes();
            filter.Runtimes.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSearchFilterClearRatings()
        {
            var filter = new TraktSearchFilter();

            filter.Ratings.Should().BeNull();

            filter.WithRatings(60, 90);
            filter.Ratings.Should().NotBeNull();
            filter.Ratings.Value.Begin.Should().Be(60);
            filter.Ratings.Value.End.Should().Be(90);

            filter.ClearRatings();
            filter.Ratings.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSearchFilterClear()
        {
            var filter = new TraktSearchFilter();

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

            filter.StartYear.Should().NotHaveValue();
            filter.EndYear.Should().NotHaveValue();
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSearchFilterGetParametersWithStartYear()
        {
            var filter = new TraktSearchFilter();

            filter.GetParameters().Should().NotBeNull().And.BeEmpty();

            var startYear = 2010;
            var years = $"{startYear}";

            filter.WithStartYear(startYear);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years } });

            filter.WithGenres("action", "drama", "fantasy");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(2);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" } });

            filter.WithLanguages("de", "en", "es");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(3);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" } });

            filter.WithCountries("gb", "us", "fr");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(4);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" } });

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(5);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" } });

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(6);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"} });
        }

        [TestMethod]
        public void TestTraktSearchFilterGetParametersWithEndYear()
        {
            var filter = new TraktSearchFilter();

            filter.GetParameters().Should().NotBeNull().And.BeEmpty();

            var endYear = 2016;
            var years = $"{endYear}";

            filter.WithEndYear(endYear);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years } });

            filter.WithGenres("action", "drama", "fantasy");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(2);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" } });

            filter.WithLanguages("de", "en", "es");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(3);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" } });

            filter.WithCountries("gb", "us", "fr");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(4);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" } });

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(5);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" } });

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(6);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"} });
        }

        [TestMethod]
        public void TestTraktSearchFilterGetParametersWithYearsReversed()
        {
            var filter = new TraktSearchFilter();

            filter.GetParameters().Should().NotBeNull().And.BeEmpty();

            var startYear = 2010;
            var endYear = 2016;
            var years = $"{startYear}-{endYear}";

            filter.WithYears(endYear, startYear);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years } });

            filter.WithGenres("action", "drama", "fantasy");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(2);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" } });

            filter.WithLanguages("de", "en", "es");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(3);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" } });

            filter.WithCountries("gb", "us", "fr");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(4);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" } });

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(5);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" } });

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(6);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"} });
        }

        [TestMethod]
        public void TestTraktSearchFilterGetParameters()
        {
            var filter = new TraktSearchFilter();

            filter.GetParameters().Should().NotBeNull().And.BeEmpty();

            var startYear = 2010;
            var endYear = 2016;
            var years = $"{startYear}-{endYear}";

            filter.WithYears(startYear, endYear);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years } });

            filter.WithGenres("action", "drama", "fantasy");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(2);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" } });

            filter.WithLanguages("de", "en", "es");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(3);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" } });

            filter.WithCountries("gb", "us", "fr");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(4);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" } });

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(5);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" } });

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(6);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", years },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"} });
        }

        [TestMethod]
        public void TestTraktMovieFilterToStringWithStartYear()
        {
            var filter = new TraktSearchFilter();

            filter.ToString().Should().NotBeNull().And.BeEmpty();

            var startYear = 2010;
            var years = $"{startYear}";

            filter.WithStartYear(startYear);
            filter.ToString().Should().Be($"years={years}");

            filter.WithGenres("action", "drama", "fantasy");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy");

            filter.WithLanguages("de", "en", "es");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es");

            filter.WithCountries("gb", "us", "fr");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr");

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}");

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}");
        }

        [TestMethod]
        public void TestTraktMovieFilterToStringWithEndYear()
        {
            var filter = new TraktSearchFilter();

            filter.ToString().Should().NotBeNull().And.BeEmpty();

            var endYear = 2016;
            var years = $"{endYear}";

            filter.WithEndYear(endYear);
            filter.ToString().Should().Be($"years={years}");

            filter.WithGenres("action", "drama", "fantasy");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy");

            filter.WithLanguages("de", "en", "es");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es");

            filter.WithCountries("gb", "us", "fr");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr");

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}");

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}");
        }

        [TestMethod]
        public void TestTraktMovieFilterToStringWithYearsReversed()
        {
            var filter = new TraktSearchFilter();

            filter.ToString().Should().NotBeNull().And.BeEmpty();

            var startYear = 2010;
            var endYear = 2016;
            var years = $"{startYear}-{endYear}";

            filter.WithYears(endYear, startYear);
            filter.ToString().Should().Be($"years={years}");

            filter.WithGenres("action", "drama", "fantasy");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy");

            filter.WithLanguages("de", "en", "es");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es");

            filter.WithCountries("gb", "us", "fr");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr");

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}");

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}");
        }

        [TestMethod]
        public void TestTraktMovieFilterToString()
        {
            var filter = new TraktSearchFilter();

            filter.ToString().Should().NotBeNull().And.BeEmpty();

            var startYear = 2010;
            var endYear = 2016;
            var years = $"{startYear}-{endYear}";

            filter.WithYears(startYear, endYear);
            filter.ToString().Should().Be($"years={years}");

            filter.WithGenres("action", "drama", "fantasy");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy");

            filter.WithLanguages("de", "en", "es");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es");

            filter.WithCountries("gb", "us", "fr");
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr");

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}");

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.ToString().Should().Be($"years={years}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}");
        }
    }
}
