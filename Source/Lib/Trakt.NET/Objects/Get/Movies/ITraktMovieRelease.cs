namespace TraktNet.Objects.Get.Movies
{
    using Enums;
    using System;

    /// <summary>A release of a Trakt movie.</summary>
    public interface ITraktMovieRelease
    {
        /// <summary>Gets or sets the two letter country code for the movie release.<para>Nullable</para></summary>
        string CountryCode { get; set; }

        /// <summary>Gets or sets the content certification for the movie release.<para>Nullable</para></summary>
        string Certification { get; set; }

        /// <summary>Gets or sets the release date of the movie release.</summary>
        DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the release type for the movie release.
        /// See also <seealso cref="TraktReleaseType" />.
        /// <para>Nullable</para>
        /// </summary>
        TraktReleaseType ReleaseType { get; set; }

        /// <summary>Gets or sets a note for the movie release.<para>Nullable</para></summary>
        string Note { get; set; }
    }
}
