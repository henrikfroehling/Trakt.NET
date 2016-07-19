namespace TraktApiSharp.Objects.Post
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Utils;

    public sealed class PostHistorySeasons : IEnumerable<PostHistorySeason>
    {
        private readonly List<PostHistorySeason> _seasons;

        public PostHistorySeasons()
        {
            _seasons = new List<PostHistorySeason>();
        }

        public void Add(int season)
        {
            _seasons.Add(new PostHistorySeason(season));
        }

        public void Add(int season, DateTime watchedAt)
        {
            _seasons.Add(new PostHistorySeason(season, watchedAt));
        }

        public void Add(int season, DateTime watchedAt, PostHistoryEpisodes episodes)
        {
            _seasons.Add(new PostHistorySeason(season, watchedAt, episodes));
        }

        public void Add(int season, PostHistoryEpisodes episodes)
        {
            _seasons.Add(new PostHistorySeason(season, null, episodes));
        }

        public IEnumerator<PostHistorySeason> GetEnumerator()
        {
            return _seasons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public sealed class PostHistorySeason : Triple<int, DateTime?, PostHistoryEpisodes>
    {
        public PostHistorySeason() : base()
        {
            Episodes = new PostHistoryEpisodes();
        }

        public PostHistorySeason(int season) : this(season, null) { }

        public PostHistorySeason(int season, DateTime? watchedAt) : this(season, watchedAt, new PostHistoryEpisodes()) { }

        public PostHistorySeason(int season, DateTime? watchedAt, PostHistoryEpisodes episodes) : base(season, watchedAt, episodes) { }

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

        public PostHistoryEpisodes Episodes
        {
            get { return Third; }
            set { Third = value; }
        }
    }

    public sealed class PostHistoryEpisodes : IEnumerable<PostHistoryEpisode>
    {
        private readonly List<PostHistoryEpisode> _episodes;

        public PostHistoryEpisodes() : base()
        {
            _episodes = new List<PostHistoryEpisode>();
        }

        public void Add(int episode, DateTime? watchedAt = null)
        {
            Add(new PostHistoryEpisode(episode, watchedAt));
        }

        public void Add(PostHistoryEpisode episode, params PostHistoryEpisode[] episodes)
        {
            _episodes.Add(episode);

            if (episodes != null && episodes.Length > 0)
                _episodes.AddRange(episodes);
        }

        public IEnumerator<PostHistoryEpisode> GetEnumerator() => _episodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class PostHistoryEpisode : Pair<int, DateTime?>
    {
        public PostHistoryEpisode() : base() { }

        public PostHistoryEpisode(int number, DateTime? watchedAt = null) : base(number, watchedAt) { }

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
