namespace TraktApiSharp.Objects.Post
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public sealed class PostHistorySeasons : IEnumerable<PostHistorySeason>
    {
        private readonly List<PostHistorySeason> _seasons;

        public PostHistorySeasons()
        {
            _seasons = new List<PostHistorySeason>();
        }

        public void Add(int season) => _seasons.Add(new PostHistorySeason(season));

        public void Add(int season, DateTime watchedAt) => _seasons.Add(new PostHistorySeason(season, watchedAt));

        public void Add(int season, DateTime watchedAt, PostHistoryEpisodes episodes) => _seasons.Add(new PostHistorySeason(season, watchedAt, episodes));

        public void Add(int season, PostHistoryEpisodes episodes) => _seasons.Add(new PostHistorySeason(season, null, episodes));

        public IEnumerator<PostHistorySeason> GetEnumerator() => _seasons.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class PostHistorySeason
    {
        public PostHistorySeason() : this(-1) { }

        public PostHistorySeason(int number) : this(number, null) { }

        public PostHistorySeason(int number, DateTime? watchedAt) : this(number, watchedAt, new PostHistoryEpisodes()) { }

        public PostHistorySeason(int number, DateTime? watchedAt, PostHistoryEpisodes episodes)
        {
            Number = number;
            WatchedAt = watchedAt;
            Episodes = episodes;
        }

        public int Number { get; set; }

        public DateTime? WatchedAt { get; set; }

        public PostHistoryEpisodes Episodes { get; set; }
    }

    public sealed class PostHistoryEpisodes : IEnumerable<PostHistoryEpisode>
    {
        private readonly List<PostHistoryEpisode> _episodes;

        public PostHistoryEpisodes()
        {
            _episodes = new List<PostHistoryEpisode>();
        }

        public void Add(int episode, DateTime? watchedAt = null) => Add(new PostHistoryEpisode(episode, watchedAt));

        public void Add(PostHistoryEpisode episode, params PostHistoryEpisode[] episodes)
        {
            _episodes.Add(episode);

            if (episodes != null && episodes.Length > 0)
                _episodes.AddRange(episodes);
        }

        public IEnumerator<PostHistoryEpisode> GetEnumerator() => _episodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class PostHistoryEpisode
    {
        public PostHistoryEpisode() : this(-1) { }

        public PostHistoryEpisode(int number, DateTime? watchedAt = null)
        {
            Number = number;
            WatchedAt = watchedAt;
        }

        public int Number { get; set; }

        public DateTime? WatchedAt { get; set; }
    }
}
