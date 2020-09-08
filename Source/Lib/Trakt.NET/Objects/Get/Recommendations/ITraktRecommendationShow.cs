namespace TraktNet.Objects.Get.Recommendations
{
    using Shows;

    /// <summary>A Trakt recommendation show, containing show information.</summary>
    public interface ITraktRecommendationShow : ITraktRecommendation, ITraktShow
    {
        /// <summary>Gets or sets the show.<para>Nullable</para></summary>
        ITraktShow Show { get; set; }
    }
}
