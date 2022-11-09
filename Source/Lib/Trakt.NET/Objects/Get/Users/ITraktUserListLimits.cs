namespace TraktNet.Objects.Get.Users
{
    /// <summary>A collection of Trakt user list limits.</summary>
    public interface ITraktUserListLimits
    {
        /// <summary>Gets or sets the number maximum lists.</summary>
        int? Count { get; set; }

        /// <summary>Gets or sets the number maximum list's item count.</summary>
        int? ItemCount { get; set; }
    }
}
