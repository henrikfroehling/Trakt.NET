namespace TraktNet.Objects.Post
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A list of episode numbers.
    /// <para>Each episode number can have an optional datetime, when it was watched.</para>
    /// </summary>
    public sealed class PostHistoryEpisodes : IEnumerable<PostHistoryEpisode>
    {
        private readonly List<PostHistoryEpisode> _episodes;

        /// <summary>Initializes a new instance of the <see cref="PostHistoryEpisodes" /> class.</summary>
        public PostHistoryEpisodes() => _episodes = new List<PostHistoryEpisode>();

        /// <summary>Adds the given episode number to the list.</summary>
        /// <param name="episodeNumber">The episode number, which will be added to the list.</param>
        public void Add(int episodeNumber)
            => Add(new PostHistoryEpisode(episodeNumber));

        /// <summary>Adds the given episode number to the list.</summary>
        /// <param name="episodeNumber">The episode number, which will be added to the list.</param>
        /// <param name="watchedAt">An UTC datetime, when the episode was watched.</param>
        public void Add(int episodeNumber, DateTime watchedAt)
            => Add(new PostHistoryEpisode(episodeNumber, watchedAt));

        /// <summary>Adds the given episode numbers to the list.</summary>
        /// <param name="episode">An episode number. See also <see cref="PostHistoryEpisode" />.</param>
        /// <param name="episodes">An optional list of episode numbers. See also <see cref="PostHistoryEpisode" />.</param>
        public void Add(PostHistoryEpisode episode, params PostHistoryEpisode[] episodes)
        {
            _episodes.Add(episode);

            if (episodes?.Length > 0)
                _episodes.AddRange(episodes);
        }

        public IEnumerator<PostHistoryEpisode> GetEnumerator() => _episodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
