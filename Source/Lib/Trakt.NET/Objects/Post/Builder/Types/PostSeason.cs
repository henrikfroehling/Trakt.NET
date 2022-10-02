namespace TraktNet.Objects.Post
{
    /// <summary>Contains a season number and an optional list of episodes numbers.</summary>
    public sealed class PostSeason
    {
        /// <summary>Gets the number of this season.</summary>
        public int Number { get; }

        /// <summary>Gets a list of episode numbers. See also <see cref="PostEpisodes" />.</summary>
        public PostEpisodes Episodes { get; }

        /// <summary>Initializes a new instance of the <see cref="PostSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        public PostSeason(int number) => Number = number;

        /// <summary>Initializes a new instance of the <see cref="PostSeason" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostEpisodes" />.</param>
        public PostSeason(int number, PostEpisodes episodes)
            : this(number)
            => Episodes = episodes;
    }
}
