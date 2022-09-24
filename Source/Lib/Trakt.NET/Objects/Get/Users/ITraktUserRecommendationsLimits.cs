namespace TraktNet.Objects.Get.Users
{
    /// <summary>A collection of Trakt user recommendations limits.</summary>
    public interface ITraktUserRecommendationsLimits
    {
        /// <summary>Gets or sets the number maximum recommendations item count.</summary>
        int? ItemCount { get; set; }
    }
}
