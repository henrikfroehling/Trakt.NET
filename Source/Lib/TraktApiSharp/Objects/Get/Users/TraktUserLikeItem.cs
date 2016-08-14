namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Basic;
    using Enums;
    using Lists;
    using Newtonsoft.Json;
    using System;

    /// <summary>Contains information about an item a Trakt user has liked, including the corresponding comment or list.</summary>
    public class TraktUserLikeItem
    {
        /// <summary>Gets or sets the UTC datetime, when the comment or list was liked.</summary>
        [JsonProperty(PropertyName = "liked_at")]
        public DateTime? LikedAt { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this liked item contains.
        /// See also <seealso cref="TraktUserLikeType" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktUserLikeType>))]
        [Nullable]
        public TraktUserLikeType Type { get; set; }

        /// <summary>
        /// Gets or sets the comment, if <see cref="Type" /> is <see cref="TraktUserLikeType.Comment" />.
        /// See also <seealso cref="TraktComment" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "comment")]
        [Nullable]
        public TraktComment Comment { get; set; }

        /// <summary>
        /// Gets or sets the list, if <see cref="Type" /> is <see cref="TraktUserLikeType.List" />.
        /// See also <seealso cref="TraktList" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "list")]
        [Nullable]
        public TraktList List { get; set; }
    }
}
