namespace TraktNET.Enums
{
    public sealed class TraktEpisodeTypeTests
    {
        [Fact]
        public void TestTraktEpisodeTypeToJson()
        {
            TraktEpisodeType.Unspecified.ToJson().Should().BeNull();
            TraktEpisodeType.Standard.ToJson().Should().Be("standard");
            TraktEpisodeType.SeriesPremiere.ToJson().Should().Be("series_premiere");
            TraktEpisodeType.SeasonPremiere.ToJson().Should().Be("season_premiere");
            TraktEpisodeType.MidSeasonFinale.ToJson().Should().Be("mid_season_finale");
            TraktEpisodeType.MidSeasonPremiere.ToJson().Should().Be("mid_season_premiere");
            TraktEpisodeType.SeasonFinale.ToJson().Should().Be("season_finale");
            TraktEpisodeType.SeriesFinale.ToJson().Should().Be("series_finale");
        }

        [Fact]
        public void TestTraktEpisodeTypeFromJson()
        {
            "unspecified".ToTraktEpisodeType().Should().Be(TraktEpisodeType.Unspecified);
            "standard".ToTraktEpisodeType().Should().Be(TraktEpisodeType.Standard);
            "series_premiere".ToTraktEpisodeType().Should().Be(TraktEpisodeType.SeriesPremiere);
            "season_premiere".ToTraktEpisodeType().Should().Be(TraktEpisodeType.SeasonPremiere);
            "mid_season_finale".ToTraktEpisodeType().Should().Be(TraktEpisodeType.MidSeasonFinale);
            "mid_season_premiere".ToTraktEpisodeType().Should().Be(TraktEpisodeType.MidSeasonPremiere);
            "season_finale".ToTraktEpisodeType().Should().Be(TraktEpisodeType.SeasonFinale);
            "series_finale".ToTraktEpisodeType().Should().Be(TraktEpisodeType.SeriesFinale);

            string? nullValue = null;
            nullValue.ToTraktEpisodeType().Should().Be(TraktEpisodeType.Unspecified);
        }

        [Fact]
        public void TestTraktEpisodeTypeDisplayName()
        {
            TraktEpisodeType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktEpisodeType.Standard.DisplayName().Should().Be("Standard");
            TraktEpisodeType.SeriesPremiere.DisplayName().Should().Be("Series Premiere");
            TraktEpisodeType.SeasonPremiere.DisplayName().Should().Be("Season Premiere");
            TraktEpisodeType.MidSeasonFinale.DisplayName().Should().Be("Mid Season Finale");
            TraktEpisodeType.MidSeasonPremiere.DisplayName().Should().Be("Mid Season Premiere");
            TraktEpisodeType.SeasonFinale.DisplayName().Should().Be("Season Finale");
            TraktEpisodeType.SeriesFinale.DisplayName().Should().Be("Series Finale");
        }
    }
}
