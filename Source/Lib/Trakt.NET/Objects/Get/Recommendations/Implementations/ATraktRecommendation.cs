namespace TraktNet.Objects.Get.Recommendations
{
    using Enums;
    using System;

    /// <summary>A Trakt recommendation.</summary>
    public abstract class ATraktRecommendation : ITraktRecommendation
    {
        /// <summary>Gets or sets the recommendation rank.</summary>
        public int? Rank { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the recommendation was listed.</summary>
        public DateTime? ListedAt { get; set; }

        /// <summary>Gets or sets the recommendation item type. See also <seealso cref="TraktRecommendationObjectType" />.<para>Nullable</para></summary>
        public TraktRecommendationObjectType Type { get; set; }

        /// <summary>Gets or sets the recommendation notes.</summary>
        public string Notes { get; set; }
    }
}
