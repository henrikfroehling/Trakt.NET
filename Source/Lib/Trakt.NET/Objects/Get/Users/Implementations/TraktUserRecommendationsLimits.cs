namespace TraktNet.Objects.Get.Users
{
    /// <summary>A collection of Trakt user recommendations limits.</summary>
    public class TraktUserRecommendationsLimits : ITraktUserRecommendationsLimits
    {
        /// <summary>Gets or sets the number maximum recommendations item count.</summary>
        public int? ItemCount { get; set; }
    }
}
