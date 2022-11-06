namespace TraktNet.Parameters.Tests.Filter
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Parameters;
    using Xunit;

    [TestCategory("Parameters.Filter")]
    public partial class TraktMovieFilterBuilder_Tests
    {
        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithQuery_ArgumentNullException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithQuery(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithQuery_ArgumentException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithQuery(string.Empty)
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithYear_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithYear(123)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithYear(12345)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithYears_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithYears(123, 1234)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithYears(1234, 12345)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithYears(2022, 2020)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithGenres_Params_ArgumentNullException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithGenres(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithGenres_ArgumentNullException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithGenres(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithLanguages_Params_ArgumentNullException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithLanguages(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithLanguages_ArgumentNullException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithLanguages(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithLanguages_Params_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithLanguages("def")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithLanguages("de", "eng")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithLanguages_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithLanguages(new List<string> { "def" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithLanguages(new List<string> { "de", "eng" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCountries_Params_ArgumentNullException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithCountries(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCountries_ArgumentNullException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithCountries(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCountries_Params_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithCountries("def")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithCountries("de", "gbr")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCountries_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithCountries(new List<string> { "def" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithCountries(new List<string> { "de", "gbr" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithRuntimes_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithRuntimes(120, 90)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithStudios_Params_ArgumentNullException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithStudios(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithStudios_ArgumentNullException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithStudios(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithRatings_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithRatings(90, 70)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithRatings(101, 70)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithRatings(90, 101)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithVotes_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithVotes(9000, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithVotes(100001, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithVotes(9000, 100001)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCertifications_Params_ArgumentNullException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithCertifications(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithCertifications_ArgumentNullException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithCertifications(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithTMDBRatings_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithTMDBRatings(7, 5)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithTMDBRatings(10.01f, 7)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithTMDBRatings(7, 10.01f)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithTMDBVotes_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithTMDBVotes(9000, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithTMDBVotes(100001, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithTMDBVotes(9000, 100001)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithIMDBRatings_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithIMDBRatings(7, 5)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithIMDBRatings(10.01f, 7)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithIMDBRatings(7, 10.01f)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithIMDBVotes_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithIMDBVotes(9000, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithIMDBVotes(3000001, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithIMDBVotes(9000, 3000001)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithRottenTomatoesMeter_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithRottenTomatoesMeter(70, 50)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithRottenTomatoesMeter(100.01f, 70)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithRottenTomatoesMeter(70, 100.01f)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_MovieFilterBuilder_WithMetascores_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieFilter> act = () => TraktFilter.NewMovieFilter()
                .WithMetascores(70, 50)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithMetascores(100.01f, 70)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewMovieFilter()
                .WithMetascores(70, 100.01f)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
