namespace TraktNet.PostBuilder
{
    /// <summary>Contains an episode number.</summary>
    public sealed class PostEpisode
    {
        /// <summary>Gets the number of this episode.</summary>
        public int Number { get; }

        /// <summary>Initializes a new instance of the <see cref="PostEpisode" /> class.</summary>
        /// <param name="number">The number of this episode.</param>
        public PostEpisode(int number) => Number = number;
    }
}
