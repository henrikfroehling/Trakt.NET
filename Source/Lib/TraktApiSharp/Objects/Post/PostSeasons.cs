namespace TraktApiSharp.Objects.Post
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>A collection of season and episode numbers.</summary>
    /// <example>
    /// This example shows an instantiation of this class.
    /// <code>
    /// new PostSeasons
    /// {
    ///     1,
    ///     { 2, new PostEpisodes { 1, 2, 3 } },
    ///     3,
    ///     { 4 }
    /// };
    /// </code>
    /// </example>
    public sealed class PostSeasons : IEnumerable<PostSeason>
    {
        private readonly List<PostSeason> _seasons;

        /// <summary>Initializes a new instance of the <see cref="PostSeasons" /> class.</summary>
        public PostSeasons()
        {
            _seasons = new List<PostSeason>();
        }

        /// <summary>Adds a season number to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        public void Add(int season) => _seasons.Add(new PostSeason(season));

        /// <summary>Adds a season number and a list of episode numbers to the collection.</summary>
        /// <param name="season">The season number, which will be added.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostEpisodes" />.</param>
        public void Add(int season, PostEpisodes episodes) => _seasons.Add(new PostSeason(season, episodes));

        public IEnumerator<PostSeason> GetEnumerator() => _seasons.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>Contains a season number and an optional list of episodes numbers.</summary>
    public sealed class PostSeason
    {
        /// <summary>Initializes a new instance of the <see cref="PostSeason" /> class.</summary>
        public PostSeason() : this(-1) { }

        /// <summary>Initializes a new instance of the <see cref="PostSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        public PostSeason(int number) : this(number, new PostEpisodes()) { }

        /// <summary>Initializes a new instance of the <see cref="PostSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostEpisodes" />.</param>
        public PostSeason(int number, PostEpisodes episodes)
        {
            Number = number;
            Episodes = episodes;
        }

        /// <summary>Gets or sets the number of this season.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets a list of episode numbers. See also <see cref="PostEpisodes" />.</summary>
        public PostEpisodes Episodes { get; set; }
    }

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

            if (episodes != null && episodes.Length > 0)
                _episodes.AddRange(episodes);
        }

        public IEnumerator<int> GetEnumerator() => _episodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
