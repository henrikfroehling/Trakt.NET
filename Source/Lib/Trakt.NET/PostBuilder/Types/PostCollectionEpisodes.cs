namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using TraktNet.Objects.Basic;

    /// <summary>
    /// A list of episode numbers.
    /// <para>Each episode number can have optional metadata and an optional datetime, when it was collected.</para>
    /// </summary>
    public sealed class PostCollectionEpisodes : IEnumerable<PostCollectionEpisode>
    {
        private readonly List<PostCollectionEpisode> _episodes;

        /// <summary>Initializes a new instance of the <see cref="PostCollectionEpisodes" /> class.</summary>
        public PostCollectionEpisodes() => _episodes = new List<PostCollectionEpisode>();

        /// <summary>Adds the given episode number to the list.</summary>
        /// <param name="episodeNumber">The episode number, which will be added to the list.</param>
        public void Add(int episodeNumber)
            => Add(new PostCollectionEpisode(episodeNumber));

        /// <summary>Adds the given episode number to the list.</summary>
        /// <param name="episodeNumber">The episode number, which will be added to the list.</param>
        /// <param name="collectedAt">An UTC datetime, when the episode was collected.</param>
        public void Add(int episodeNumber, DateTime collectedAt)
            => Add(new PostCollectionEpisode(episodeNumber, collectedAt));

        /// <summary>Adds the given episode number to the list.</summary>
        /// <param name="episodeNumber">The episode number, which will be added to the list.</param>
        /// <param name="metadata">The metadata of the episode.</param>
        public void Add(int episodeNumber, ITraktMetadata metadata)
            => Add(new PostCollectionEpisode(episodeNumber, metadata));

        /// <summary>Adds the given episode number to the list.</summary>
        /// <param name="episodeNumber">The episode number, which will be added to the list.</param>
        /// <param name="metadata">The metadata of the episode.</param>
        /// <param name="collectedAt">An UTC datetime, when the episode was collected.</param>
        public void Add(int episodeNumber, ITraktMetadata metadata, DateTime collectedAt)
            => Add(new PostCollectionEpisode(episodeNumber, metadata, collectedAt));

        /// <summary>Adds the given episode numbers to the list.</summary>
        /// <param name="episode">An episode number. See also <see cref="PostCollectionEpisode" />.</param>
        /// <param name="episodes">An optional list of episode numbers. See also <see cref="PostCollectionEpisode" />.</param>
        public void Add(PostCollectionEpisode episode, params PostCollectionEpisode[] episodes)
        {
            _episodes.Add(episode);

            if (episodes?.Length > 0)
                _episodes.AddRange(episodes);
        }

        public IEnumerator<PostCollectionEpisode> GetEnumerator() => _episodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
