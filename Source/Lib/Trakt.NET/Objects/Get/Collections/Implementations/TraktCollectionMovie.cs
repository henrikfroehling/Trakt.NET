namespace TraktNet.Objects.Get.Collections
{
    using Basic;
    using Movies;
    using System;
    using System.Collections.Generic;

    /// <summary>Contains information about a collected Trakt movie.</summary>
    public class TraktCollectionMovie : ITraktCollectionMovie
    {
        /// <summary>Gets or sets the UTC datetime, when the movie was collected.</summary>
        public DateTime? CollectedAt { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the movie was updated.</summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the collected Trakt movie. See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets metadata about the collected movie. See also <seealso cref="ITraktMetadata" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMetadata Metadata { get; set; }

        /// <summary>Gets or sets the movie title.<para>Nullable</para></summary>
        public string Title
        {
            get { return Movie?.Title; }

            set
            {
                if (Movie != null)
                    Movie.Title = value;
            }
        }

        /// <summary>Gets or sets the movie release year.</summary>
        public int? Year
        {
            get { return Movie?.Year; }

            set
            {
                if (Movie != null)
                    Movie.Year = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of ids for the movie for various web services.
        /// See also <seealso cref="ITraktMovieIds" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovieIds Ids
        {
            get { return Movie?.Ids; }

            set
            {
                if (Movie != null)
                    Movie.Ids = value;
            }
        }

        /// <summary>Gets or sets the movie tagline.<para>Nullable</para></summary>
        public string Tagline
        {
            get { return Movie?.Tagline; }

            set
            {
                if (Movie != null)
                    Movie.Tagline = value;
            }
        }

        /// <summary>Gets or sets the synopsis of the movie.<para>Nullable</para></summary>
        public string Overview
        {
            get { return Movie?.Overview; }

            set
            {
                if (Movie != null)
                    Movie.Overview = value;
            }
        }

        /// <summary>Gets or sets the UTC datetime when the movie was released.</summary>
        public DateTime? Released
        {
            get { return Movie?.Released; }

            set
            {
                if (Movie != null)
                    Movie.Released = value;
            }
        }

        /// <summary>Gets or sets the runtime for the movie.</summary>
        public int? Runtime
        {
            get { return Movie?.Runtime; }

            set
            {
                if (Movie != null)
                    Movie.Runtime = value;
            }
        }

        /// <summary>Gets or sets the web address of a trailer for the movie.<para>Nullable</para></summary>
        public string Trailer
        {
            get { return Movie?.Trailer; }

            set
            {
                if (Movie != null)
                    Movie.Trailer = value;
            }
        }

        /// <summary>Gets or sets the web address of the homepage of the movie.<para>Nullable</para></summary>
        public string Homepage
        {
            get { return Movie?.Homepage; }

            set
            {
                if (Movie != null)
                    Movie.Homepage = value;
            }
        }

        /// <summary>Gets or sets the average user rating of the movie.</summary>
        public float? Rating
        {
            get { return Movie?.Rating; }

            set
            {
                if (Movie != null)
                    Movie.Rating = value;
            }
        }

        /// <summary>Gets or sets the number of votes for the movie.</summary>
        public int? Votes
        {
            get { return Movie?.Votes; }

            set
            {
                if (Movie != null)
                    Movie.Votes = value;
            }
        }

        public DateTime? MovieUpdatedAt
        /// <summary>Gets or sets the UTC datetime when the movie was last updated.</summary>
        {
            get { return Movie?.UpdatedAt; }

            set
            {
                if (Movie != null)
                    Movie.UpdatedAt = value;
            }
        }

        /// <summary>Gets or sets the two letter language code of the movie.<para>Nullable</para></summary>
        public string LanguageCode
        {
            get { return Movie?.LanguageCode; }

            set
            {
                if (Movie != null)
                    Movie.LanguageCode = value;
            }
        }

        /// <summary>Gets or sets the list of translation language codes (two letters) for the movie.<para>Nullable</para></summary>
        public IEnumerable<string> AvailableTranslationLanguageCodes
        {
            get { return Movie?.AvailableTranslationLanguageCodes; }

            set
            {
                if (Movie != null)
                    Movie.AvailableTranslationLanguageCodes = value;
            }
        }

        /// <summary>Gets or sets the collection of Trakt genre slugs for the movie.<para>Nullable</para></summary>
        public IEnumerable<string> Genres
        {
            get { return Movie?.Genres; }

            set
            {
                if (Movie != null)
                    Movie.Genres = value;
            }
        }

        /// <summary>Gets or sets the content certification of the movie.<para>Nullable</para></summary>
        public string Certification
        {
            get { return Movie?.Certification; }

            set
            {
                if (Movie != null)
                    Movie.Certification = value;
            }
        }

        /// <summary>Gets or sets the content country code of the movie.<para>Nullable</para></summary>
        public string CountryCode
        {
            get { return Movie?.CountryCode; }

            set
            {
                if (Movie != null)
                    Movie.CountryCode = value;
            }
        }

        /// <summary>Gets or sets the comment count of the movie.<para>Nullable</para></summary>
        public int? CommentCount
        {
            get { return Movie?.CommentCount; }

            set
            {
                if (Movie != null)
                    Movie.CommentCount = value;
            }
        }
    }
}
