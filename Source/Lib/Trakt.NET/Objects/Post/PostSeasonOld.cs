namespace TraktNet.Objects.Post
{
    /// <summary>Contains a season number and an optional list of episodes numbers.</summary>
    public sealed class PostSeasonOld
    {
        /// <summary>Initializes a new instance of the <see cref="PostSeasonOld" /> class.</summary>
        public PostSeasonOld() : this(-1) { }

        /// <summary>Initializes a new instance of the <see cref="PostSeasonOld" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        public PostSeasonOld(int number) : this(number, new PostEpisodesOld()) { }

        /// <summary>Initializes a new instance of the <see cref="PostSeasonOld" /> class.</summary>
        /// <param name="number">The number of this season.</param>
        /// <param name="episodes">A list of episode numbers. See also <see cref="PostEpisodesOld" />.</param>
        public PostSeasonOld(int number, PostEpisodesOld episodes)
        {
            Number = number;
            Episodes = episodes;
        }

        /// <summary>Gets or sets the number of this season.</summary>
        public int Number { get; set; }

        /// <summary>Gets or sets a list of episode numbers. See also <see cref="PostEpisodesOld" />.</summary>
        public PostEpisodesOld Episodes { get; set; }
    }
}
