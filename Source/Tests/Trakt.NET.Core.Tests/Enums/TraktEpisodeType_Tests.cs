namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktEpisodeType_Tests
    {
        [Fact]
        public void Test_TraktEpisodeType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktEpisodeType>();

            allValues.Should().NotBeNull().And.HaveCount(8);
            allValues.Should().Contain(new List<TraktEpisodeType>() { TraktEpisodeType.Unspecified, TraktEpisodeType.Standard,
                                                                      TraktEpisodeType.SeriesPremiere, TraktEpisodeType.SeasonPremiere,
                                                                      TraktEpisodeType.MidSeasonFinale, TraktEpisodeType.MidSeasonPremiere,
                                                                      TraktEpisodeType.SeasonFinale, TraktEpisodeType.SeriesFinale });
        }

        [Fact]
        public void Test_TraktEpisodeType_Properties()
        {
            TraktEpisodeType.Standard.Value.Should().Be(1);
            TraktEpisodeType.Standard.ObjectName.Should().Be("standard");
            TraktEpisodeType.Standard.UriName.Should().Be("standard");
            TraktEpisodeType.Standard.DisplayName.Should().Be("Standard");

            TraktEpisodeType.SeriesPremiere.Value.Should().Be(2);
            TraktEpisodeType.SeriesPremiere.ObjectName.Should().Be("series_premiere");
            TraktEpisodeType.SeriesPremiere.UriName.Should().Be("series_premiere");
            TraktEpisodeType.SeriesPremiere.DisplayName.Should().Be("Series Premiere");

            TraktEpisodeType.SeasonPremiere.Value.Should().Be(4);
            TraktEpisodeType.SeasonPremiere.ObjectName.Should().Be("season_premiere");
            TraktEpisodeType.SeasonPremiere.UriName.Should().Be("season_premiere");
            TraktEpisodeType.SeasonPremiere.DisplayName.Should().Be("Season Premiere");

            TraktEpisodeType.MidSeasonFinale.Value.Should().Be(8);
            TraktEpisodeType.MidSeasonFinale.ObjectName.Should().Be("mid_season_finale");
            TraktEpisodeType.MidSeasonFinale.UriName.Should().Be("mid_season_finale");
            TraktEpisodeType.MidSeasonFinale.DisplayName.Should().Be("Mid Season Finale");

            TraktEpisodeType.MidSeasonPremiere.Value.Should().Be(16);
            TraktEpisodeType.MidSeasonPremiere.ObjectName.Should().Be("mid_season_premiere");
            TraktEpisodeType.MidSeasonPremiere.UriName.Should().Be("mid_season_premiere");
            TraktEpisodeType.MidSeasonPremiere.DisplayName.Should().Be("Mid Season Premiere");

            TraktEpisodeType.SeasonFinale.Value.Should().Be(32);
            TraktEpisodeType.SeasonFinale.ObjectName.Should().Be("season_finale");
            TraktEpisodeType.SeasonFinale.UriName.Should().Be("season_finale");
            TraktEpisodeType.SeasonFinale.DisplayName.Should().Be("Season Finale");

            TraktEpisodeType.SeriesFinale.Value.Should().Be(64);
            TraktEpisodeType.SeriesFinale.ObjectName.Should().Be("series_finale");
            TraktEpisodeType.SeriesFinale.UriName.Should().Be("series_finale");
            TraktEpisodeType.SeriesFinale.DisplayName.Should().Be("Series Finale");
        }
    }
}
