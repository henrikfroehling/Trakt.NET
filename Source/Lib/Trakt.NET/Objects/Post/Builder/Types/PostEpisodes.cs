namespace TraktNet.Objects.Post
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>A list of episode numbers.</summary>
    public sealed class PostEpisodes : IEnumerable<PostEpisode>
    {
        private readonly List<PostEpisode> _episodes;

        /// <summary>Initializes a new instance of the <see cref="PostEpisodes" /> class.</summary>
        public PostEpisodes() => _episodes = new List<PostEpisode>();

        /// <summary>Adds the given episode number to the list.</summary>
        /// <param name="episodeNumber">The episode number, which will be added to the list.</param>
        public void Add(int episodeNumber)
            => Add(new PostEpisode(episodeNumber));

        /// <summary>Adds the given episode numbers to the list.</summary>
        /// <param name="episode">An episode number, which will be added to the list.</param>
        /// <param name="episodes">An optional array of episode numbers, which will be added to the list.</param>
        public void Add(PostEpisode episode, params PostEpisode[] episodes)
        {
            _episodes.Add(episode);

            if (episodes?.Length > 0)
                _episodes.AddRange(episodes);
        }

        public IEnumerator<PostEpisode> GetEnumerator() => _episodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
