namespace TraktNet.Objects.Get.Recommendations
{
    using Enums;
    using System;

    /// <summary>A Trakt recommendation.</summary>
    public interface ITraktRecommendation
    {
        /// <summary>Gets or sets the recommendation rank.</summary>
        int? Rank { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the recommendation was listed.</summary>
        DateTime? ListedAt { get; set; }

        /// <summary>Gets or sets the recommendation item type. See also <seealso cref="TraktRecommendationObjectType" />.<para>Nullable</para></summary>
        TraktRecommendationObjectType Type { get; set; }

        /// <summary>Gets or sets the recommendation notes.</summary>
        string Notes { get; set; }
    }
}
