namespace TraktNet.Objects.Post.Responses
{
    using System;

    /// <summary>A collection containing information about an updated list.</summary>
    public class TraktPostResponseListData : ITraktPostResponseListData
    {
        /// <summary>Gets or sets the UTC datetime when a list was updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the new item count of a list.</summary>
        public int? ItemCount { get; set; }
    }
}
