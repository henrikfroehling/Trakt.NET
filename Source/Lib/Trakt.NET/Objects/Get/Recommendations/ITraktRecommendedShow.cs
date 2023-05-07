namespace TraktNet.Objects.Get.Recommendations
{
    using Shows;
    using System.Collections.Generic;

    /// <summary>A Trakt recommended show.</summary>
    public interface ITraktRecommendedShow : ITraktShow
    {
        /// <summary>Gets or sets the list of users who recommended this show. See also <seealso cref="ITraktRecommendedBy" />.<para>Nullable</para></summary>
        IList<ITraktRecommendedBy> RecommendedBy { get; set; }
    }
}
