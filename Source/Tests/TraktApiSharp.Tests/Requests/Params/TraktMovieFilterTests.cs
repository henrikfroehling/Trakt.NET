namespace TraktApiSharp.Tests.Requests.Params
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Utils;

    [TestClass]
    public class TraktMovieFilterTests
    {
        [TestMethod]
        public void TestTraktMovieFilterDefaultConstructor()
        {
            var filter = new TraktMovieFilter();

            filter.Query.Should().BeNull();
            filter.Years.Should().Be(0);
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.Certifications.Should().BeNull();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktMovieFilterConstructor()
        {
            var filter = new TraktMovieFilter("query", 2016, new string[] { "action", "drama" },
                                              new string[] { "de", "en" },
                                              new string[] { "gb", "us" },
                                              new Range<int>(40, 100), new Range<int>(70, 90),
                                              new string[] { "cert1", "cert2" });

            filter.Query.Should().Be("query");
            filter.Years.Should().Be(2016);

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
        }

        [TestMethod]
        public void TestTraktMovieFilterAddCertifications()
        {
            var filter = new TraktMovieFilter();

            filter.AddCertifications(null);
            filter.Certifications.Should().NotBeNull().And.BeEmpty();

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

        [TestMethod]
        public void TestTraktMovieFilterWithCertifications()
        {
            var filter = new TraktMovieFilter();

            filter.WithCertifications(null);
            filter.Certifications.Should().NotBeNull().And.BeEmpty();

            filter.WithCertifications(null, "cert1");
            filter.Certifications.Should().NotBeNull().And.HaveCount(1);

            filter.AddCertifications("cert1", "cert2");
            filter.Certifications.Should().NotBeNull().And.HaveCount(3);

            filter.WithCertifications(null);
            filter.Certifications.Should().NotBeNull().And.BeEmpty();

            filter.WithCertifications(null, "cert1");
            filter.Certifications.Should().NotBeNull().And.HaveCount(1);

            filter.WithCertifications("cert1", "cert2");
            filter.Certifications.Should().NotBeNull().And.HaveCount(2);

            filter.WithCertifications("cert1", "cert2", "cert3", "cert4");
            filter.Certifications.Should().NotBeNull().And.HaveCount(4);

            filter.WithCertifications("cert5");
            filter.Certifications.Should().NotBeNull().And.HaveCount(1);
        }

        [TestMethod]
        public void TestTraktMovieFilterHasValues()
        {
            var filter = new TraktMovieFilter();

            filter.HasValues.Should().BeFalse();

            filter.WithQuery("query");
            filter.Query.Should().Be("query");
            filter.HasValues.Should().BeTrue();

            filter.Clear();
            filter.HasValues.Should().BeFalse();

            filter.WithYears(2016);
            filter.Years.Should().Be(2016);
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
        }

        [TestMethod]
        public void TestTraktMovieFilterClear()
        {
            var filter = new TraktMovieFilter();

            filter.WithQuery("query");
            filter.Query.Should().Be("query");

            filter.WithYears(2016);
            filter.Years.Should().Be(2016);

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

            filter.Clear();

            filter.Query.Should().BeNull();
            filter.Years.Should().Be(0);
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.Certifications.Should().BeNull();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktMovieFilterGetParameters()
        {
            var filter = new TraktMovieFilter();

            filter.GetParameters().Should().NotBeNull().And.BeEmpty();

            filter.WithQuery("query");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" } });

            var year = 2016;

            filter.WithYears(year);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(2);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", "2016" } });

            filter.WithGenres("action", "drama", "fantasy");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(3);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", "2016" },
                                                                                       { "genres", "action,drama,fantasy" } });

            filter.WithLanguages("de", "en", "es");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(4);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", "2016" },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" } });

            filter.WithCountries("gb", "us", "fr");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(5);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", "2016" },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" } });

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(6);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", "2016" },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" } });

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.GetParameters().Should().NotBeNull().And.HaveCount(7);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", "2016" },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"} });

            filter.WithCertifications("cert1", "cert2", "cert3");
            filter.GetParameters().Should().NotBeNull().And.HaveCount(8);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" }, { "years", "2016" },
                                                                                       { "genres", "action,drama,fantasy" },
                                                                                       { "languages", "de,en,es" },
                                                                                       { "countries", "gb,us,fr" },
                                                                                       { "runtimes", $"{runtimeBegin}-{runtimeEnd}" },
                                                                                       { "ratings", $"{ratingBegin}-{ratingEnd}"},
                                                                                       { "certifications", "cert1,cert2,cert3" } });
        }

        [TestMethod]
        public void TestTraktMovieFilterToString()
        {
            var filter = new TraktMovieFilter();

            filter.ToString().Should().NotBeNull().And.BeEmpty();

            filter.WithQuery("query");
            filter.ToString().Should().Be("query=query");

            var year = 2016;

            filter.WithYears(year);
            filter.ToString().Should().Be($"years={year}&query=query");

            filter.WithGenres("action", "drama", "fantasy");
            filter.ToString().Should().Be($"years={year}&genres=action,drama,fantasy&query=query");

            filter.WithLanguages("de", "en", "es");
            filter.ToString().Should().Be($"years={year}&genres=action,drama,fantasy&languages=de,en,es&query=query");

            filter.WithCountries("gb", "us", "fr");
            filter.ToString().Should().Be($"years={year}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr&query=query");

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.ToString().Should().Be($"years={year}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&query=query");

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.ToString().Should().Be($"years={year}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query");

            filter.WithCertifications("cert1", "cert2", "cert3");
            filter.ToString().Should().Be($"years={year}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}&query=query" +
                                          $"&certifications=cert1,cert2,cert3");
        }
    }
}
