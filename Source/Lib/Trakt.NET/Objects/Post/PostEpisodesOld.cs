namespace TraktNet.Objects.Post
{
    using Objects.Basic;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>A list of episode numbers.</summary>
    public sealed class PostEpisodesOld : IEnumerable<PostEpisodeOld>
    {
        private readonly List<PostEpisodeOld> _episodes;

        /// <summary>Initializes a new instance of the <see cref="PostEpisodesOld" /> class.</summary>
        public PostEpisodesOld()
        {
            _episodes = new List<PostEpisodeOld>();
        }

        /// <summary>Adds the given episode number to the list.</summary>
        /// <param name="episode">The episode number, which will be added to the list.</param>
        /// <param name="metadata">Metadata about the given episode.</param>
        /// <param name="at">An UTC datetime.</param>
        public void Add(int episode, ITraktMetadata metadata = null, DateTime? at = null) => _episodes.Add(new PostEpisodeOld(episode, metadata, at));

        /// <summary>Adds the given episode numbers to the list.</summary>
        /// <param name="episode">An episode number, which will be added to the list.</param>
        /// <param name="episodes">An optional array of episode numbers, which will be added to the list.</param>
        public void Add(PostEpisodeOld episode, params PostEpisodeOld[] episodes)
        {
            _episodes.Add(episode);

            if (episodes?.Length > 0)
                _episodes.AddRange(episodes);
        }

        public IEnumerator<PostEpisodeOld> GetEnumerator() => _episodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
