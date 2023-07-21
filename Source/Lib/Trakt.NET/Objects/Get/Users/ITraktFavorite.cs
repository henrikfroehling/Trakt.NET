namespace TraktNet.Objects.Get.Users
{
    using Enums;
    using Movies;
    using Shows;
    using System;

    /// <summary>A Trakt favorite.</summary>
    public interface ITraktFavorite
    {
        /// <summary>Gets or sets the id of this favorite item.</summary>
        ulong? Id { get; set; }

        /// <summary>Gets or sets the favorite rank.</summary>
        int? Rank { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the favorite was listed.</summary>
        DateTime? ListedAt { get; set; }

        /// <summary>Gets or sets the favorite item type. See also <seealso cref="TraktFavoriteObjectType" />.<para>Nullable</para></summary>
        TraktFavoriteObjectType Type { get; set; }

        /// <summary>Gets or sets the favorite notes.</summary>
        string Notes { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktFavoriteObjectType.Movie" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktFavoriteObjectType.Show" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktShow Show { get; set; }
    }
}
