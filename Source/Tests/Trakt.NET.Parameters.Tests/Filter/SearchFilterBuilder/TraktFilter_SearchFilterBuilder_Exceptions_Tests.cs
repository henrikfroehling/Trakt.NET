namespace TraktNet.Parameters.Tests.Filter
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Parameters;
    using Xunit;

    [TestCategory("Parameters.Filter")]
    public partial class TraktSearchFilterBuilder_Tests
    {
        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithQuery_ArgumentNullException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithQuery(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithQuery_ArgumentException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithQuery(string.Empty)
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithYear_ArgumentOutOfRangeException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithYear(123)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithYear(12345)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithYears_ArgumentOutOfRangeException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithYears(123, 1234)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithYears(1234, 12345)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithYears(2022, 2020)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithGenres_Params_ArgumentNullException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithGenres(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithGenres_ArgumentNullException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithGenres(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithLanguages_Params_ArgumentNullException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithLanguages(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithLanguages_ArgumentNullException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithLanguages(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithLanguages_Params_ArgumentOutOfRangeException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithLanguages("def")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithLanguages("de", "eng")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithLanguages_ArgumentOutOfRangeException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithLanguages(new List<string> { "def" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithLanguages(new List<string> { "de", "eng" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCountries_Params_ArgumentNullException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithCountries(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCountries_ArgumentNullException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithCountries(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCountries_Params_ArgumentOutOfRangeException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithCountries("def")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithCountries("de", "gbr")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCountries_ArgumentOutOfRangeException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithCountries(new List<string> { "def" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithCountries(new List<string> { "de", "gbr" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithRuntimes_ArgumentOutOfRangeException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithRuntimes(120, 90)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithStudios_Params_ArgumentNullException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithStudios(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithStudios_ArgumentNullException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithStudios(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithRatings_ArgumentOutOfRangeException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithRatings(90, 70)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithRatings(101, 70)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithRatings(90, 101)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithVotes_ArgumentOutOfRangeException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithVotes(9000, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithVotes(100001, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithVotes(9000, 100001)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCertifications_Params_ArgumentNullException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithCertifications(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithCertifications_ArgumentNullException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithCertifications(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithTMDBRatings_ArgumentOutOfRangeException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithTMDBRatings(7, 5)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithTMDBRatings(10.01f, 7)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithTMDBRatings(7, 10.01f)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithTMDBVotes_ArgumentOutOfRangeException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithTMDBVotes(9000, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithTMDBVotes(100001, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithTMDBVotes(9000, 100001)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithIMDBRatings_ArgumentOutOfRangeException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithIMDBRatings(7, 5)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithIMDBRatings(10.01f, 7)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithIMDBRatings(7, 10.01f)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_SearchFilterBuilder_WithIMDBVotes_ArgumentOutOfRangeException()
        {
            Func<ITraktSearchFilter> act = () => TraktFilter.NewSearchFilter()
                .WithIMDBVotes(9000, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithIMDBVotes(3000001, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewSearchFilter()
                .WithIMDBVotes(9000, 3000001)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
