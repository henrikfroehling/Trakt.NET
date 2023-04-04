namespace TraktNet.Objects.Get.Recommendations
{
    using Movies;

    /// <summary>A Trakt recommended movie.</summary>
    public interface ITraktRecommendedMovie : ITraktRecommendedObject, ITraktMovie
    {
    }
}
