namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses
{
    /// <summary>A collection containing the number of movies and shows.</summary>
    public interface ITraktSyncRecommendationsPostResponseGroup
    {
        /// <summary>Gets or sets the number of movies.</summary>
        int? Movies { get; set; }

        /// <summary>Gets or sets the number of shows.</summary>
        int? Shows { get; set; }
    }
}
