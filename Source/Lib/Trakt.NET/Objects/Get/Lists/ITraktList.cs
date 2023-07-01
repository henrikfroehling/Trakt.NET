namespace TraktNet.Objects.Get.Lists
{
    using Enums;
    using System;
    using Users;

    /// <summary>A Trakt list.</summary>
    public interface ITraktList
    {
        /// <summary>Gets or sets the list title.<para>Nullable</para></summary>
        string Name { get; set; }

        /// <summary>Gets or sets the list description.<para>Nullable</para></summary>
        string Description { get; set; }

        /// <summary>Gets or sets the list's visibility status. See also <seealso cref="TraktListPrivacy" />.<para>Nullable</para></summary>
        TraktListPrivacy Privacy { get; set; }

        /// <summary>Gets or sets the list's share link.<para>Nullable</para></summary>
        string ShareLink { get; set; }

        /// <summary>Gets or sets the list type. See also <seealso cref="TraktListType" />.<para>Nullable</para></summary>
        TraktListType Type { get; set; }

        /// <summary>Gets or sets, whether the list displays ranking numbers.</summary>
        bool? DisplayNumbers { get; set; }

        /// <summary>Gets or sets, whether the list allows comments.</summary>
        bool? AllowComments { get; set; }

        /// <summary>Gets or sets the property, by which the list is sorted. See also <seealso cref="TraktSortBy" />.<para>Nullable</para></summary>
        TraktSortBy SortBy { get; set; }

        /// <summary>Gets or sets the sort order of the list. See also <seealso cref="TraktSortHow" />.<para>Nullable</para></summary>
        TraktSortHow SortHow { get; set; }

        /// <summary>Gets or sets the UTC datetime when the list was created.</summary>
        DateTime? CreatedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime when the list was last updated.</summary>
        DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the list item count.</summary>
        int? ItemCount { get; set; }

        /// <summary>Gets or sets the list comment count.</summary>
        int? CommentCount { get; set; }

        /// <summary>Gets or sets the count of likes of the list.</summary>
        int? Likes { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the list for various web services.
        /// See also <seealso cref="ITraktListIds" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktListIds Ids { get; set; }

        /// <summary>
        /// Gets or sets the list's username of the user, which created this list.
        /// See also <seealso cref="ITraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktUser User { get; set; }
    }
}
