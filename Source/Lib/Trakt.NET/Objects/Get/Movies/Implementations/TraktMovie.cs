namespace TraktNet.Objects.Get.Movies
{
    using Enums;
    using System;
    using System.Collections.Generic;

    /// <summary>A Trakt movie.</summary>
    public class TraktMovie : ITraktMovie
    {
        /// <summary>Gets or sets the movie title.<para>Nullable</para></summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the movie release year.</summary>
        public int? Year { get; set; }

        /// <summary>
        /// Gets or sets the collection of ids for the movie for various web services.
        /// See also <seealso cref="ITraktMovieIds" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovieIds Ids { get; set; }

        /// <summary>Gets or sets the movie tagline.<para>Nullable</para></summary>
        public string Tagline { get; set; }

        /// <summary>Gets or sets the synopsis of the movie.<para>Nullable</para></summary>
        public string Overview { get; set; }

        /// <summary>Gets or sets the UTC datetime when the movie was released.</summary>
        public DateTime? Released { get; set; }

        /// <summary>Gets or sets the runtime for the movie.</summary>
        public int? Runtime { get; set; }

        /// <summary>Gets or sets the web address of a trailer for the movie.<para>Nullable</para></summary>
        public string Trailer { get; set; }

        /// <summary>Gets or sets the web address of the homepage of the movie.<para>Nullable</para></summary>
        public string Homepage { get; set; }

        /// <summary>Gets or sets the average user rating of the movie.</summary>
        public float? Rating { get; set; }

        /// <summary>Gets or sets the number of votes for the movie.</summary>
        public int? Votes { get; set; }

        /// <summary>Gets or sets the UTC datetime when the movie was last updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the two letter language code of the movie.<para>Nullable</para></summary>
        public string LanguageCode { get; set; }

        /// <summary>Gets or sets the list of translation language codes (two letters) for the movie.<para>Nullable</para></summary>
        public IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        /// <summary>Gets or sets the collection of Trakt genre slugs for the movie.<para>Nullable</para></summary>
        public IEnumerable<string> Genres { get; set; }

        /// <summary>Gets or sets the content certification of the movie.<para>Nullable</para></summary>
        public string Certification { get; set; }

        /// <summary>Gets or sets the content country code of the movie.<para>Nullable</para></summary>
        public string CountryCode { get; set; }

        /// <summary>Gets or sets the comment count of the movie.<para>Nullable</para></summary>
        public int? CommentCount { get; set; }

        /// <summary>Gets or sets the movie's current status. See also <seealso cref="TraktMovieStatus" />.<para>Nullable</para></summary>
        public TraktMovieStatus Status { get; set; }
    }
}
