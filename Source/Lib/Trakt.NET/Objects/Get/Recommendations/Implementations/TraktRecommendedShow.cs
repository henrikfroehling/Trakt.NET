namespace TraktNet.Objects.Get.Recommendations
{
    using Shows;
    using System.Collections.Generic;

    /// <summary>A Trakt recommended show.</summary>
    public class TraktRecommendedShow : TraktShow, ITraktRecommendedShow
    {
        /// <summary>Gets or sets the list of users who favorited this show. See also <seealso cref="ITraktFavoritedBy" />.<para>Nullable</para></summary>
        public IList<ITraktFavoritedBy> FavoritedBy { get; set; }
    }
}
