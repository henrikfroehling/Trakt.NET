namespace TraktNET
{
    public class TraktSeason
    {
        public uint? Number { get; set; }

        public TraktSeasonIds? Ids { get; set; }

        public float? Rating { get; set; }

        public uint? Votes { get; set; }

        public uint? EpisodeCount { get; set; }

        public uint? AiredEpisodes { get; set; }

        public string? Title { get; set; }

        public string? Overview { get; set; }

        public DateTime? FirstAired { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? Network { get; set; }

        public IList<TraktEpisode>? Episodes { get; set; }
    }
}
