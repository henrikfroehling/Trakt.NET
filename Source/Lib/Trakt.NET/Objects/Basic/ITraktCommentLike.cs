namespace TraktNet.Objects.Basic
{
    using Get.Users;
    using System;

    /// <summary>Represents a Trakt comment like.</summary>
    public interface ITraktCommentLike
    {
        /// <summary>Gets or sets the UTC datetime, when the comment was liked.</summary>
        DateTime? LikedAt { get; set; }

        /// <summary>Gets or sets the user, who liked the comment.</summary>
        ITraktUser User { get; set; }
    }
}
