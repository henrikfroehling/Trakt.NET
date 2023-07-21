namespace TraktNet.Objects.Get.Users
{
    using Enums;
    using Movies;
    using Shows;
    using System;

    /// <summary>A Trakt favorite.</summary>
    public class TraktFavorite : ITraktFavorite
    {
        /// <summary>Gets or sets the id of this favorite item.</summary>
        public ulong? Id { get; set; }

        /// <summary>Gets or sets the favorite rank.</summary>
        public int? Rank { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the favorite was listed.</summary>
        public DateTime? ListedAt { get; set; }

        /// <summary>Gets or sets the favorite item type. See also <seealso cref="TraktFavoriteObjectType" />.<para>Nullable</para></summary>
        public TraktFavoriteObjectType Type { get; set; }

        /// <summary>Gets or sets the favorite notes.</summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktFavoriteObjectType.Movie" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktFavoriteObjectType.Show" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }
    }
}
