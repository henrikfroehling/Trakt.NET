namespace TraktNet.Objects.Basic
{
    using Get.Users;
    using System;

    /// <summary>A Trakt comment or reply.</summary>
    public interface ITraktComment
    {
        /// <summary>Gets or sets the Trakt id of the comment.</summary>
        uint Id { get; set; }

        /// <summary>Gets or sets the parent comment id, if this comment is a reply.</summary>
        uint? ParentId { get; set; }

        /// <summary>Gets or sets the UTC datetime, when this comment was created.</summary>
        DateTime CreatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when this comment was last updated.</summary>
        DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the comment's content.<para>Nullable</para></summary>
        string Comment { get; set; }

        /// <summary>Gets or sets, whether the comment contains spoiler.</summary>
        bool Spoiler { get; set; }

        /// <summary>Gets or sets, whether the comment is a review.</summary>
        bool Review { get; set; }

        /// <summary>Gets or sets the number of replies for the comment.</summary>
        int? Replies { get; set; }

        /// <summary>Gets or sets the number of likes for the comment.</summary>
        int? Likes { get; set; }

        /// <summary>Gets or sets the user rating for the comment.</summary>
        float? UserRating { get; set; }

        /// <summary>Gets or sets the user, which has written the comment. See also <seealso cref="ITraktUser" />.<para>Nullable</para></summary>
        ITraktUser User { get; set; }
    }
}
