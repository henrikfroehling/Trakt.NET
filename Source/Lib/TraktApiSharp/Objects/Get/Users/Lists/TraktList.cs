namespace TraktApiSharp.Objects.Get.Users.Lists
{
    using Attributes;
    using Enums;
    using Newtonsoft.Json;
    using System;

    /// <summary>A Trakt list.</summary>
    public class TraktList
    {
        /// <summary>Gets or sets the list title.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "name")]
        [Nullable]
        public string Name { get; set; }

        /// <summary>Gets or sets the list description.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "description")]
        [Nullable]
        public string Description { get; set; }

        /// <summary>Gets or sets the list's visibility status. See also <seealso cref="TraktAccessScope" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "privacy")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktAccessScope>))]
        [Nullable]
        public TraktAccessScope Privacy { get; set; }

        /// <summary>Gets or sets, whether the list displays ranking numbers.</summary>
        [JsonProperty(PropertyName = "display_numbers")]
        public bool? DisplayNumbers { get; set; }

        /// <summary>Gets or sets, whether the list allows comments.</summary>
        [JsonProperty(PropertyName = "allow_comments")]
        public bool? AllowComments { get; set; }

        /// <summary>Gets or sets the property, by which the list is sorted.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "sort_by")]
        [Nullable]
        public string SortBy { get; set; }

        /// <summary>Gets or sets the sort order of the list.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "sort_how")]
        [Nullable]
        public string SortHow { get; set; }

        /// <summary>Gets or sets the UTC datetime when the list was created.</summary>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime when the list was last updated.</summary>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the list item count.</summary>
        [JsonProperty(PropertyName = "item_count")]
        public int? ItemCount { get; set; }

        /// <summary>Gets or sets the list comment count.</summary>
        [JsonProperty(PropertyName = "comment_count")]
        public int? CommentCount { get; set; }

        /// <summary>Gets or sets the count of likes of the list.</summary>
        [JsonProperty(PropertyName = "likes")]
        public int? Likes { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the list for various web services.
        /// See also <seealso cref="TraktListIds" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "ids")]
        [Nullable]
        public TraktListIds Ids { get; set; }

        /// <summary>
        /// Gets or sets the list's username of the user, which created this list.
        /// See also <seealso cref="TraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        [Nullable]
        public TraktUser User { get; set; }
    }
}
