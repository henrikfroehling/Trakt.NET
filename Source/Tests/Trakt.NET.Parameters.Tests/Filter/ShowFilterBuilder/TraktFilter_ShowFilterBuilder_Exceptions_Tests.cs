namespace TraktNet.Parameters.Tests.Filter
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Parameters;
    using Xunit;

    [TestCategory("Parameters.Filter")]
    public partial class TraktShowFilterBuilder_Tests
    {
        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithQuery_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithQuery(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithQuery_ArgumentException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithQuery(string.Empty)
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithYear_ArgumentOutOfRangeException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithYear(123)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithYear(12345)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithYears_ArgumentOutOfRangeException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithYears(123, 1234)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithYears(1234, 12345)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithYears(2022, 2020)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithGenres_Params_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithGenres(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithGenres_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithGenres(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithLanguages_Params_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithLanguages(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithLanguages_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithLanguages(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithLanguages_Params_ArgumentOutOfRangeException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithLanguages("def")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithLanguages("de", "eng")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithLanguages_ArgumentOutOfRangeException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithLanguages(new List<string> { "def" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithLanguages(new List<string> { "de", "eng" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCountries_Params_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithCountries(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCountries_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithCountries(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCountries_Params_ArgumentOutOfRangeException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithCountries("def")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithCountries("de", "gbr")
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCountries_ArgumentOutOfRangeException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithCountries(new List<string> { "def" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithCountries(new List<string> { "de", "gbr" })
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithRuntimes_ArgumentOutOfRangeException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithRuntimes(120, 90)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStudios_Params_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithStudios(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStudios_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithStudios(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithRatings_ArgumentOutOfRangeException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithRatings(90, 70)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithRatings(101, 70)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithRatings(90, 101)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithVotes_ArgumentOutOfRangeException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithVotes(9000, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithVotes(100001, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithVotes(9000, 100001)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCertifications_Params_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithCertifications(default(string))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithCertifications_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithCertifications(default(List<string>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithNetworkIds_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithNetworkIds(default(List<uint>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStates_Params_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithStates(default(TraktShowStatus))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStates_ArgumentNullException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithStates(default(List<TraktShowStatus>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStates_Params_ArgumentException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithStates(TraktShowStatus.Unspecified)
                .Build();

            act.Should().Throw<ArgumentException>();

            act = () => TraktFilter.NewShowFilter()
                .WithStates(TraktShowStatus.Planned, TraktShowStatus.Unspecified)
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithStates_ArgumentException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithStates(new List<TraktShowStatus> { TraktShowStatus.Unspecified })
                .Build();

            act.Should().Throw<ArgumentException>();

            act = () => TraktFilter.NewShowFilter()
                .WithStates(new List<TraktShowStatus> { TraktShowStatus.Planned, TraktShowStatus.Unspecified })
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithTMDBRatings_ArgumentOutOfRangeException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithTMDBRatings(7, 5)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithTMDBRatings(10.01f, 7)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithTMDBRatings(7, 10.01f)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithTMDBVotes_ArgumentOutOfRangeException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithTMDBVotes(9000, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithTMDBVotes(100001, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithTMDBVotes(9000, 100001)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithIMDBRatings_ArgumentOutOfRangeException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithIMDBRatings(7, 5)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithIMDBRatings(10.01f, 7)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithIMDBRatings(7, 10.01f)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktFilter_ShowFilterBuilder_WithIMDBVotes_ArgumentOutOfRangeException()
        {
            Func<ITraktShowFilter> act = () => TraktFilter.NewShowFilter()
                .WithIMDBVotes(9000, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithIMDBVotes(3000001, 7000)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktFilter.NewShowFilter()
                .WithIMDBVotes(9000, 3000001)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
