namespace TraktNet.Objects.Post
{
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
}
