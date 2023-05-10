namespace TraktNet.Objects.Get.Recommendations
{
    using Movies;
    using System.Collections.Generic;

    /// <summary>A Trakt recommended movie.</summary>
    public class TraktRecommendedMovie : TraktMovie, ITraktRecommendedMovie
    {
        /// <summary>Gets or sets the list of users who recommended this movie. See also <seealso cref="ITraktRecommendedBy" />.<para>Nullable</para></summary>
        public IList<ITraktRecommendedBy> RecommendedBy { get; set; }
    }
}
