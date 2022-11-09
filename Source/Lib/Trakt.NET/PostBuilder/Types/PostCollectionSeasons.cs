namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using TraktNet.Objects.Basic;

    /// <summary>
    /// A collection of season and episode numbers.
    /// <para>Can also contain metadata and collected datetimes for each season and episode number.</para>
    /// </summary>
    public sealed class PostCollectionSeasons : IEnumerable<PostCollectionSeason>
    {
        private readonly List<PostCollectionSeason> _seasons;

        /// <summary>Initializes a new instance of the <see cref="PostCollectionSeasons" /> class.</summary>
        public PostCollectionSeasons() => _seasons = new List<PostCollectionSeason>();

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="seasonNumber">The season number, which will be added.</param>
        public void Add(int seasonNumber)
            => Add(new PostCollectionSeason(seasonNumber));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="seasonNumber">The season number, which will be added.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostCollectionEpisodes" />.</param>
        public void Add(int seasonNumber, PostCollectionEpisodes episodes)
            => Add(new PostCollectionSeason(seasonNumber, episodes));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="seasonNumber">The season number, which will be added.</param>
        /// <param name="collectedAt">An UTC datetime, when the season was collected.</param>
        public void Add(int seasonNumber, DateTime collectedAt)
            => Add(new PostCollectionSeason(seasonNumber, collectedAt));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="seasonNumber">The season number, which will be added.</param>
        /// <param name="collectedAt">An UTC datetime, when the season was collected.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostCollectionEpisodes" />.</param>
        public void Add(int seasonNumber, DateTime collectedAt, PostCollectionEpisodes episodes)
            => Add(new PostCollectionSeason(seasonNumber, collectedAt, episodes));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="seasonNumber">The season number, which will be added.</param>
        /// <param name="metadata">The metadata of the season.</param>
        public void Add(int seasonNumber, ITraktMetadata metadata)
            => Add(new PostCollectionSeason(seasonNumber, metadata));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="seasonNumber">The season number, which will be added.</param>
        /// <param name="metadata">The metadata of the season.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostCollectionEpisodes" />.</param>
        public void Add(int seasonNumber, ITraktMetadata metadata, PostCollectionEpisodes episodes)
            => Add(new PostCollectionSeason(seasonNumber, metadata, episodes));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="seasonNumber">The season number, which will be added.</param>
        /// <param name="metadata">The metadata of the season.</param>
        /// <param name="collectedAt">An UTC datetime, when the season was collected.</param>
        public void Add(int seasonNumber, ITraktMetadata metadata, DateTime collectedAt)
            => Add(new PostCollectionSeason(seasonNumber, metadata, collectedAt));

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="seasonNumber">The season number, which will be added.</param>
        /// <param name="metadata">The metadata of the season.</param>
        /// <param name="collectedAt">An UTC datetime, when the season was collected.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostCollectionEpisodes" />.</param>
        public void Add(int seasonNumber, ITraktMetadata metadata, DateTime collectedAt, PostCollectionEpisodes episodes)
            => Add(new PostCollectionSeason(seasonNumber, metadata, collectedAt, episodes));

        /// <summary>Adds the given season numbers to the list.</summary>
        /// <param name="season">An season number. See also <see cref="PostCollectionSeason" />.</param>
        /// <param name="seasons">An optional list of season numbers. See also <see cref="PostCollectionSeason" />.</param>
        public void Add(PostCollectionSeason season, params PostCollectionSeason[] seasons)
        {
            _seasons.Add(season);

            if (seasons?.Length > 0)
                _seasons.AddRange(seasons);
        }

        public IEnumerator<PostCollectionSeason> GetEnumerator() => _seasons.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
