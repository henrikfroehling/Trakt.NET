namespace TraktNet.Objects.Get.Users
{
    using Enums;
    using Movies;
    using Shows;
    using System;

    /// <summary>A Trakt recommendation.</summary>
    public interface ITraktRecommendation
    {
        /// <summary>Gets or sets the id of this recommendation item.</summary>
        ulong? Id { get; set; }

        /// <summary>Gets or sets the recommendation rank.</summary>
        int? Rank { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the recommendation was listed.</summary>
        DateTime? ListedAt { get; set; }

        /// <summary>Gets or sets the recommendation item type. See also <seealso cref="TraktRecommendationObjectType" />.<para>Nullable</para></summary>
        TraktRecommendationObjectType Type { get; set; }

        /// <summary>Gets or sets the recommendation notes.</summary>
        string Notes { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktRecommendationObjectType.Movie" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktRecommendationObjectType.Show" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktShow Show { get; set; }
    }
}
