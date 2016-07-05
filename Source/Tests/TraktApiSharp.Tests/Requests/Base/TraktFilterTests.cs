namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using TraktApiSharp.Requests.Base;

    [TestClass]
    public class TraktFilterTests
    {
        [TestMethod]
        public void TestTraktFilterDefaultConstructor()
        {
            var filter = new TraktFilter();

            filter.Query.Should().BeNull();
            filter.Years.Should().Be(0);
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktFilterConstructor()
        {
            var filter = new TraktFilter("query", 2016, new string[] { "action", "drama" },
                                         new string[] { "de", "en" },
                                         new string[] { "gb", "us" },
                                         new Range<int>(40, 100), new Range<int>(70, 90));

            filter.Query.Should().Be("query");
            filter.Years.Should().Be(2016);

            filter.Genres.Should().NotBeNull().And.HaveCount(2);
            filter.Languages.Should().NotBeNull().And.HaveCount(2);
            filter.Countries.Should().NotBeNull().And.HaveCount(2);

            filter.Runtimes.Should().NotBeNull();
            filter.Runtimes.Begin.Should().Be(40);
            filter.Runtimes.End.Should().Be(100);

            filter.Ratings.Should().NotBeNull();
            filter.Ratings.Begin.Should().Be(70);
            filter.Ratings.End.Should().Be(90);
        }

        [TestMethod]
        public void TestTraktFilterWithQuery()
        {
            var filter = new TraktFilter();

            Action act = () => filter.WithQuery(null);
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithQuery(string.Empty);
            act.ShouldThrow<ArgumentException>();

            filter.WithQuery("query");
            filter.Query.Should().Be("query");
        }

        [TestMethod]
        public void TestTraktFilterWithYears()
        {
            var filter = new TraktFilter();

            Action act = () => filter.WithYears(-1);
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithYears(1);
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithYears(12);
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithYears(123);
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithYears(12345);
            act.ShouldThrow<ArgumentException>();

            filter.WithYears(2016);
            filter.Years.Should().Be(2016);
        }

        [TestMethod]
        public void TestTraktFilterAddGenres()
        {
            var filter = new TraktFilter();

            filter.AddGenres(null);
            filter.Genres.Should().NotBeNull().And.BeEmpty();

            filter.AddGenres(null, "action");
            filter.Genres.Should().NotBeNull().And.HaveCount(1);

            filter.AddGenres("action", "fantasy", "science-fiction");
            filter.Genres.Should().NotBeNull().And.HaveCount(4);

            filter.AddGenres("drama");
            filter.Genres.Should().NotBeNull().And.HaveCount(5);

            filter.AddGenres(null);
            filter.Genres.Should().NotBeNull().And.HaveCount(5);

            filter.AddGenres("comedy", "mystery");
            filter.Genres.Should().NotBeNull().And.HaveCount(7);
        }

        [TestMethod]
        public void TestTraktFilterWithGenres()
        {
            var filter = new TraktFilter();

            filter.WithGenres(null);
            filter.Genres.Should().NotBeNull().And.BeEmpty();

            filter.WithGenres(null, "action");
            filter.Genres.Should().NotBeNull().And.HaveCount(1);

            filter.AddGenres("action", "fantasy");
            filter.Genres.Should().NotBeNull().And.HaveCount(3);

            filter.WithGenres(null);
            filter.Genres.Should().NotBeNull().And.BeEmpty();

            filter.WithGenres(null, "action");
            filter.Genres.Should().NotBeNull().And.HaveCount(1);

            filter.WithGenres("action", "fantasy");
            filter.Genres.Should().NotBeNull().And.HaveCount(2);

            filter.WithGenres("action", "fantasy", "drama", "comedy");
            filter.Genres.Should().NotBeNull().And.HaveCount(4);

            filter.WithGenres("mystery");
            filter.Genres.Should().NotBeNull().And.HaveCount(1);
        }

        [TestMethod]
        public void TestTraktFilterAddLanguages()
        {
            var filter = new TraktFilter();

            Action act = () => filter.AddLanguages("deu");
            act.ShouldThrow<ArgumentException>();

            act = () => filter.AddLanguages("d");
            act.ShouldThrow<ArgumentException>();

            act = () => filter.AddLanguages(null, "deu", "en");
            act.ShouldThrow<ArgumentException>();

            act = () => filter.AddLanguages(null, "en", "de", "f");
            act.ShouldThrow<ArgumentException>();

            filter.AddLanguages(null);
            filter.Languages.Should().NotBeNull().And.BeEmpty();

            filter.AddLanguages(null, "de");
            filter.Languages.Should().NotBeNull().And.HaveCount(1);

            filter.AddLanguages("de", "en", "fr");
            filter.Languages.Should().NotBeNull().And.HaveCount(4);

            filter.AddLanguages("es");
            filter.Languages.Should().NotBeNull().And.HaveCount(5);

            filter.AddLanguages(null);
            filter.Languages.Should().NotBeNull().And.HaveCount(5);

            filter.AddLanguages("nl", "us");
            filter.Languages.Should().NotBeNull().And.HaveCount(7);
        }

        [TestMethod]
        public void TestTraktFilterWithLanguages()
        {
            var filter = new TraktFilter();

            Action act = () => filter.WithLanguages("deu");
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithLanguages("d");
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithLanguages(null, "deu", "en");
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithLanguages(null, "en", "de", "f");
            act.ShouldThrow<ArgumentException>();

            filter.WithLanguages(null);
            filter.Languages.Should().NotBeNull().And.BeEmpty();

            filter.WithLanguages(null, "de");
            filter.Languages.Should().NotBeNull().And.HaveCount(1);

            filter.AddLanguages("de", "en");
            filter.Languages.Should().NotBeNull().And.HaveCount(3);

            filter.WithLanguages(null);
            filter.Languages.Should().NotBeNull().And.BeEmpty();

            filter.WithLanguages(null, "de");
            filter.Languages.Should().NotBeNull().And.HaveCount(1);

            filter.WithLanguages("de", "en");
            filter.Languages.Should().NotBeNull().And.HaveCount(2);

            filter.WithLanguages("de", "en", "es", "fr");
            filter.Languages.Should().NotBeNull().And.HaveCount(4);

            filter.WithLanguages("us");
            filter.Languages.Should().NotBeNull().And.HaveCount(1);
        }

        [TestMethod]
        public void TestTraktFilterAddCountries()
        {
            var filter = new TraktFilter();

            Action act = () => filter.AddCountries("ger");
            act.ShouldThrow<ArgumentException>();

            act = () => filter.AddCountries("g");
            act.ShouldThrow<ArgumentException>();

            act = () => filter.AddCountries(null, "ger", "gb");
            act.ShouldThrow<ArgumentException>();

            act = () => filter.AddCountries(null, "gb", "ge", "f");
            act.ShouldThrow<ArgumentException>();

            filter.AddCountries(null);
            filter.Countries.Should().NotBeNull().And.BeEmpty();

            filter.AddCountries(null, "ge");
            filter.Countries.Should().NotBeNull().And.HaveCount(1);

            filter.AddCountries("ge", "gb", "fr");
            filter.Countries.Should().NotBeNull().And.HaveCount(4);

            filter.AddCountries("sp");
            filter.Countries.Should().NotBeNull().And.HaveCount(5);

            filter.AddCountries(null);
            filter.Countries.Should().NotBeNull().And.HaveCount(5);

            filter.AddCountries("nl", "us");
            filter.Countries.Should().NotBeNull().And.HaveCount(7);
        }

        [TestMethod]
        public void TestTraktFilterWithCountries()
        {
            var filter = new TraktFilter();

            Action act = () => filter.WithCountries("ger");
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithCountries("g");
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithCountries(null, "ger", "gb");
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithCountries(null, "gb", "ge", "f");
            act.ShouldThrow<ArgumentException>();

            filter.WithCountries(null);
            filter.Countries.Should().NotBeNull().And.BeEmpty();

            filter.WithCountries(null, "ge");
            filter.Countries.Should().NotBeNull().And.HaveCount(1);

            filter.AddCountries("ge", "gb");
            filter.Countries.Should().NotBeNull().And.HaveCount(3);

            filter.WithCountries(null);
            filter.Countries.Should().NotBeNull().And.BeEmpty();

            filter.WithCountries(null, "ge");
            filter.Countries.Should().NotBeNull().And.HaveCount(1);

            filter.WithCountries("ge", "gb");
            filter.Countries.Should().NotBeNull().And.HaveCount(2);

            filter.WithCountries("ge", "gb", "sp", "fr");
            filter.Countries.Should().NotBeNull().And.HaveCount(4);

            filter.WithCountries("us");
            filter.Countries.Should().NotBeNull().And.HaveCount(1);
        }

        [TestMethod]
        public void TestTraktFilterWithRuntimes()
        {
            var filter = new TraktFilter();

            Action act = () => filter.WithRuntimes(-1, 0);
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithRuntimes(0, -1);
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithRuntimes(75, 74);
            act.ShouldThrow<ArgumentException>();

            filter.WithRuntimes(45, 120);
            filter.Runtimes.Should().NotBeNull();
            filter.Runtimes.Begin.Should().Be(45);
            filter.Runtimes.End.Should().Be(120);
        }

        [TestMethod]
        public void TestTraktFilterWithRatings()
        {
            var filter = new TraktFilter();

            Action act = () => filter.WithRatings(-1, 0);
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithRatings(0, -1);
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithRatings(0, 101);
            act.ShouldThrow<ArgumentException>();

            act = () => filter.WithRatings(75, 74);
            act.ShouldThrow<ArgumentException>();

            filter.WithRatings(40, 80);
            filter.Ratings.Should().NotBeNull();
            filter.Ratings.Begin.Should().Be(40);
            filter.Ratings.End.Should().Be(80);
        }

        [TestMethod]
        public void TestTraktFilterClear()
        {
            var filter = new TraktFilter();

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
            filter.Runtimes.Begin.Should().Be(30);
            filter.Runtimes.End.Should().Be(180);

            filter.WithRatings(60, 90);
            filter.Ratings.Should().NotBeNull();
            filter.Ratings.Begin.Should().Be(60);
            filter.Ratings.End.Should().Be(90);

            filter.Clear();

            filter.Query.Should().BeNull();
            filter.Years.Should().Be(0);
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktFilterToString()
        {
            var filter = new TraktFilter();

            filter.ToString().Should().NotBeNull().And.BeEmpty();

            filter.WithQuery("query");
            filter.ToString().Should().Be("query=query");

            var year = 2016;

            filter.WithYears(year);
            filter.ToString().Should().Be($"query=query&years={year}");

            filter.WithGenres("action", "drama", "fantasy");
            filter.ToString().Should().Be($"query=query&years={year}&genres=action,drama,fantasy");

            filter.WithLanguages("de", "en", "es");
            filter.ToString().Should().Be($"query=query&years={year}&genres=action,drama,fantasy&languages=de,en,es");

            filter.WithCountries("gb", "us", "fr");
            filter.ToString().Should().Be($"query=query&years={year}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr");

            var runtimeBegin = 50;
            var runtimeEnd = 100;

            filter.WithRuntimes(runtimeBegin, runtimeEnd);
            filter.ToString().Should().Be($"query=query&years={year}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}");

            var ratingBegin = 70;
            var ratingEnd = 90;

            filter.WithRatings(ratingBegin, ratingEnd);
            filter.ToString().Should().Be($"query=query&years={year}&genres=action,drama,fantasy&languages=de,en,es&countries=gb,us,fr" +
                                          $"&runtimes={runtimeBegin}-{runtimeEnd}&ratings={ratingBegin}-{ratingEnd}");
        }
    }
}
