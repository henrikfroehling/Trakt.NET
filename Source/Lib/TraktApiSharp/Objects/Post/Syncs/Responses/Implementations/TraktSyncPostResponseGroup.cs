namespace TraktApiSharp.Objects.Post.Syncs.Responses.Implementations
{
    /// <summary>A collection containing the number of movies, shows, seasons and episodes.</summary>
    public class TraktSyncPostResponseGroup : ITraktSyncPostResponseGroup
    {
        /// <summary>Gets or sets the number of movies.</summary>
        public int? Movies { get; set; }

        /// <summary>Gets or sets the number of shows.</summary>
        public int? Shows { get; set; }

        /// <summary>Gets or sets the number of seasons.</summary>
        public int? Seasons { get; set; }

        /// <summary>Gets or sets the number of episodes.</summary>
        public int? Episodes { get; set; }
    }
}
