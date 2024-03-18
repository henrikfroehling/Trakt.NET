namespace TraktNet.Enums
{
    /// <summary>Determines the type of an episode.</summary>
    public sealed class TraktEpisodeType : TraktEnumeration
    {
        /// <summary>An invalid episode type.</summary>
        public static TraktEpisodeType Unspecified { get; } = new TraktEpisodeType();

        /// <summary>The type for a standard episode.</summary>
        public static TraktEpisodeType Standard { get; } = new TraktEpisodeType(1, "standard", "standard", "Standard");

        /// <summary>The type for a series premiere episode (season 1, episode 1).</summary>
        public static TraktEpisodeType SeriesPremiere { get; } = new TraktEpisodeType(2, "series_premiere", "series_premiere", "Series Premiere");

        /// <summary>The type for a season premiere episode (episode 1).</summary>
        public static TraktEpisodeType SeasonPremiere { get; } = new TraktEpisodeType(4, "season_premiere", "season_premiere", "Season Premiere");

        /// <summary>The type for a mid season finale episode.</summary>
        public static TraktEpisodeType MidSeasonFinale { get; } = new TraktEpisodeType(8, "mid_season_finale", "mid_season_finale", "Mid Season Finale");

        /// <summary>The type for a mid season premiere episode (the next episode after the mid season finale).</summary>
        public static TraktEpisodeType MidSeasonPremiere { get; } = new TraktEpisodeType(16, "mid_season_premiere", "mid_season_premiere", "Mid Season Premiere");

        /// <summary>The type for a season finale episode.</summary>
        public static TraktEpisodeType SeasonFinale { get; } = new TraktEpisodeType(32, "season_finale", "season_finale", "Season Finale");

        /// <summary>The type for a series finale episode (last episode to air for an ended show).</summary>
        public static TraktEpisodeType SeriesFinale { get; } = new TraktEpisodeType(64, "series_finale", "series_finale", "Series Finale");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktEpisodeType" /> class.<para />
        /// The initialized <see cref="TraktEpisodeType" /> is invalid.
        /// </summary>
        public TraktEpisodeType()
        {
        }

        private TraktEpisodeType(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
