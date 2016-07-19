namespace TraktApiSharp.Objects.Post
{
    using System.Collections;
    using System.Collections.Generic;
    using Utils;

    public sealed class PostSeasons : IEnumerable<PostSeason>
    {
        private readonly List<PostSeason> _seasons;

        public PostSeasons()
        {
            _seasons = new List<PostSeason>();
        }

        public void Add(int season)
        {
            _seasons.Add(new PostSeason(season));
        }

        public void Add(int season, PostEpisodes episodes)
        {
            _seasons.Add(new PostSeason(season, episodes));
        }

        public IEnumerator<PostSeason> GetEnumerator()
        {
            return _seasons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public sealed class PostSeason : Pair<int, PostEpisodes>
    {
        public PostSeason() : base()
        {
            Episodes = new PostEpisodes();
        }

        public PostSeason(int season) : this(season, new PostEpisodes()) { }

        public PostSeason(int season, PostEpisodes episodes) : base(season, episodes) { }

        public int Season
        {
            get { return First; }
            set { First = value; }
        }

        public PostEpisodes Episodes
        {
            get { return Second; }
            set { Second = value; }
        }
    }

    public sealed class PostEpisodes : IEnumerable<int>
    {
        private readonly List<int> _episodes;

        public PostEpisodes()
        {
            _episodes = new List<int>();
        }

        public void Add(int episode, params int[] episodes)
        {
            _episodes.Add(episode);

            if (episodes != null && episodes.Length > 0)
                _episodes.AddRange(episodes);
        }

        public IEnumerator<int> GetEnumerator() => _episodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
