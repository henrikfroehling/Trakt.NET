namespace TraktNet.Objects.Post.Syncs.Responses
{
    /// <summary>A collection containing the number of movies, shows, seasons and episodes.</summary>
    public interface ITraktSyncPostResponseGroup
    {
        /// <summary>Gets or sets the number of movies.</summary>
        int? Movies { get; set; }

        /// <summary>Gets or sets the number of shows.</summary>
        int? Shows { get; set; }

        /// <summary>Gets or sets the number of seasons.</summary>
        int? Seasons { get; set; }

        /// <summary>Gets or sets the number of episodes.</summary>
        int? Episodes { get; set; }
    }
}
