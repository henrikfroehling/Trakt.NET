namespace TraktNet.Objects.Get.Users
{
    /// <summary>A collection of Trakt user list limits.</summary>
    public class TraktUserListLimits : ITraktUserListLimits
    {
        /// <summary>Gets or sets the number maximum lists.</summary>
        public int? Count { get; set; }

        /// <summary>Gets or sets the number maximum list's item count.</summary>
        public int? ItemCount { get; set; }
    }
}
