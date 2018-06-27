namespace TraktNet.Objects.Post
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>A list of episode numbers.</summary>
    public sealed class PostEpisodes : IEnumerable<int>
    {
        private readonly List<int> _episodes;

        /// <summary>Initializes a new instance of the <see cref="PostEpisodes" /> class.</summary>
        public PostEpisodes()
        {
            _episodes = new List<int>();
        }

        /// <summary>Adds the given episode numbers to the list.</summary>
        /// <param name="episode">An episode number, which will be added to the list.</param>
        /// <param name="episodes">An optional array of episode numbers, which will be added to the list.</param>
        public void Add(int episode, params int[] episodes)
        {
            _episodes.Add(episode);

            if (episodes?.Length > 0)
                _episodes.AddRange(episodes);
        }

        public IEnumerator<int> GetEnumerator() => _episodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
