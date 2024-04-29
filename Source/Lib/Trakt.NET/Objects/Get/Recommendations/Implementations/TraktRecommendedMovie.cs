namespace TraktNet.Objects.Get.Recommendations
{
    using Movies;
    using System.Collections.Generic;

    /// <summary>A Trakt recommended movie.</summary>
    public class TraktRecommendedMovie : TraktMovie, ITraktRecommendedMovie
    {
        /// <summary>Gets or sets the list of users who favorited this movie. See also <seealso cref="ITraktFavoritedBy" />.<para>Nullable</para></summary>
        public IList<ITraktFavoritedBy> FavoritedBy { get; set; }
    }
}
