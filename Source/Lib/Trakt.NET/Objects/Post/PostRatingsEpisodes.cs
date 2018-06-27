namespace TraktNet.Objects.Post
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A list of episode numbers.
    /// <para>Each episode number can have an optional rating and an optional datetime, when it was rated.</para>
    /// </summary>
    public sealed class PostRatingsEpisodes : IEnumerable<PostRatingsEpisode>
    {
        private readonly List<PostRatingsEpisode> _episodes;

        /// <summary>Initializes a new instance of the <see cref="PostRatingsEpisodes" /> class.</summary>
        public PostRatingsEpisodes()
        {
            _episodes = new List<PostRatingsEpisode>();
        }

        /// <summary>Adds the given episode number to the list.</summary>
        /// <param name="episode">The episode number, which will be added to the list.</param>
        public void Add(int episode) => _episodes.Add(new PostRatingsEpisode(episode));

        /// <summary>Adds the given episode number to the list.</summary>
        /// <param name="episode">The episode number, which will be added to the list.</param>
        /// <param name="rating">A rating for the episode.</param>
        /// <param name="ratedAt">An UTC datetime, when the episode was rated.</param>
        public void Add(int episode, int rating, DateTime? ratedAt = null) => _episodes.Add(new PostRatingsEpisode(episode, rating, ratedAt));

        public void Add(PostRatingsEpisode episode, params PostRatingsEpisode[] episodes)
        {
            _episodes.Add(episode);

            if (episodes?.Length > 0)
                _episodes.AddRange(episodes);
        }

        public IEnumerator<PostRatingsEpisode> GetEnumerator() => _episodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
