namespace TraktNet.Objects.Get.Lists
{
    using Enums;
    using System;
    using Users;

    /// <summary>A Trakt list.</summary>
    public class TraktList : ITraktList
    {
        /// <summary>Gets or sets the list title.<para>Nullable</para></summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the list description.<para>Nullable</para></summary>
        public string Description { get; set; }

        /// <summary>Gets or sets the list's visibility status. See also <seealso cref="TraktAccessScope" />.<para>Nullable</para></summary>
        public TraktAccessScope Privacy { get; set; }

        /// <summary>Gets or sets, whether the list displays ranking numbers.</summary>
        public bool? DisplayNumbers { get; set; }

        /// <summary>Gets or sets, whether the list allows comments.</summary>
        public bool? AllowComments { get; set; }

        /// <summary>Gets or sets the property, by which the list is sorted.<para>Nullable</para></summary>
        public string SortBy { get; set; }

        /// <summary>Gets or sets the sort order of the list.<para>Nullable</para></summary>
        public string SortHow { get; set; }

        /// <summary>Gets or sets the UTC datetime when the list was created.</summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime when the list was last updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the list item count.</summary>
        public int? ItemCount { get; set; }

        /// <summary>Gets or sets the list comment count.</summary>
        public int? CommentCount { get; set; }

        /// <summary>Gets or sets the count of likes of the list.</summary>
        public int? Likes { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the list for various web services.
        /// See also <seealso cref="ITraktListIds" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktListIds Ids { get; set; }

        /// <summary>
        /// Gets or sets the list's username of the user, which created this list.
        /// See also <seealso cref="ITraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktUser User { get; set; }
    }
}
