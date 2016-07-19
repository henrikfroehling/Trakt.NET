namespace TraktApiSharp.Objects.Post
{
    using System.Collections;
    using System.Collections.Generic;

    public sealed class PostSeasons : IDictionary<int, PostEpisodes>
    {
        private readonly Dictionary<int, PostEpisodes> _seasons;

        public PostSeasons()
        {
            _seasons = new Dictionary<int, PostEpisodes>();
        }

        public PostSeasons(int season) : base()
        {
            Add(season);
        }

        public PostEpisodes this[int key]
        {
            get { return _seasons[key]; }
            set { _seasons[key] = value; }
        }

        public int Count => _seasons.Count;

        public bool IsReadOnly => false;

        public ICollection<int> Keys => _seasons.Keys;

        public ICollection<PostEpisodes> Values => _seasons.Values;

        public void Add(KeyValuePair<int, PostEpisodes> item) => Add(item.Key, item.Value);

        public void Add(int season, PostEpisodes episodes) => _seasons.Add(season, episodes);

        public void Add(int season) => _seasons.Add(season, new PostEpisodes());

        public void Clear() => _seasons.Clear();

        public bool Contains(KeyValuePair<int, PostEpisodes> item) => ContainsKey(item.Key);

        public bool ContainsKey(int season) => _seasons.ContainsKey(season);

        public void CopyTo(KeyValuePair<int, PostEpisodes>[] array, int arrayIndex) => (_seasons as IDictionary).CopyTo(array, arrayIndex);

        public IEnumerator<KeyValuePair<int, PostEpisodes>> GetEnumerator() => _seasons.GetEnumerator();

        public bool Remove(KeyValuePair<int, PostEpisodes> item) => _seasons.Remove(item.Key);

        public bool Remove(int season) => _seasons.Remove(season);

        public bool TryGetValue(int season, out PostEpisodes episodes) => _seasons.TryGetValue(season, out episodes);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
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
