namespace TraktNet.Objects.Get.Users
{
    /// <summary>A collection of Trakt user favorites limits.</summary>
    public class TraktUserFavoritesLimits : ITraktUserFavoritesLimits
    {
        /// <summary>Gets or sets the number maximum favorites item count.</summary>
        public int? ItemCount { get; set; }
    }
}
