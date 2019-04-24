namespace TraktNet.Objects.Basic
{
    using Get.Users;
    using System;

    /// <summary>Represents a Trakt comment like.</summary>
    public class TraktCommentLike : ITraktCommentLike
    {
        /// <summary>Gets or sets the UTC datetime, when the comment was liked.</summary>
        public DateTime? LikedAt { get; set; }

        /// <summary>Gets or sets the user, who liked the comment.</summary>
        public ITraktUser User { get; set; }
    }
}
