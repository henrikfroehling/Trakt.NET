namespace TraktApiSharp.Objects.Post
{
    using System.Collections;
    using System.Collections.Generic;

    public sealed class PostSeasons : IEnumerable<PostSeason>
    {
        private readonly List<PostSeason> _seasons;

        public PostSeasons()
        {
            _seasons = new List<PostSeason>();
        }

        public void Add(int season) => _seasons.Add(new PostSeason(season));

        public void Add(int season, PostEpisodes episodes) => _seasons.Add(new PostSeason(season, episodes));

        public IEnumerator<PostSeason> GetEnumerator() => _seasons.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class PostSeason
    {
        public PostSeason() : this(-1) { }

        public PostSeason(int number) : this(number, new PostEpisodes()) { }

        public PostSeason(int number, PostEpisodes episodes)
        {
            Number = number;
            Episodes = episodes;
        }

        public int Number { get; set; }

        public PostEpisodes Episodes { get; set; }
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
