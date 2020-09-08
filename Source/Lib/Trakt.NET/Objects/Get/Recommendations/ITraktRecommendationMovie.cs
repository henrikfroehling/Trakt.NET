namespace TraktNet.Objects.Get.Recommendations
{
    using Movies;

    /// <summary>A Trakt recommendation movie, containing movie information.</summary>
    public interface ITraktRecommendationMovie : ITraktRecommendation, ITraktMovie
    {
        /// <summary>Gets or sets the movie.<para>Nullable</para></summary>
        ITraktMovie Movie { get; set; }
    }
}
