namespace TraktNet.Requests.Tests.Parameters
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Parameters.Filter;
    using Xunit;

    [Category("Requests.Parameters")]
    public class TraktMovieFilter_Tests
    {
        [Fact]
        public void Test_TraktMovieFilterBuilder_EmptyFilter()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.Build();

            filter.Query.Should().BeNull();
            filter.Year.Should().BeNull();
            filter.Years.Should().BeNull();
            filter.Genres.Should().BeNull();
            filter.Languages.Should().BeNull();
            filter.Countries.Should().BeNull();
            filter.Runtimes.Should().BeNull();
            filter.Ratings.Should().BeNull();
            filter.Certifications.Should().BeNull();
            filter.HasValues.Should().BeFalse();
            filter.ToString().Should().NotBeNull().And.BeEmpty();
            filter.GetParameters().Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_HasValues()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.Build();
            filter.HasValues.Should().BeFalse();

            filter = TraktFilterDirectory.MovieFilter.WithQuery("query").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.MovieFilter.WithYear(2018).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.MovieFilter.WithYears(2016, 2018).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.MovieFilter.WithGenres("action", "drama").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.MovieFilter.WithLanguages("de", "en").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.MovieFilter.WithCountries("gb", "us").Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.MovieFilter.WithRuntimes(30, 180).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.MovieFilter.WithRatings(60, 90).Build();
            filter.HasValues.Should().BeTrue();

            filter = TraktFilterDirectory.MovieFilter.WithCertifications("pg-13", "nr").Build();
            filter.HasValues.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_GetParameters_With_Query()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithQuery("query").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" } });
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_GetParameters_With_Year()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithYear(2018).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", "2018" } });
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_GetParameters_With_Years()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithYears(2016, 2018).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", "2016-2018" } });
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_GetParameters_With_Years_Reversed()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithYears(2018, 2016).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "years", "2016-2018" } });
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_GetParameters_With_Genres()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithGenres("action", "drama").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "genres", "action,drama" } });
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_GetParameters_With_Languages()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithLanguages("de", "en").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "languages", "de,en" } });
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_GetParameters_With_Countries()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithCountries("gb", "us").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "countries", "gb,us" } });
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_GetParameters_With_Runtimes()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithRuntimes(30, 180).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "runtimes", "30-180" } });
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_GetParameters_With_Ratings()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithRatings(60, 90).Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "ratings", "60-90" } });
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_GetParameters_With_Certifications()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithCertifications("pg-13", "nr").Build();
            filter.GetParameters().Should().NotBeNull().And.HaveCount(1);
            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "certifications", "pg-13,nr" } });
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_GetParameters()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter
                .WithQuery("query")
                .WithYears(2016, 2018)
                .WithGenres("action", "drama")
                .WithLanguages("de", "en")
                .WithCountries("gb", "us")
                .WithRuntimes(30, 180)
                .WithRatings(60, 90)
                .WithCertifications("pg-13", "nr")
                .Build();

            filter.GetParameters().Should().NotBeNull().And.HaveCount(8);

            filter.GetParameters().Should().Contain(new Dictionary<string, object>() { { "query", "query" },
                                                                                       { "years", "2016-2018" },
                                                                                       { "genres", "action,drama" },
                                                                                       { "languages", "de,en" },
                                                                                       { "countries", "gb,us" },
                                                                                       { "runtimes", "30-180" },
                                                                                       { "ratings", "60-90" },
                                                                                       { "certifications", "pg-13,nr" } });
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_ToString_With_Query()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithQuery("query").Build();
            filter.ToString().Should().Be("query=query");
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_ToString_With_Year()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithYear(2018).Build();
            filter.ToString().Should().Be("years=2018");
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_ToString_With_Years()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithYears(2016, 2018).Build();
            filter.ToString().Should().Be("years=2016-2018");
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_ToString_With_Years_Reversed()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithYears(2018, 2016).Build();
            filter.ToString().Should().Be("years=2016-2018");
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_ToString_With_Genres()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithGenres("action", "drama").Build();
            filter.ToString().Should().Be("genres=action,drama");
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_ToString_With_Languages()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithLanguages("de", "en").Build();
            filter.ToString().Should().Be("languages=de,en");
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_ToString_With_Countries()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithCountries("gb", "us").Build();
            filter.ToString().Should().Be("countries=gb,us");
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_ToString_With_Runtimes()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithRuntimes(30, 180).Build();
            filter.ToString().Should().Be("runtimes=30-180");
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_ToString_With_Ratings()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithRatings(60, 90).Build();
            filter.ToString().Should().Be("ratings=60-90");
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_ToString_With_Certifications()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter.WithCertifications("pg-13", "nr").Build();
            filter.ToString().Should().Be("certifications=pg-13,nr");
        }

        [Fact]
        public void Test_TraktMovieFilterBuilder_ToString()
        {
            ITraktMovieFilter filter = TraktFilterDirectory.MovieFilter
                .WithQuery("query")
                .WithYears(2016, 2018)
                .WithGenres("action", "drama")
                .WithLanguages("de", "en")
                .WithCountries("gb", "us")
                .WithRuntimes(30, 180)
                .WithRatings(60, 90)
                .WithCertifications("pg-13", "nr")
                .Build();

            filter.ToString().Should().Be("query=query&years=2016-2018&genres=action,drama&languages=de,en" +
                                          "&countries=gb,us&runtimes=30-180&ratings=60-90&certifications=pg-13,nr");
        }
    }
}
