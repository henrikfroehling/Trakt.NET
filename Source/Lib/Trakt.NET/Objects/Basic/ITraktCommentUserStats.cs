namespace TraktNet.Objects.Basic
{
    /// <summary>A Trakt user stats for a comment or reply.</summary>
    public interface ITraktCommentUserStats
    {
        /// <summary>Gets or sets the user rating for the comment.</summary>
        int? Rating { get; set; }

        /// <summary>Gets or sets the user play count for the comment.</summary>
        int? PlayCount { get; set; }

        /// <summary>Gets or sets the user completed count for the comment.</summary>
        int? CompletedCount { get; set; }
    }
}
