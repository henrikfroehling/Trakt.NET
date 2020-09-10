namespace TraktNet.Objects.Get.Users
{
    using Enums;
    using Movies;
    using Shows;
    using System;

    /// <summary>A Trakt recommendation.</summary>
    public class TraktRecommendation : ITraktRecommendation
    {
        /// <summary>Gets or sets the recommendation rank.</summary>
        public int? Rank { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the recommendation was listed.</summary>
        public DateTime? ListedAt { get; set; }

        /// <summary>Gets or sets the recommendation item type. See also <seealso cref="TraktRecommendationObjectType" />.<para>Nullable</para></summary>
        public TraktRecommendationObjectType Type { get; set; }

        /// <summary>Gets or sets the recommendation notes.</summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktRecommendationObjectType.Movie" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktRecommendationObjectType.Show" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }
    }
}
