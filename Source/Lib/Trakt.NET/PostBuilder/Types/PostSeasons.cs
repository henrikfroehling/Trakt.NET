﻿namespace TraktNet.PostBuilder
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>A collection of season and episode numbers.</summary>
    public sealed class PostSeasons : IEnumerable<PostSeason>
    {
        private readonly List<PostSeason> _seasons;

        /// <summary>Initializes a new instance of the <see cref="PostSeasons" /> class.</summary>
        public PostSeasons() => _seasons = new List<PostSeason>();

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="seasonNumber">The season number, which will be added.</param>
        public void Add(int seasonNumber)
            => Add(new PostSeason(seasonNumber));

        /// <summary>Adds a season number and a list of episode numbers to the collection.</summary>
        /// <param name="seasonNumber">The season number, which will be added.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostEpisodes" />.</param>
        public void Add(int seasonNumber, PostEpisodes episodes)
            => Add(new PostSeason(seasonNumber, episodes));

        /// <summary>Adds the given season numbers to the list.</summary>
        /// <param name="season">An season number, which will be added to the list.</param>
        /// <param name="seasons">An optional array of season numbers, which will be added to the list.</param>
        public void Add(PostSeason season, params PostSeason[] seasons)
        {
            _seasons.Add(season);

            if (seasons?.Length > 0)
                _seasons.AddRange(seasons);
        }

        /// <summary>Adds the given season numbers to the list.</summary>
        /// <param name="seasons">The season numbers, which will be added to the list.</param>
        public void Add(IEnumerable<int> seasons)
        {
            if (seasons != null)
            {
                foreach (int season in seasons)
                    Add(season);
            }
        }

        /// <summary>Adds the given season numbers to the list.</summary>
        /// <param name="season">An season number, which will be added to the list.</param>
        /// <param name="seasons">An optional array of season numbers, which will be added to the list.</param>
        public void Add(int season, params int[] seasons)
        {
            Add(season);

            if (seasons?.Length > 0)
            {
                foreach (int seasonValue in seasons)
                    Add(seasonValue);
            }
        }

        public IEnumerator<PostSeason> GetEnumerator() => _seasons.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
