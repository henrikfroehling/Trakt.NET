namespace TraktNet.Objects.Get.Recommendations
{
    using Shows;
    using System.Collections.Generic;

    /// <summary>A Trakt recommended show.</summary>
    public class TraktRecommendedShow : TraktShow, ITraktRecommendedShow
    {
        /// <summary>Gets or sets the list of users who recommended this show. See also <seealso cref="ITraktRecommendedBy" />.<para>Nullable</para></summary>
        public IList<ITraktRecommendedBy> RecommendedBy { get; set; }
    }
}
