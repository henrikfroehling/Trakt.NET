namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Get.Users;
    using Newtonsoft.Json;
    using System;

    /// <summary>A Trakt comment or reply.</summary>
    public class TraktComment
    {
        /// <summary>Gets or sets the Trakt id of the comment.</summary>
        [JsonProperty(PropertyName = "id")]
        public uint Id { get; set; }

        /// <summary>Gets or sets the parent comment id, if this comment is a reply.</summary>
        [JsonProperty(PropertyName = "parent_id")]
        public uint? ParentId { get; set; }

        /// <summary>Gets or sets the UTC datetime, when this comment was created.</summary>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when this comment was last updated.</summary>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the comment's content.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "comment")]
        [Nullable]
        public string Comment { get; set; }

        /// <summary>Gets or sets, whether the comment contains spoiler.</summary>
        [JsonProperty(PropertyName = "spoiler")]
        public bool Spoiler { get; set; }

        /// <summary>Gets or sets, whether the comment is a review.</summary>
        [JsonProperty(PropertyName = "review")]
        public bool Review { get; set; }

        /// <summary>Gets or sets the number of replies for the comment.</summary>
        [JsonProperty(PropertyName = "replies")]
        public int? Replies { get; set; }

        /// <summary>Gets or sets the number of likes for the comment.</summary>
        [JsonProperty(PropertyName = "likes")]
        public int? Likes { get; set; }

        /// <summary>Gets or sets the user rating for the comment.</summary>
        [JsonProperty(PropertyName = "user_rating")]
        public float? UserRating { get; set; }

        /// <summary>Gets or sets the user, which has written the comment. See also <seealso cref="TraktUser" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "user")]
        [Nullable]
        public TraktUser User { get; set; }
    }
}
