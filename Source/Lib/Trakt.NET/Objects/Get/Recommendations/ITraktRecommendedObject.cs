namespace TraktNet.Objects.Get.Recommendations
{
    using System.Collections.Generic;

    public interface ITraktRecommendedObject
    {
        /// <summary>Gets or sets the list of users who recommended this. See also <seealso cref="ITraktRecommendedBy" />.<para>Nullable</para></summary>
        IEnumerable<ITraktRecommendedBy> RecommendedBy { get; set; }
    }
}
