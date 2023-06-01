namespace TraktNet.Objects.Basic
{
    using Get.Users;
    using System;

    /// <summary>A Trakt comment or reply.</summary>
    public class TraktComment : ITraktComment
    {
        /// <summary>Gets or sets the Trakt id of the comment.</summary>
        public uint Id { get; set; }

        /// <summary>Gets or sets the parent comment id, if this comment is a reply.</summary>
        public uint? ParentId { get; set; }

        /// <summary>Gets or sets the UTC datetime, when this comment was created.</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when this comment was last updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the comment's content.<para>Nullable</para></summary>
        public string Comment { get; set; }

        /// <summary>Gets or sets, whether the comment contains spoiler.</summary>
        public bool Spoiler { get; set; }

        /// <summary>Gets or sets, whether the comment is a review.</summary>
        public bool Review { get; set; }

        /// <summary>Gets or sets the number of replies for the comment.</summary>
        public int? Replies { get; set; }

        /// <summary>Gets or sets the number of likes for the comment.</summary>
        public int? Likes { get; set; }

        /// <summary>Gets or sets the user stats for the comment. See also <seealso cref="ITraktCommentUserStats" />.<para>Nullable</para></summary>
        public ITraktCommentUserStats UserStats { get; set; }

        /// <summary>Gets or sets the user, which has written the comment. See also <seealso cref="ITraktUser" />.<para>Nullable</para></summary>
        public ITraktUser User { get; set; }
    }
}
