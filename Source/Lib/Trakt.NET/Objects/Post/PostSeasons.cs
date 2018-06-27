namespace TraktNet.Objects.Post
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
}
