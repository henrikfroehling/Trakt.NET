namespace TraktNet.Objects.Get.Users
{
    /// <summary>A collection of Trakt user favorites limits.</summary>
    public interface ITraktUserFavoritesLimits
    {
        /// <summary>Gets or sets the number maximum favorites item count.</summary>
        int? ItemCount { get; set; }
    }
}
