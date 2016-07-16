namespace TraktApiSharp.Objects.Post
{
    using System;
    using Utils;

    public sealed class HistorySAE
    {
        public HistorySAE(int number, DateTime watchedAt)
        {
            Number = number;
            WatchedAt = watchedAt;
        }

        public HistorySAE(int number, HistorySeasonOrEpisode[] episodes)
        {
            Number = number;
            Episodes = episodes;
        }

        public HistorySAE(int number, DateTime watchedAt, HistorySeasonOrEpisode[] episodes)
        {
            Number = number;
            WatchedAt = watchedAt;
            Episodes = episodes;
        }

        public int Number { get; set; }

        public DateTime? WatchedAt { get; set; }

        public HistorySeasonOrEpisode[] Episodes { get; set; }
    }

    public sealed class HistorySeasonOrEpisode : Pair<int, DateTime?>
    {
        public HistorySeasonOrEpisode(int number, DateTime? watchedAt = null)
        {
            First = number;
            Second = watchedAt;
        }

        public int Number
        {
            get { return First; }
            set { First = value; }
        }

        public DateTime? WatchedAt
        {
            get { return Second; }
            set { Second = value; }
        }
    }
}
