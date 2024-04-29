namespace TraktNet.Objects.Get.Recommendations
{
    using Movies;
    using System.Collections.Generic;

    /// <summary>A Trakt recommended movie.</summary>
    public interface ITraktRecommendedMovie : ITraktMovie
    {
        /// <summary>Gets or sets the list of users who favorited this movie. See also <seealso cref="ITraktFavoritedBy" />.<para>Nullable</para></summary>
        IList<ITraktFavoritedBy> FavoritedBy { get; set; }
    }
}
