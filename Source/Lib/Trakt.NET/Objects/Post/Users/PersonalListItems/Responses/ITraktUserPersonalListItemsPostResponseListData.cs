namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses
{
    using System;

    /// <summary>A collection containing information about an updated list.</summary>
    public interface ITraktUserPersonalListItemsPostResponseListData
    {
        /// <summary>Gets or sets the UTC datetime when a list was updated.</summary>
        DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the new item count of a list.</summary>
        int? ItemCount { get; set; }
    }
}
